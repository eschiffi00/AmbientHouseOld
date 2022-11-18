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
    public partial class ObtenerEventosSeguimientoOperator
    {

        public static ObtenerEventosSeguimiento GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSeguimientoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventosSeguimiento where  = " + .ToString()).Tables[0];
            ObtenerEventosSeguimiento obtenerEventosSeguimiento = new ObtenerEventosSeguimiento();
            foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerEventosSeguimiento, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerEventosSeguimiento;
        }

        public static List<ObtenerEventosSeguimiento> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSeguimientoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerEventosSeguimiento> lista = new List<ObtenerEventosSeguimiento>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventosSeguimiento").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerEventosSeguimiento obtenerEventosSeguimiento = new ObtenerEventosSeguimiento();
                foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerEventosSeguimiento, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerEventosSeguimiento);
            }
            return lista;
        }
        public static ObtenerEventosSeguimiento GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSeguimientoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerEventosSeguimiento where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerEventosSeguimiento ObtenerEventosSeguimiento = new ObtenerEventosSeguimiento();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerEventosSeguimiento, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerEventosSeguimiento;
        }
        public static List<ObtenerEventosSeguimiento> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSeguimientoBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerEventosSeguimiento where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerEventosSeguimiento where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerEventosSeguimiento> lista = new List<ObtenerEventosSeguimiento>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerEventosSeguimiento entidad = new ObtenerEventosSeguimiento();
                    foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties())
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

		public static List<ObtenerEventosSeguimiento> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<ObtenerEventosSeguimiento> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<ObtenerEventosSeguimiento> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<ObtenerEventosSeguimiento> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int RazonSocial { get; set; } = 200;
			public static int ApellidoNombreCliente { get; set; } = 100;
			public static int Mail { get; set; } = 100;
			public static int Celular { get; set; } = 50;
			public static int ApellidoNombre { get; set; } = 50;
			public static int Descripcion { get; set; } = 50;
			public static int Comentario { get; set; } = 2000;


        }

        public static ObtenerEventosSeguimiento Save(ObtenerEventosSeguimiento obtenerEventosSeguimiento)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSeguimientoSave")) throw new PermisoException();
            if (obtenerEventosSeguimiento. == -1) return Insert(obtenerEventosSeguimiento);
            else return Update(obtenerEventosSeguimiento);
        }

        public static ObtenerEventosSeguimiento Insert(ObtenerEventosSeguimiento obtenerEventosSeguimiento)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSeguimientoSave")) throw new PermisoException();
            string sql = "insert into ObtenerEventosSeguimiento(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerEventosSeguimiento, null));
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
            obtenerEventosSeguimiento. = Convert.ToInt32(resp);
            return obtenerEventosSeguimiento;
        }

        public static ObtenerEventosSeguimiento Update(ObtenerEventosSeguimiento obtenerEventosSeguimiento)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerEventosSeguimientoSave")) throw new PermisoException();
            string sql = "update ObtenerEventosSeguimiento set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerEventosSeguimiento).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerEventosSeguimiento, null));
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
            sql += " where  = " + obtenerEventosSeguimiento.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerEventosSeguimiento;
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
