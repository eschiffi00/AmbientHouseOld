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
    public partial class ObtenerPrecioCostoCateringOperator
    {

        public static ObtenerPrecioCostoCatering GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoCatering where  = " + .ToString()).Tables[0];
            ObtenerPrecioCostoCatering obtenerPrecioCostoCatering = new ObtenerPrecioCostoCatering();
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerPrecioCostoCatering, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerPrecioCostoCatering;
        }

        public static List<ObtenerPrecioCostoCatering> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerPrecioCostoCatering> lista = new List<ObtenerPrecioCostoCatering>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoCatering").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerPrecioCostoCatering obtenerPrecioCostoCatering = new ObtenerPrecioCostoCatering();
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerPrecioCostoCatering, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerPrecioCostoCatering);
            }
            return lista;
        }
        public static ObtenerPrecioCostoCatering GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoCatering where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerPrecioCostoCatering ObtenerPrecioCostoCatering = new ObtenerPrecioCostoCatering();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerPrecioCostoCatering, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerPrecioCostoCatering;
        }
        public static List<ObtenerPrecioCostoCatering> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoCateringBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerPrecioCostoCatering where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerPrecioCostoCatering where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerPrecioCostoCatering> lista = new List<ObtenerPrecioCostoCatering>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerPrecioCostoCatering entidad = new ObtenerPrecioCostoCatering();
                    foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties())
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
			public static int Descripcion { get; set; } = 50;


        }

        public static ObtenerPrecioCostoCatering Save(ObtenerPrecioCostoCatering obtenerPrecioCostoCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoCateringSave")) throw new PermisoException();
            if (obtenerPrecioCostoCatering. == -1) return Insert(obtenerPrecioCostoCatering);
            else return Update(obtenerPrecioCostoCatering);
        }

        public static ObtenerPrecioCostoCatering Insert(ObtenerPrecioCostoCatering obtenerPrecioCostoCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoCateringSave")) throw new PermisoException();
            string sql = "insert into ObtenerPrecioCostoCatering(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPrecioCostoCatering, null));
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
            obtenerPrecioCostoCatering. = Convert.ToInt32(resp);
            return obtenerPrecioCostoCatering;
        }

        public static ObtenerPrecioCostoCatering Update(ObtenerPrecioCostoCatering obtenerPrecioCostoCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoCateringSave")) throw new PermisoException();
            string sql = "update ObtenerPrecioCostoCatering set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoCatering).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPrecioCostoCatering, null));
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
            sql += " where  = " + obtenerPrecioCostoCatering.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerPrecioCostoCatering;
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
