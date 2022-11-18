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
    public partial class ReporteAdiocionalesOperator
    {

        public static ReporteAdiocionales GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteAdiocionalesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteAdiocionales where  = " + .ToString()).Tables[0];
            ReporteAdiocionales reporteAdiocionales = new ReporteAdiocionales();
            foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(reporteAdiocionales, value, null); }
                catch (System.ArgumentException) { }
            }
            return reporteAdiocionales;
        }

        public static List<ReporteAdiocionales> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteAdiocionalesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ReporteAdiocionales> lista = new List<ReporteAdiocionales>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteAdiocionales").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ReporteAdiocionales reporteAdiocionales = new ReporteAdiocionales();
                foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(reporteAdiocionales, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(reporteAdiocionales);
            }
            return lista;
        }
        public static ReporteAdiocionales GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteAdiocionalesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteAdiocionales where  " + campo + " = \'" + valor + "\'").Tables[0];
            ReporteAdiocionales ReporteAdiocionales = new ReporteAdiocionales();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ReporteAdiocionales, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ReporteAdiocionales;
        }
        public static List<ReporteAdiocionales> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoReporteAdiocionalesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties())
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
                    queryStr = "select " + columnas + " from ReporteAdiocionales where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ReporteAdiocionales where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ReporteAdiocionales> lista = new List<ReporteAdiocionales>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ReporteAdiocionales entidad = new ReporteAdiocionales();
                    foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties())
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
			public static int FECHAEVENTO { get; set; } = 10;
			public static int Rubro { get; set; } = 50;
			public static int Descripcion { get; set; } = 300;


        }

        public static ReporteAdiocionales Save(ReporteAdiocionales reporteAdiocionales)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteAdiocionalesSave")) throw new PermisoException();
            if (reporteAdiocionales. == -1) return Insert(reporteAdiocionales);
            else return Update(reporteAdiocionales);
        }

        public static ReporteAdiocionales Insert(ReporteAdiocionales reporteAdiocionales)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteAdiocionalesSave")) throw new PermisoException();
            string sql = "insert into ReporteAdiocionales(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(reporteAdiocionales, null));
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
            reporteAdiocionales. = Convert.ToInt32(resp);
            return reporteAdiocionales;
        }

        public static ReporteAdiocionales Update(ReporteAdiocionales reporteAdiocionales)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteAdiocionalesSave")) throw new PermisoException();
            string sql = "update ReporteAdiocionales set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ReporteAdiocionales).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(reporteAdiocionales, null));
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
            sql += " where  = " + reporteAdiocionales.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return reporteAdiocionales;
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
