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
    public partial class ReporteComprobantesOperator
    {

        public static ReporteComprobantes GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteComprobantesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteComprobantes where  = " + .ToString()).Tables[0];
            ReporteComprobantes reporteComprobantes = new ReporteComprobantes();
            foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(reporteComprobantes, value, null); }
                catch (System.ArgumentException) { }
            }
            return reporteComprobantes;
        }

        public static List<ReporteComprobantes> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteComprobantesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ReporteComprobantes> lista = new List<ReporteComprobantes>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteComprobantes").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ReporteComprobantes reporteComprobantes = new ReporteComprobantes();
                foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(reporteComprobantes, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(reporteComprobantes);
            }
            return lista;
        }
        public static ReporteComprobantes GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteComprobantesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteComprobantes where  " + campo + " = \'" + valor + "\'").Tables[0];
            ReporteComprobantes ReporteComprobantes = new ReporteComprobantes();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ReporteComprobantes, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ReporteComprobantes;
        }
        public static List<ReporteComprobantes> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoReporteComprobantesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties())
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
                    queryStr = "select " + columnas + " from ReporteComprobantes where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ReporteComprobantes where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ReporteComprobantes> lista = new List<ReporteComprobantes>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ReporteComprobantes entidad = new ReporteComprobantes();
                    foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties())
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
			public static int Descripcion { get; set; } = 500;
			public static int RazonSocial { get; set; } = 50;
			public static int Cuenta { get; set; } = 551;
			public static int TipoImpuesto { get; set; } = 100;
			public static int FormadePago { get; set; } = 100;
			public static int CC { get; set; } = 300;
			public static int Leyenda { get; set; } = 200;
			public static int Codigo { get; set; } = 50;


        }

        public static ReporteComprobantes Save(ReporteComprobantes reporteComprobantes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteComprobantesSave")) throw new PermisoException();
            if (reporteComprobantes. == -1) return Insert(reporteComprobantes);
            else return Update(reporteComprobantes);
        }

        public static ReporteComprobantes Insert(ReporteComprobantes reporteComprobantes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteComprobantesSave")) throw new PermisoException();
            string sql = "insert into ReporteComprobantes(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(reporteComprobantes, null));
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
            reporteComprobantes. = Convert.ToInt32(resp);
            return reporteComprobantes;
        }

        public static ReporteComprobantes Update(ReporteComprobantes reporteComprobantes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteComprobantesSave")) throw new PermisoException();
            string sql = "update ReporteComprobantes set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ReporteComprobantes).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(reporteComprobantes, null));
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
            sql += " where  = " + reporteComprobantes.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return reporteComprobantes;
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
