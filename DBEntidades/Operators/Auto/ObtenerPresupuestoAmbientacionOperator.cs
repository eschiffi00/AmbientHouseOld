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
    public partial class ObtenerPresupuestoAmbientacionOperator
    {

        public static ObtenerPresupuestoAmbientacion GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoAmbientacionBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoAmbientacion where  = " + .ToString()).Tables[0];
            ObtenerPresupuestoAmbientacion obtenerPresupuestoAmbientacion = new ObtenerPresupuestoAmbientacion();
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerPresupuestoAmbientacion, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerPresupuestoAmbientacion;
        }

        public static List<ObtenerPresupuestoAmbientacion> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoAmbientacionBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerPresupuestoAmbientacion> lista = new List<ObtenerPresupuestoAmbientacion>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoAmbientacion").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerPresupuestoAmbientacion obtenerPresupuestoAmbientacion = new ObtenerPresupuestoAmbientacion();
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerPresupuestoAmbientacion, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerPresupuestoAmbientacion);
            }
            return lista;
        }
        public static ObtenerPresupuestoAmbientacion GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoAmbientacionBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoAmbientacion where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerPresupuestoAmbientacion ObtenerPresupuestoAmbientacion = new ObtenerPresupuestoAmbientacion();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerPresupuestoAmbientacion, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerPresupuestoAmbientacion;
        }
        public static List<ObtenerPresupuestoAmbientacion> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoAmbientacionBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerPresupuestoAmbientacion where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerPresupuestoAmbientacion where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerPresupuestoAmbientacion> lista = new List<ObtenerPresupuestoAmbientacion>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerPresupuestoAmbientacion entidad = new ObtenerPresupuestoAmbientacion();
                    foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties())
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
			public static int AdjuntoExtension { get; set; } = 50;
			public static int Segmento { get; set; } = 50;
			public static int Caracteristicas { get; set; } = 50;
			public static int Sector { get; set; } = 50;
			public static int Categoria { get; set; } = 50;
			public static int RazonSocial { get; set; } = 50;


        }

        public static ObtenerPresupuestoAmbientacion Save(ObtenerPresupuestoAmbientacion obtenerPresupuestoAmbientacion)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoAmbientacionSave")) throw new PermisoException();
            if (obtenerPresupuestoAmbientacion. == -1) return Insert(obtenerPresupuestoAmbientacion);
            else return Update(obtenerPresupuestoAmbientacion);
        }

        public static ObtenerPresupuestoAmbientacion Insert(ObtenerPresupuestoAmbientacion obtenerPresupuestoAmbientacion)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoAmbientacionSave")) throw new PermisoException();
            string sql = "insert into ObtenerPresupuestoAmbientacion(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoAmbientacion, null));
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
            obtenerPresupuestoAmbientacion. = Convert.ToInt32(resp);
            return obtenerPresupuestoAmbientacion;
        }

        public static ObtenerPresupuestoAmbientacion Update(ObtenerPresupuestoAmbientacion obtenerPresupuestoAmbientacion)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoAmbientacionSave")) throw new PermisoException();
            string sql = "update ObtenerPresupuestoAmbientacion set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoAmbientacion).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoAmbientacion, null));
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
            sql += " where  = " + obtenerPresupuestoAmbientacion.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerPresupuestoAmbientacion;
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
