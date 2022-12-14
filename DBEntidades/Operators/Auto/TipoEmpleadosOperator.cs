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
    public partial class TipoEmpleadosOperator
    {

        public static TipoEmpleados GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoEmpleados where Id = " + Id.ToString()).Tables[0];
            TipoEmpleados tipoEmpleados = new TipoEmpleados();
            foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(tipoEmpleados, value, null); }
                catch (System.ArgumentException) { }
            }
            return tipoEmpleados;
        }

        public static List<TipoEmpleados> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TipoEmpleados> lista = new List<TipoEmpleados>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoEmpleados").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TipoEmpleados tipoEmpleados = new TipoEmpleados();
                foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(tipoEmpleados, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(tipoEmpleados);
            }
            return lista;
        }
        public static TipoEmpleados GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoEmpleados where  " + campo + " = \'" + valor + "\'").Tables[0];
            TipoEmpleados TipoEmpleados = new TipoEmpleados();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(TipoEmpleados, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return TipoEmpleados;
        }
        public static List<TipoEmpleados> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoTipoEmpleadosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties())
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
                    queryStr = "select " + columnas + " from TipoEmpleados where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from TipoEmpleados where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<TipoEmpleados> lista = new List<TipoEmpleados>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    TipoEmpleados entidad = new TipoEmpleados();
                    foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties())
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
			public static int Descripcion { get; set; } = 200;


        }

        public static TipoEmpleados Save(TipoEmpleados tipoEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoEmpleadosSave")) throw new PermisoException();
            if (tipoEmpleados.Id == -1) return Insert(tipoEmpleados);
            else return Update(tipoEmpleados);
        }

        public static TipoEmpleados Insert(TipoEmpleados tipoEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoEmpleadosSave")) throw new PermisoException();
            string sql = "insert into TipoEmpleados(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoEmpleados, null));
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
            tipoEmpleados.Id = Convert.ToInt32(resp);
            return tipoEmpleados;
        }

        public static TipoEmpleados Update(TipoEmpleados tipoEmpleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoEmpleadosSave")) throw new PermisoException();
            string sql = "update TipoEmpleados set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoEmpleados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoEmpleados, null));
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
            sql += " where Id = " + tipoEmpleados.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return tipoEmpleados;
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
