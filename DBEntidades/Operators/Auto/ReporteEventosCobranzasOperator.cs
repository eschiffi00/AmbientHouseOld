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
    public partial class ReporteEventosCobranzasOperator
    {

        public static ReporteEventosCobranzas GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosCobranzasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteEventosCobranzas where  = " + .ToString()).Tables[0];
            ReporteEventosCobranzas reporteEventosCobranzas = new ReporteEventosCobranzas();
            foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(reporteEventosCobranzas, value, null); }
                catch (System.ArgumentException) { }
            }
            return reporteEventosCobranzas;
        }

        public static List<ReporteEventosCobranzas> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosCobranzasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ReporteEventosCobranzas> lista = new List<ReporteEventosCobranzas>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteEventosCobranzas").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ReporteEventosCobranzas reporteEventosCobranzas = new ReporteEventosCobranzas();
                foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(reporteEventosCobranzas, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(reporteEventosCobranzas);
            }
            return lista;
        }
        public static ReporteEventosCobranzas GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosCobranzasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteEventosCobranzas where  " + campo + " = \'" + valor + "\'").Tables[0];
            ReporteEventosCobranzas ReporteEventosCobranzas = new ReporteEventosCobranzas();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ReporteEventosCobranzas, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ReporteEventosCobranzas;
        }
        public static List<ReporteEventosCobranzas> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosCobranzasBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties())
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
                    queryStr = "select " + columnas + " from ReporteEventosCobranzas where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ReporteEventosCobranzas where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ReporteEventosCobranzas> lista = new List<ReporteEventosCobranzas>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ReporteEventosCobranzas entidad = new ReporteEventosCobranzas();
                    foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties())
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
			public static int Unidad de Negocio { get; set; } = 50;
			public static int UnidadNegocioAdicional { get; set; } = 50;
			public static int PrecioSeleccionado { get; set; } = 50;
			public static int RazonSocial { get; set; } = 200;
			public static int ApellidoNombre { get; set; } = 200;
			public static int Locacion { get; set; } = 50;
			public static int Ejecutivo { get; set; } = 50;


        }

        public static ReporteEventosCobranzas Save(ReporteEventosCobranzas reporteEventosCobranzas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosCobranzasSave")) throw new PermisoException();
            if (reporteEventosCobranzas. == -1) return Insert(reporteEventosCobranzas);
            else return Update(reporteEventosCobranzas);
        }

        public static ReporteEventosCobranzas Insert(ReporteEventosCobranzas reporteEventosCobranzas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosCobranzasSave")) throw new PermisoException();
            string sql = "insert into ReporteEventosCobranzas(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(reporteEventosCobranzas, null));
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
            reporteEventosCobranzas. = Convert.ToInt32(resp);
            return reporteEventosCobranzas;
        }

        public static ReporteEventosCobranzas Update(ReporteEventosCobranzas reporteEventosCobranzas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosCobranzasSave")) throw new PermisoException();
            string sql = "update ReporteEventosCobranzas set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ReporteEventosCobranzas).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(reporteEventosCobranzas, null));
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
            sql += " where  = " + reporteEventosCobranzas.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return reporteEventosCobranzas;
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
