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
    public partial class ObtenerGruposconFamiliasOperator
    {

        public static ObtenerGruposconFamilias GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerGruposconFamiliasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerGruposconFamilias where  = " + .ToString()).Tables[0];
            ObtenerGruposconFamilias obtenerGruposconFamilias = new ObtenerGruposconFamilias();
            foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerGruposconFamilias, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerGruposconFamilias;
        }

        public static List<ObtenerGruposconFamilias> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerGruposconFamiliasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerGruposconFamilias> lista = new List<ObtenerGruposconFamilias>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerGruposconFamilias").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerGruposconFamilias obtenerGruposconFamilias = new ObtenerGruposconFamilias();
                foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerGruposconFamilias, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerGruposconFamilias);
            }
            return lista;
        }
        public static ObtenerGruposconFamilias GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerGruposconFamiliasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerGruposconFamilias where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerGruposconFamilias ObtenerGruposconFamilias = new ObtenerGruposconFamilias();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerGruposconFamilias, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerGruposconFamilias;
        }
        public static List<ObtenerGruposconFamilias> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerGruposconFamiliasBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerGruposconFamilias where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerGruposconFamilias where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerGruposconFamilias> lista = new List<ObtenerGruposconFamilias>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerGruposconFamilias entidad = new ObtenerGruposconFamilias();
                    foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties())
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
			public static int Codigo { get; set; } = 50;


        }

        public static ObtenerGruposconFamilias Save(ObtenerGruposconFamilias obtenerGruposconFamilias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerGruposconFamiliasSave")) throw new PermisoException();
            if (obtenerGruposconFamilias. == -1) return Insert(obtenerGruposconFamilias);
            else return Update(obtenerGruposconFamilias);
        }

        public static ObtenerGruposconFamilias Insert(ObtenerGruposconFamilias obtenerGruposconFamilias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerGruposconFamiliasSave")) throw new PermisoException();
            string sql = "insert into ObtenerGruposconFamilias(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerGruposconFamilias, null));
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
            obtenerGruposconFamilias. = Convert.ToInt32(resp);
            return obtenerGruposconFamilias;
        }

        public static ObtenerGruposconFamilias Update(ObtenerGruposconFamilias obtenerGruposconFamilias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerGruposconFamiliasSave")) throw new PermisoException();
            string sql = "update ObtenerGruposconFamilias set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerGruposconFamilias).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerGruposconFamilias, null));
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
            sql += " where  = " + obtenerGruposconFamilias.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerGruposconFamilias;
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
