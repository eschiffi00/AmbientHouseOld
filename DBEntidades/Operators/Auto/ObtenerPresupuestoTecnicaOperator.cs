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
    public partial class ObtenerPresupuestoTecnicaOperator
    {

        public static ObtenerPresupuestoTecnica GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoTecnicaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoTecnica where  = " + .ToString()).Tables[0];
            ObtenerPresupuestoTecnica obtenerPresupuestoTecnica = new ObtenerPresupuestoTecnica();
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerPresupuestoTecnica, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerPresupuestoTecnica;
        }

        public static List<ObtenerPresupuestoTecnica> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoTecnicaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerPresupuestoTecnica> lista = new List<ObtenerPresupuestoTecnica>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoTecnica").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerPresupuestoTecnica obtenerPresupuestoTecnica = new ObtenerPresupuestoTecnica();
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerPresupuestoTecnica, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerPresupuestoTecnica);
            }
            return lista;
        }
        public static ObtenerPresupuestoTecnica GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoTecnicaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoTecnica where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerPresupuestoTecnica ObtenerPresupuestoTecnica = new ObtenerPresupuestoTecnica();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerPresupuestoTecnica, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerPresupuestoTecnica;
        }
        public static List<ObtenerPresupuestoTecnica> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoTecnicaBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerPresupuestoTecnica where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerPresupuestoTecnica where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerPresupuestoTecnica> lista = new List<ObtenerPresupuestoTecnica>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerPresupuestoTecnica entidad = new ObtenerPresupuestoTecnica();
                    foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties())
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
			public static int Canal { get; set; } = 50;
			public static int TipoServicio { get; set; } = 50;
			public static int RazonSocial { get; set; } = 50;


        }

        public static ObtenerPresupuestoTecnica Save(ObtenerPresupuestoTecnica obtenerPresupuestoTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoTecnicaSave")) throw new PermisoException();
            if (obtenerPresupuestoTecnica. == -1) return Insert(obtenerPresupuestoTecnica);
            else return Update(obtenerPresupuestoTecnica);
        }

        public static ObtenerPresupuestoTecnica Insert(ObtenerPresupuestoTecnica obtenerPresupuestoTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoTecnicaSave")) throw new PermisoException();
            string sql = "insert into ObtenerPresupuestoTecnica(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoTecnica, null));
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
            obtenerPresupuestoTecnica. = Convert.ToInt32(resp);
            return obtenerPresupuestoTecnica;
        }

        public static ObtenerPresupuestoTecnica Update(ObtenerPresupuestoTecnica obtenerPresupuestoTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoTecnicaSave")) throw new PermisoException();
            string sql = "update ObtenerPresupuestoTecnica set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoTecnica).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoTecnica, null));
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
            sql += " where  = " + obtenerPresupuestoTecnica.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerPresupuestoTecnica;
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
