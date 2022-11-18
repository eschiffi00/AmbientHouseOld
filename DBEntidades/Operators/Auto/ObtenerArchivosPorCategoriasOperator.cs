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
    public partial class ObtenerArchivosPorCategoriasOperator
    {

        public static ObtenerArchivosPorCategorias GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerArchivosPorCategoriasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerArchivosPorCategorias where  = " + .ToString()).Tables[0];
            ObtenerArchivosPorCategorias obtenerArchivosPorCategorias = new ObtenerArchivosPorCategorias();
            foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerArchivosPorCategorias, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerArchivosPorCategorias;
        }

        public static List<ObtenerArchivosPorCategorias> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerArchivosPorCategoriasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerArchivosPorCategorias> lista = new List<ObtenerArchivosPorCategorias>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerArchivosPorCategorias").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerArchivosPorCategorias obtenerArchivosPorCategorias = new ObtenerArchivosPorCategorias();
                foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerArchivosPorCategorias, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerArchivosPorCategorias);
            }
            return lista;
        }
        public static ObtenerArchivosPorCategorias GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerArchivosPorCategoriasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerArchivosPorCategorias where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerArchivosPorCategorias ObtenerArchivosPorCategorias = new ObtenerArchivosPorCategorias();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerArchivosPorCategorias, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerArchivosPorCategorias;
        }
        public static List<ObtenerArchivosPorCategorias> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerArchivosPorCategoriasBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerArchivosPorCategorias where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerArchivosPorCategorias where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerArchivosPorCategorias> lista = new List<ObtenerArchivosPorCategorias>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerArchivosPorCategorias entidad = new ObtenerArchivosPorCategorias();
                    foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties())
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
			public static int Descripcion { get; set; } = 100;
			public static int ExtencionArchivo { get; set; } = 10;
			public static int Carpeta { get; set; } = 50;


        }

        public static ObtenerArchivosPorCategorias Save(ObtenerArchivosPorCategorias obtenerArchivosPorCategorias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerArchivosPorCategoriasSave")) throw new PermisoException();
            if (obtenerArchivosPorCategorias. == -1) return Insert(obtenerArchivosPorCategorias);
            else return Update(obtenerArchivosPorCategorias);
        }

        public static ObtenerArchivosPorCategorias Insert(ObtenerArchivosPorCategorias obtenerArchivosPorCategorias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerArchivosPorCategoriasSave")) throw new PermisoException();
            string sql = "insert into ObtenerArchivosPorCategorias(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerArchivosPorCategorias, null));
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
            obtenerArchivosPorCategorias. = Convert.ToInt32(resp);
            return obtenerArchivosPorCategorias;
        }

        public static ObtenerArchivosPorCategorias Update(ObtenerArchivosPorCategorias obtenerArchivosPorCategorias)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerArchivosPorCategoriasSave")) throw new PermisoException();
            string sql = "update ObtenerArchivosPorCategorias set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerArchivosPorCategorias).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerArchivosPorCategorias, null));
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
            sql += " where  = " + obtenerArchivosPorCategorias.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerArchivosPorCategorias;
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
