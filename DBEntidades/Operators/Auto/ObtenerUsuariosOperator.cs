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
    public partial class ObtenerUsuariosOperator
    {

        public static ObtenerUsuarios GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerUsuariosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerUsuarios where  = " + .ToString()).Tables[0];
            ObtenerUsuarios obtenerUsuarios = new ObtenerUsuarios();
            foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerUsuarios, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerUsuarios;
        }

        public static List<ObtenerUsuarios> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerUsuariosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerUsuarios> lista = new List<ObtenerUsuarios>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerUsuarios").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerUsuarios obtenerUsuarios = new ObtenerUsuarios();
                foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerUsuarios, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerUsuarios);
            }
            return lista;
        }
        public static ObtenerUsuarios GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerUsuariosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerUsuarios where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerUsuarios ObtenerUsuarios = new ObtenerUsuarios();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerUsuarios, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerUsuarios;
        }
        public static List<ObtenerUsuarios> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerUsuariosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerUsuarios where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerUsuarios where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerUsuarios> lista = new List<ObtenerUsuarios>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerUsuarios entidad = new ObtenerUsuarios();
                    foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties())
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

		public static List<ObtenerUsuarios> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<ObtenerUsuarios> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<ObtenerUsuarios> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<ObtenerUsuarios> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int ApellidoNombre { get; set; } = 50;
			public static int UserName { get; set; } = 50;
			public static int Mail { get; set; } = 100;
			public static int Nombre { get; set; } = 50;
			public static int Descripcion { get; set; } = 50;


        }

        public static ObtenerUsuarios Save(ObtenerUsuarios obtenerUsuarios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerUsuariosSave")) throw new PermisoException();
            if (obtenerUsuarios. == -1) return Insert(obtenerUsuarios);
            else return Update(obtenerUsuarios);
        }

        public static ObtenerUsuarios Insert(ObtenerUsuarios obtenerUsuarios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerUsuariosSave")) throw new PermisoException();
            string sql = "insert into ObtenerUsuarios(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerUsuarios, null));
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
            obtenerUsuarios. = Convert.ToInt32(resp);
            return obtenerUsuarios;
        }

        public static ObtenerUsuarios Update(ObtenerUsuarios obtenerUsuarios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerUsuariosSave")) throw new PermisoException();
            string sql = "update ObtenerUsuarios set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerUsuarios).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerUsuarios, null));
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
            sql += " where  = " + obtenerUsuarios.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerUsuarios;
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
