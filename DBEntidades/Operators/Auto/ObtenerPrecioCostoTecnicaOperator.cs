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
    public partial class ObtenerPrecioCostoTecnicaOperator
    {

        public static ObtenerPrecioCostoTecnica GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoTecnicaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoTecnica where  = " + .ToString()).Tables[0];
            ObtenerPrecioCostoTecnica obtenerPrecioCostoTecnica = new ObtenerPrecioCostoTecnica();
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerPrecioCostoTecnica, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerPrecioCostoTecnica;
        }

        public static List<ObtenerPrecioCostoTecnica> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoTecnicaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerPrecioCostoTecnica> lista = new List<ObtenerPrecioCostoTecnica>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoTecnica").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerPrecioCostoTecnica obtenerPrecioCostoTecnica = new ObtenerPrecioCostoTecnica();
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerPrecioCostoTecnica, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerPrecioCostoTecnica);
            }
            return lista;
        }
        public static ObtenerPrecioCostoTecnica GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoTecnicaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoTecnica where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerPrecioCostoTecnica ObtenerPrecioCostoTecnica = new ObtenerPrecioCostoTecnica();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerPrecioCostoTecnica, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerPrecioCostoTecnica;
        }
        public static List<ObtenerPrecioCostoTecnica> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoTecnicaBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerPrecioCostoTecnica where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerPrecioCostoTecnica where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerPrecioCostoTecnica> lista = new List<ObtenerPrecioCostoTecnica>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerPrecioCostoTecnica entidad = new ObtenerPrecioCostoTecnica();
                    foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties())
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
			public static int Servicio { get; set; } = 50;
			public static int Segmento { get; set; } = 50;
			public static int RazonSocial { get; set; } = 50;
			public static int Dia { get; set; } = 50;


        }

        public static ObtenerPrecioCostoTecnica Save(ObtenerPrecioCostoTecnica obtenerPrecioCostoTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoTecnicaSave")) throw new PermisoException();
            if (obtenerPrecioCostoTecnica. == -1) return Insert(obtenerPrecioCostoTecnica);
            else return Update(obtenerPrecioCostoTecnica);
        }

        public static ObtenerPrecioCostoTecnica Insert(ObtenerPrecioCostoTecnica obtenerPrecioCostoTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoTecnicaSave")) throw new PermisoException();
            string sql = "insert into ObtenerPrecioCostoTecnica(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPrecioCostoTecnica, null));
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
            obtenerPrecioCostoTecnica. = Convert.ToInt32(resp);
            return obtenerPrecioCostoTecnica;
        }

        public static ObtenerPrecioCostoTecnica Update(ObtenerPrecioCostoTecnica obtenerPrecioCostoTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoTecnicaSave")) throw new PermisoException();
            string sql = "update ObtenerPrecioCostoTecnica set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoTecnica).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPrecioCostoTecnica, null));
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
            sql += " where  = " + obtenerPrecioCostoTecnica.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerPrecioCostoTecnica;
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
