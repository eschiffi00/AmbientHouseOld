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
    public partial class ObtenerPresupuestoArtisticaOperator
    {

        public static ObtenerPresupuestoArtistica GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoArtisticaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoArtistica where  = " + .ToString()).Tables[0];
            ObtenerPresupuestoArtistica obtenerPresupuestoArtistica = new ObtenerPresupuestoArtistica();
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerPresupuestoArtistica, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerPresupuestoArtistica;
        }

        public static List<ObtenerPresupuestoArtistica> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoArtisticaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerPresupuestoArtistica> lista = new List<ObtenerPresupuestoArtistica>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoArtistica").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerPresupuestoArtistica obtenerPresupuestoArtistica = new ObtenerPresupuestoArtistica();
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerPresupuestoArtistica, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerPresupuestoArtistica);
            }
            return lista;
        }
        public static ObtenerPresupuestoArtistica GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoArtisticaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoArtistica where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerPresupuestoArtistica ObtenerPresupuestoArtistica = new ObtenerPresupuestoArtistica();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerPresupuestoArtistica, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerPresupuestoArtistica;
        }
        public static List<ObtenerPresupuestoArtistica> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoArtisticaBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerPresupuestoArtistica where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerPresupuestoArtistica where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerPresupuestoArtistica> lista = new List<ObtenerPresupuestoArtistica>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerPresupuestoArtistica entidad = new ObtenerPresupuestoArtistica();
                    foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties())
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
			public static int RazonSocial { get; set; } = 50;


        }

        public static ObtenerPresupuestoArtistica Save(ObtenerPresupuestoArtistica obtenerPresupuestoArtistica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoArtisticaSave")) throw new PermisoException();
            if (obtenerPresupuestoArtistica. == -1) return Insert(obtenerPresupuestoArtistica);
            else return Update(obtenerPresupuestoArtistica);
        }

        public static ObtenerPresupuestoArtistica Insert(ObtenerPresupuestoArtistica obtenerPresupuestoArtistica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoArtisticaSave")) throw new PermisoException();
            string sql = "insert into ObtenerPresupuestoArtistica(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoArtistica, null));
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
            obtenerPresupuestoArtistica. = Convert.ToInt32(resp);
            return obtenerPresupuestoArtistica;
        }

        public static ObtenerPresupuestoArtistica Update(ObtenerPresupuestoArtistica obtenerPresupuestoArtistica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoArtisticaSave")) throw new PermisoException();
            string sql = "update ObtenerPresupuestoArtistica set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoArtistica).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoArtistica, null));
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
            sql += " where  = " + obtenerPresupuestoArtistica.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerPresupuestoArtistica;
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
