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
    public partial class ObtenerEventosOperator
    {

        public static ObtenerEventos GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventos where  = " + .ToString()).Tables[0];
            ObtenerEventos obtenerEventos = new ObtenerEventos();
            foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerEventos, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerEventos;
        }

        public static List<ObtenerEventos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerEventos> lista = new List<ObtenerEventos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerEventos obtenerEventos = new ObtenerEventos();
                foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerEventos, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerEventos);
            }
            return lista;
        }
        public static ObtenerEventos GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventos where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerEventos ObtenerEventos = new ObtenerEventos();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerEventos, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerEventos;
        }
        public static List<ObtenerEventos> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerEventos where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerEventos where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerEventos> lista = new List<ObtenerEventos>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerEventos entidad = new ObtenerEventos();
                    foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties())
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

		public static List<ObtenerEventos> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<ObtenerEventos> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<ObtenerEventos> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<ObtenerEventos> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int ApellidoNombre { get; set; } = 300;
			public static int CARACTERISTICA { get; set; } = 50;
			public static int LOCACION { get; set; } = 50;
			public static int SECTOR { get; set; } = 200;
			public static int JORNADA { get; set; } = 50;
			public static int HorarioEvento { get; set; } = 50;
			public static int Estado { get; set; } = 50;
			public static int Ejecutivo { get; set; } = 100;
			public static int RazonSocial { get; set; } = 300;
			public static int EstadoPresupuesto { get; set; } = 50;
			public static int TipoEvento { get; set; } = 50;
			public static int Cliente { get; set; } = 401;


        }

        public static ObtenerEventos Save(ObtenerEventos obtenerEventos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSave")) throw new PermisoException();
            if (obtenerEventos. == -1) return Insert(obtenerEventos);
            else return Update(obtenerEventos);
        }

        public static ObtenerEventos Insert(ObtenerEventos obtenerEventos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSave")) throw new PermisoException();
            string sql = "insert into ObtenerEventos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerEventos, null));
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
            obtenerEventos. = Convert.ToInt32(resp);
            return obtenerEventos;
        }

        public static ObtenerEventos Update(ObtenerEventos obtenerEventos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSave")) throw new PermisoException();
            string sql = "update ObtenerEventos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerEventos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerEventos, null));
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
            sql += " where  = " + obtenerEventos.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerEventos;
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
