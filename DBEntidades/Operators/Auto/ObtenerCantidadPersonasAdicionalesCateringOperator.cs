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
    public partial class ObtenerCantidadPersonasAdicionalesCateringOperator
    {

        public static ObtenerCantidadPersonasAdicionalesCatering GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadPersonasAdicionalesCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerCantidadPersonasAdicionalesCatering where  = " + .ToString()).Tables[0];
            ObtenerCantidadPersonasAdicionalesCatering obtenerCantidadPersonasAdicionalesCatering = new ObtenerCantidadPersonasAdicionalesCatering();
            foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerCantidadPersonasAdicionalesCatering, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerCantidadPersonasAdicionalesCatering;
        }

        public static List<ObtenerCantidadPersonasAdicionalesCatering> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadPersonasAdicionalesCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerCantidadPersonasAdicionalesCatering> lista = new List<ObtenerCantidadPersonasAdicionalesCatering>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerCantidadPersonasAdicionalesCatering").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerCantidadPersonasAdicionalesCatering obtenerCantidadPersonasAdicionalesCatering = new ObtenerCantidadPersonasAdicionalesCatering();
                foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerCantidadPersonasAdicionalesCatering, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerCantidadPersonasAdicionalesCatering);
            }
            return lista;
        }
        public static ObtenerCantidadPersonasAdicionalesCatering GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadPersonasAdicionalesCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerCantidadPersonasAdicionalesCatering where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerCantidadPersonasAdicionalesCatering ObtenerCantidadPersonasAdicionalesCatering = new ObtenerCantidadPersonasAdicionalesCatering();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerCantidadPersonasAdicionalesCatering, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerCantidadPersonasAdicionalesCatering;
        }
        public static List<ObtenerCantidadPersonasAdicionalesCatering> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadPersonasAdicionalesCateringBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerCantidadPersonasAdicionalesCatering where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerCantidadPersonasAdicionalesCatering where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerCantidadPersonasAdicionalesCatering> lista = new List<ObtenerCantidadPersonasAdicionalesCatering>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerCantidadPersonasAdicionalesCatering entidad = new ObtenerCantidadPersonasAdicionalesCatering();
                    foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties())
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

        public static ObtenerCantidadPersonasAdicionalesCatering Save(ObtenerCantidadPersonasAdicionalesCatering obtenerCantidadPersonasAdicionalesCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadPersonasAdicionalesCateringSave")) throw new PermisoException();
            if (obtenerCantidadPersonasAdicionalesCatering. == -1) return Insert(obtenerCantidadPersonasAdicionalesCatering);
            else return Update(obtenerCantidadPersonasAdicionalesCatering);
        }

        public static ObtenerCantidadPersonasAdicionalesCatering Insert(ObtenerCantidadPersonasAdicionalesCatering obtenerCantidadPersonasAdicionalesCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadPersonasAdicionalesCateringSave")) throw new PermisoException();
            string sql = "insert into ObtenerCantidadPersonasAdicionalesCatering(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerCantidadPersonasAdicionalesCatering, null));
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
            obtenerCantidadPersonasAdicionalesCatering. = Convert.ToInt32(resp);
            return obtenerCantidadPersonasAdicionalesCatering;
        }

        public static ObtenerCantidadPersonasAdicionalesCatering Update(ObtenerCantidadPersonasAdicionalesCatering obtenerCantidadPersonasAdicionalesCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadPersonasAdicionalesCateringSave")) throw new PermisoException();
            string sql = "update ObtenerCantidadPersonasAdicionalesCatering set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerCantidadPersonasAdicionalesCatering).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerCantidadPersonasAdicionalesCatering, null));
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
            sql += " where  = " + obtenerCantidadPersonasAdicionalesCatering.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerCantidadPersonasAdicionalesCatering;
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
