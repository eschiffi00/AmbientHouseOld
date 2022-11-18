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
    public partial class ReporteEventosPorUnidadesdeNegociosOperator
    {

        public static ReporteEventosPorUnidadesdeNegocios GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosPorUnidadesdeNegociosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteEventosPorUnidadesdeNegocios where  = " + .ToString()).Tables[0];
            ReporteEventosPorUnidadesdeNegocios reporteEventosPorUnidadesdeNegocios = new ReporteEventosPorUnidadesdeNegocios();
            foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(reporteEventosPorUnidadesdeNegocios, value, null); }
                catch (System.ArgumentException) { }
            }
            return reporteEventosPorUnidadesdeNegocios;
        }

        public static List<ReporteEventosPorUnidadesdeNegocios> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosPorUnidadesdeNegociosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ReporteEventosPorUnidadesdeNegocios> lista = new List<ReporteEventosPorUnidadesdeNegocios>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteEventosPorUnidadesdeNegocios").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ReporteEventosPorUnidadesdeNegocios reporteEventosPorUnidadesdeNegocios = new ReporteEventosPorUnidadesdeNegocios();
                foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(reporteEventosPorUnidadesdeNegocios, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(reporteEventosPorUnidadesdeNegocios);
            }
            return lista;
        }
        public static ReporteEventosPorUnidadesdeNegocios GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosPorUnidadesdeNegociosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ReporteEventosPorUnidadesdeNegocios where  " + campo + " = \'" + valor + "\'").Tables[0];
            ReporteEventosPorUnidadesdeNegocios ReporteEventosPorUnidadesdeNegocios = new ReporteEventosPorUnidadesdeNegocios();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ReporteEventosPorUnidadesdeNegocios, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ReporteEventosPorUnidadesdeNegocios;
        }
        public static List<ReporteEventosPorUnidadesdeNegocios> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosPorUnidadesdeNegociosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties())
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
                    queryStr = "select " + columnas + " from ReporteEventosPorUnidadesdeNegocios where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ReporteEventosPorUnidadesdeNegocios where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ReporteEventosPorUnidadesdeNegocios> lista = new List<ReporteEventosPorUnidadesdeNegocios>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ReporteEventosPorUnidadesdeNegocios entidad = new ReporteEventosPorUnidadesdeNegocios();
                    foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties())
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
			public static int ApellidoNombre { get; set; } = 100;
			public static int RazonSocial { get; set; } = 200;
			public static int Mail { get; set; } = 100;
			public static int Celular { get; set; } = 50;
			public static int ComoLlego { get; set; } = 50;
			public static int CARACTERISTICA { get; set; } = 50;
			public static int Segmento { get; set; } = 50;
			public static int LOCACION { get; set; } = 50;
			public static int SECTOR { get; set; } = 50;
			public static int JORNADA { get; set; } = 50;
			public static int HorarioEvento { get; set; } = 50;
			public static int Estado { get; set; } = 50;
			public static int Ejecutivo { get; set; } = 50;
			public static int EstadoPresupuesto { get; set; } = 50;
			public static int ValorVendidoSalon { get; set; } = 7;
			public static int ValorVendidoCatering { get; set; } = 7;
			public static int TipoCatering { get; set; } = 50;
			public static int ValorVendidoTecnica { get; set; } = 7;
			public static int TipoTecnica { get; set; } = 50;
			public static int ValorVendidoBarra { get; set; } = 7;
			public static int TipoBarra { get; set; } = 50;
			public static int ValorVendidoAmbientacion { get; set; } = 7;
			public static int ValorVendidoAudiovisual { get; set; } = 7;
			public static int ValorVendidoArtistica { get; set; } = 7;


        }

        public static ReporteEventosPorUnidadesdeNegocios Save(ReporteEventosPorUnidadesdeNegocios reporteEventosPorUnidadesdeNegocios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosPorUnidadesdeNegociosSave")) throw new PermisoException();
            if (reporteEventosPorUnidadesdeNegocios. == -1) return Insert(reporteEventosPorUnidadesdeNegocios);
            else return Update(reporteEventosPorUnidadesdeNegocios);
        }

        public static ReporteEventosPorUnidadesdeNegocios Insert(ReporteEventosPorUnidadesdeNegocios reporteEventosPorUnidadesdeNegocios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosPorUnidadesdeNegociosSave")) throw new PermisoException();
            string sql = "insert into ReporteEventosPorUnidadesdeNegocios(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(reporteEventosPorUnidadesdeNegocios, null));
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
            reporteEventosPorUnidadesdeNegocios. = Convert.ToInt32(resp);
            return reporteEventosPorUnidadesdeNegocios;
        }

        public static ReporteEventosPorUnidadesdeNegocios Update(ReporteEventosPorUnidadesdeNegocios reporteEventosPorUnidadesdeNegocios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoReporteEventosPorUnidadesdeNegociosSave")) throw new PermisoException();
            string sql = "update ReporteEventosPorUnidadesdeNegocios set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ReporteEventosPorUnidadesdeNegocios).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(reporteEventosPorUnidadesdeNegocios, null));
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
            sql += " where  = " + reporteEventosPorUnidadesdeNegocios.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return reporteEventosPorUnidadesdeNegocios;
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
