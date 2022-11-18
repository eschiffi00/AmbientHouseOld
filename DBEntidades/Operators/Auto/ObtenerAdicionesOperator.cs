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
    public partial class ObtenerAdicionesOperator
    {

        public static ObtenerAdiciones GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerAdicionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerAdiciones where  = " + .ToString()).Tables[0];
            ObtenerAdiciones obtenerAdiciones = new ObtenerAdiciones();
            foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerAdiciones, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerAdiciones;
        }

        public static List<ObtenerAdiciones> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerAdicionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerAdiciones> lista = new List<ObtenerAdiciones>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerAdiciones").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerAdiciones obtenerAdiciones = new ObtenerAdiciones();
                foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerAdiciones, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerAdiciones);
            }
            return lista;
        }
        public static ObtenerAdiciones GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerAdicionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerAdiciones where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerAdiciones ObtenerAdiciones = new ObtenerAdiciones();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerAdiciones, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerAdiciones;
        }
        public static List<ObtenerAdiciones> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerAdicionesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerAdiciones where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerAdiciones where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerAdiciones> lista = new List<ObtenerAdiciones>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerAdiciones entidad = new ObtenerAdiciones();
                    foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties())
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

		public static List<ObtenerAdiciones> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<ObtenerAdiciones> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<ObtenerAdiciones> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<ObtenerAdiciones> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int Descripcion { get; set; } = 300;
			public static int Rubro { get; set; } = 50;
			public static int EstadoDescripcion { get; set; } = 50;
			public static int RequiereCantidad { get; set; } = 1;


        }

        public static ObtenerAdiciones Save(ObtenerAdiciones obtenerAdiciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerAdicionesSave")) throw new PermisoException();
            if (obtenerAdiciones. == -1) return Insert(obtenerAdiciones);
            else return Update(obtenerAdiciones);
        }

        public static ObtenerAdiciones Insert(ObtenerAdiciones obtenerAdiciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerAdicionesSave")) throw new PermisoException();
            string sql = "insert into ObtenerAdiciones(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerAdiciones, null));
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
            obtenerAdiciones. = Convert.ToInt32(resp);
            return obtenerAdiciones;
        }

        public static ObtenerAdiciones Update(ObtenerAdiciones obtenerAdiciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerAdicionesSave")) throw new PermisoException();
            string sql = "update ObtenerAdiciones set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerAdiciones).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerAdiciones, null));
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
            sql += " where  = " + obtenerAdiciones.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerAdiciones;
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
