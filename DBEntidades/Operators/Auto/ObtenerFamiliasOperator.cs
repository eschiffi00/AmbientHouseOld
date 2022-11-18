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
    public partial class ObtenerFamiliasOperator
    {

        public static ObtenerFamilias GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerFamiliasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerFamilias where  = " + .ToString()).Tables[0];
            ObtenerFamilias obtenerFamilias = new ObtenerFamilias();
            foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerFamilias, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerFamilias;
        }

        public static List<ObtenerFamilias> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerFamiliasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerFamilias> lista = new List<ObtenerFamilias>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerFamilias").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerFamilias obtenerFamilias = new ObtenerFamilias();
                foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerFamilias, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerFamilias);
            }
            return lista;
        }
        public static ObtenerFamilias GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerFamiliasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerFamilias where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerFamilias ObtenerFamilias = new ObtenerFamilias();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerFamilias, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerFamilias;
        }
        public static List<ObtenerFamilias> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerFamiliasBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerFamilias where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerFamilias where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerFamilias> lista = new List<ObtenerFamilias>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerFamilias entidad = new ObtenerFamilias();
                    foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties())
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
			public static int Titulo { get; set; } = 200;
			public static int Subtitulo { get; set; } = 200;
			public static int Comentario { get; set; } = 2000;
			public static int Edad { get; set; } = 50;
			public static int Fantasia { get; set; } = 500;
			public static int Codigo { get; set; } = 50;
			public static int Descripcion { get; set; } = 500;


        }

        public static ObtenerFamilias Save(ObtenerFamilias obtenerFamilias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerFamiliasSave")) throw new PermisoException();
            if (obtenerFamilias. == -1) return Insert(obtenerFamilias);
            else return Update(obtenerFamilias);
        }

        public static ObtenerFamilias Insert(ObtenerFamilias obtenerFamilias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerFamiliasSave")) throw new PermisoException();
            string sql = "insert into ObtenerFamilias(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerFamilias, null));
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
            obtenerFamilias. = Convert.ToInt32(resp);
            return obtenerFamilias;
        }

        public static ObtenerFamilias Update(ObtenerFamilias obtenerFamilias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerFamiliasSave")) throw new PermisoException();
            string sql = "update ObtenerFamilias set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerFamilias).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerFamilias, null));
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
            sql += " where  = " + obtenerFamilias.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerFamilias;
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
