using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using DbEntidades.Entities;
using System.Data.SqlClient;
using LibDB2;

namespace DbEntidades.Operators
{
    public partial class ObjetivosEmpleadosOperator
    {

        public static ObjetivosEmpleados GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObjetivosEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObjetivosEmpleados where Id = " + Id.ToString()).Tables[0];
            ObjetivosEmpleados objetivosEmpleados = new ObjetivosEmpleados();
            foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(objetivosEmpleados, value, null); }
                catch (System.ArgumentException) { }
            }
            return objetivosEmpleados;
        }

        public static List<ObjetivosEmpleados> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObjetivosEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObjetivosEmpleados> lista = new List<ObjetivosEmpleados>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObjetivosEmpleados").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObjetivosEmpleados objetivosEmpleados = new ObjetivosEmpleados();
                foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(objetivosEmpleados, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(objetivosEmpleados);
            }
            return lista;
        }
        public static ObjetivosEmpleados GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObjetivosEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties())
        {
            if (prop.Name == campo)
            {
                tipo = prop.PropertyType.Name.ToString();
            }
            if (prop.Name == "Delete")
            {
                columnas += "[" + prop.Name + "]" + ", ";
            }
            else
            {
                columnas += prop.Name + ", ";
            }

        }
        columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObjetivosEmpleados where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObjetivosEmpleados ObjetivosEmpleados = new ObjetivosEmpleados();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObjetivosEmpleados, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObjetivosEmpleados;
        }
        public static List<ObjetivosEmpleados> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObjetivosEmpleadosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties())
                {
                    if (prop.Name == campo)
                    {
                        tipo = prop.PropertyType.Name.ToString();
                    }
                    if (prop.Name == "Delete")
                    {
                        columnas += "[" + prop.Name + "]" + ", ";
                    }
                    else
                    {
                        columnas += prop.Name + ", ";
                    }

                }
                columnas = columnas.Substring(0, columnas.Length - 2);
                DB db = new DB();
                var queryStr = string.Empty;
                if (tipo == "String")
                {
                    queryStr = "select " + columnas + " from ObjetivosEmpleados where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObjetivosEmpleados where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObjetivosEmpleados> lista = new List<ObjetivosEmpleados>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObjetivosEmpleados entidad = new ObjetivosEmpleados();
                    foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties())
                    {
                        object value = dr[prop.Name];
                        if (value == DBNull.Value) value = null;
                        try { prop.SetValue(entidad, value, null); }
                        catch (System.ArgumentException) { }
                    }
                    lista.Add(entidad);
                }
                return lista;
            }



        public class MaxLength
        {


        }

        public static ObjetivosEmpleados Save(ObjetivosEmpleados objetivosEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObjetivosEmpleadosSave")) throw new PermisoException();
            if (objetivosEmpleados.Id == -1) return Insert(objetivosEmpleados);
            else return Update(objetivosEmpleados);
        }

        public static ObjetivosEmpleados Insert(ObjetivosEmpleados objetivosEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObjetivosEmpleadosSave")) throw new PermisoException();
            string sql = "insert into ObjetivosEmpleados(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(objetivosEmpleados, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            valores = valores.Substring(0, valores.Length - 2);
            sql += columnas + ") output inserted.Id values (" + valores + ")";
            DB db = new DB();
            List<object> parametros = new List<object>();
            for (int i = 0; i < param.Count; i++)
            {
                parametros.Add(param[i]);
                parametros.Add(valor[i]);
                SqlParameter p = new SqlParameter(param[i].ToString(), valor[i]);
                sqlParams.Add(p);
            }
            //object resp = db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            objetivosEmpleados.Id = Convert.ToInt32(resp);
            return objetivosEmpleados;
        }

        public static ObjetivosEmpleados Update(ObjetivosEmpleados objetivosEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObjetivosEmpleadosSave")) throw new PermisoException();
            string sql = "update ObjetivosEmpleados set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObjetivosEmpleados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(objetivosEmpleados, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            sql += columnas;
            List<object> parametros = new List<object>();
            for (int i = 0; i<param.Count; i++)
            {
                parametros.Add(param[i]);
                parametros.Add(valor[i]);
                SqlParameter p = new SqlParameter(param[i].ToString(), valor[i]);
                sqlParams.Add(p);
        }
            sql += " where Id = " + objetivosEmpleados.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return objetivosEmpleados;
    }

        private static string GetComilla(string tipo)
        {
            switch (tipo) //son tipos de c#
            {
                case "Int32": return "";
                case "String": return "'";
                case "DateTime": return "'";
                case "Nullable`1": return "'";
            }
            return "";
        }

        public static string VerificaStringNull(string v)
        {
            return v == string.Empty ? null : v;
        }
    }
}
