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
    public partial class ControlEventosConfirmadosOperator
    {

        public static ControlEventosConfirmados GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoControlEventosConfirmadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ControlEventosConfirmados where  = " + .ToString()).Tables[0];
            ControlEventosConfirmados controlEventosConfirmados = new ControlEventosConfirmados();
            foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(controlEventosConfirmados, value, null); }
                catch (System.ArgumentException) { }
            }
            return controlEventosConfirmados;
        }

        public static List<ControlEventosConfirmados> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoControlEventosConfirmadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ControlEventosConfirmados> lista = new List<ControlEventosConfirmados>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ControlEventosConfirmados").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ControlEventosConfirmados controlEventosConfirmados = new ControlEventosConfirmados();
                foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(controlEventosConfirmados, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(controlEventosConfirmados);
            }
            return lista;
        }
        public static ControlEventosConfirmados GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoControlEventosConfirmadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ControlEventosConfirmados where  " + campo + " = \'" + valor + "\'").Tables[0];
            ControlEventosConfirmados ControlEventosConfirmados = new ControlEventosConfirmados();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ControlEventosConfirmados, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ControlEventosConfirmados;
        }
        public static List<ControlEventosConfirmados> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoControlEventosConfirmadosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties())
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
                    queryStr = "select " + columnas + " from ControlEventosConfirmados where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ControlEventosConfirmados where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ControlEventosConfirmados> lista = new List<ControlEventosConfirmados>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ControlEventosConfirmados entidad = new ControlEventosConfirmados();
                    foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties())
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

        public static ControlEventosConfirmados Save(ControlEventosConfirmados controlEventosConfirmados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoControlEventosConfirmadosSave")) throw new PermisoException();
            if (controlEventosConfirmados. == -1) return Insert(controlEventosConfirmados);
            else return Update(controlEventosConfirmados);
        }

        public static ControlEventosConfirmados Insert(ControlEventosConfirmados controlEventosConfirmados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoControlEventosConfirmadosSave")) throw new PermisoException();
            string sql = "insert into ControlEventosConfirmados(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(controlEventosConfirmados, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            valores = valores.Substring(0, valores.Length - 2);
            sql += columnas + ") output inserted. values (" + valores + ")";
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
            controlEventosConfirmados. = Convert.ToInt32(resp);
            return controlEventosConfirmados;
        }

        public static ControlEventosConfirmados Update(ControlEventosConfirmados controlEventosConfirmados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoControlEventosConfirmadosSave")) throw new PermisoException();
            string sql = "update ControlEventosConfirmados set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ControlEventosConfirmados).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(controlEventosConfirmados, null));
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
            sql += " where  = " + controlEventosConfirmados.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return controlEventosConfirmados;
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
