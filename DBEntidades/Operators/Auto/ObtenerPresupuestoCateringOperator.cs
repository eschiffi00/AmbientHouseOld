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
    public partial class ObtenerPresupuestoCateringOperator
    {

        public static ObtenerPresupuestoCatering GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoCatering where  = " + .ToString()).Tables[0];
            ObtenerPresupuestoCatering obtenerPresupuestoCatering = new ObtenerPresupuestoCatering();
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerPresupuestoCatering, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerPresupuestoCatering;
        }

        public static List<ObtenerPresupuestoCatering> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerPresupuestoCatering> lista = new List<ObtenerPresupuestoCatering>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoCatering").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerPresupuestoCatering obtenerPresupuestoCatering = new ObtenerPresupuestoCatering();
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerPresupuestoCatering, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerPresupuestoCatering);
            }
            return lista;
        }
        public static ObtenerPresupuestoCatering GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoCatering where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerPresupuestoCatering ObtenerPresupuestoCatering = new ObtenerPresupuestoCatering();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerPresupuestoCatering, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerPresupuestoCatering;
        }
        public static List<ObtenerPresupuestoCatering> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoCateringBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerPresupuestoCatering where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerPresupuestoCatering where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerPresupuestoCatering> lista = new List<ObtenerPresupuestoCatering>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerPresupuestoCatering entidad = new ObtenerPresupuestoCatering();
                    foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties())
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
			public static int Descripcion { get; set; } = 50;
			public static int RazonSocial { get; set; } = 50;


        }

        public static ObtenerPresupuestoCatering Save(ObtenerPresupuestoCatering obtenerPresupuestoCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoCateringSave")) throw new PermisoException();
            if (obtenerPresupuestoCatering. == -1) return Insert(obtenerPresupuestoCatering);
            else return Update(obtenerPresupuestoCatering);
        }

        public static ObtenerPresupuestoCatering Insert(ObtenerPresupuestoCatering obtenerPresupuestoCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoCateringSave")) throw new PermisoException();
            string sql = "insert into ObtenerPresupuestoCatering(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoCatering, null));
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
            obtenerPresupuestoCatering. = Convert.ToInt32(resp);
            return obtenerPresupuestoCatering;
        }

        public static ObtenerPresupuestoCatering Update(ObtenerPresupuestoCatering obtenerPresupuestoCatering)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoCateringSave")) throw new PermisoException();
            string sql = "update ObtenerPresupuestoCatering set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoCatering).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoCatering, null));
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
            sql += " where  = " + obtenerPresupuestoCatering.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerPresupuestoCatering;
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
