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
    public partial class ObtenerEventosNewOperator
    {

        public static ObtenerEventosNew GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosNewBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventosNew where  = " + .ToString()).Tables[0];
            ObtenerEventosNew obtenerEventosNew = new ObtenerEventosNew();
            foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerEventosNew, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerEventosNew;
        }

        public static List<ObtenerEventosNew> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosNewBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerEventosNew> lista = new List<ObtenerEventosNew>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventosNew").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerEventosNew obtenerEventosNew = new ObtenerEventosNew();
                foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerEventosNew, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerEventosNew);
            }
            return lista;
        }
        public static ObtenerEventosNew GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosNewBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventosNew where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerEventosNew ObtenerEventosNew = new ObtenerEventosNew();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerEventosNew, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerEventosNew;
        }
        public static List<ObtenerEventosNew> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosNewBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerEventosNew where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerEventosNew where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerEventosNew> lista = new List<ObtenerEventosNew>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerEventosNew entidad = new ObtenerEventosNew();
                    foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties())
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

		public static List<ObtenerEventosNew> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<ObtenerEventosNew> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<ObtenerEventosNew> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<ObtenerEventosNew> GetAllEstadoNotN(int estado)
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
			public static int TipoExperiencia { get; set; } = 400;
			public static int TipoBarra { get; set; } = 300;


        }

        public static ObtenerEventosNew Save(ObtenerEventosNew obtenerEventosNew)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosNewSave")) throw new PermisoException();
            if (obtenerEventosNew. == -1) return Insert(obtenerEventosNew);
            else return Update(obtenerEventosNew);
        }

        public static ObtenerEventosNew Insert(ObtenerEventosNew obtenerEventosNew)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosNewSave")) throw new PermisoException();
            string sql = "insert into ObtenerEventosNew(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerEventosNew, null));
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
            obtenerEventosNew. = Convert.ToInt32(resp);
            return obtenerEventosNew;
        }

        public static ObtenerEventosNew Update(ObtenerEventosNew obtenerEventosNew)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosNewSave")) throw new PermisoException();
            string sql = "update ObtenerEventosNew set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerEventosNew).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerEventosNew, null));
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
            sql += " where  = " + obtenerEventosNew.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerEventosNew;
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
