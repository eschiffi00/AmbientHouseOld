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
    public partial class ObtenerCantidadInvitadosCateringOperator
    {

        public static ObtenerCantidadInvitadosCatering GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadInvitadosCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerCantidadInvitadosCatering where  = " + .ToString()).Tables[0];
            ObtenerCantidadInvitadosCatering obtenerCantidadInvitadosCatering = new ObtenerCantidadInvitadosCatering();
            foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerCantidadInvitadosCatering, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerCantidadInvitadosCatering;
        }

        public static List<ObtenerCantidadInvitadosCatering> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadInvitadosCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerCantidadInvitadosCatering> lista = new List<ObtenerCantidadInvitadosCatering>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerCantidadInvitadosCatering").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerCantidadInvitadosCatering obtenerCantidadInvitadosCatering = new ObtenerCantidadInvitadosCatering();
                foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerCantidadInvitadosCatering, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerCantidadInvitadosCatering);
            }
            return lista;
        }
        public static ObtenerCantidadInvitadosCatering GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadInvitadosCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerCantidadInvitadosCatering where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerCantidadInvitadosCatering ObtenerCantidadInvitadosCatering = new ObtenerCantidadInvitadosCatering();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerCantidadInvitadosCatering, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerCantidadInvitadosCatering;
        }
        public static List<ObtenerCantidadInvitadosCatering> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadInvitadosCateringBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerCantidadInvitadosCatering where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerCantidadInvitadosCatering where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerCantidadInvitadosCatering> lista = new List<ObtenerCantidadInvitadosCatering>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerCantidadInvitadosCatering entidad = new ObtenerCantidadInvitadosCatering();
                    foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties())
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

        public static ObtenerCantidadInvitadosCatering Save(ObtenerCantidadInvitadosCatering obtenerCantidadInvitadosCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadInvitadosCateringSave")) throw new PermisoException();
            if (obtenerCantidadInvitadosCatering. == -1) return Insert(obtenerCantidadInvitadosCatering);
            else return Update(obtenerCantidadInvitadosCatering);
        }

        public static ObtenerCantidadInvitadosCatering Insert(ObtenerCantidadInvitadosCatering obtenerCantidadInvitadosCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadInvitadosCateringSave")) throw new PermisoException();
            string sql = "insert into ObtenerCantidadInvitadosCatering(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerCantidadInvitadosCatering, null));
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
            obtenerCantidadInvitadosCatering. = Convert.ToInt32(resp);
            return obtenerCantidadInvitadosCatering;
        }

        public static ObtenerCantidadInvitadosCatering Update(ObtenerCantidadInvitadosCatering obtenerCantidadInvitadosCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerCantidadInvitadosCateringSave")) throw new PermisoException();
            string sql = "update ObtenerCantidadInvitadosCatering set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerCantidadInvitadosCatering).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerCantidadInvitadosCatering, null));
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
            sql += " where  = " + obtenerCantidadInvitadosCatering.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerCantidadInvitadosCatering;
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
