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
    public partial class ResponsablesEventosOperator
    {

        public static ResponsablesEventos GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoResponsablesEventosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ResponsablesEventos where  = " + .ToString()).Tables[0];
            ResponsablesEventos responsablesEventos = new ResponsablesEventos();
            foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(responsablesEventos, value, null); }
                catch (System.ArgumentException) { }
            }
            return responsablesEventos;
        }

        public static List<ResponsablesEventos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoResponsablesEventosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ResponsablesEventos> lista = new List<ResponsablesEventos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ResponsablesEventos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ResponsablesEventos responsablesEventos = new ResponsablesEventos();
                foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(responsablesEventos, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(responsablesEventos);
            }
            return lista;
        }
        public static ResponsablesEventos GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoResponsablesEventosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ResponsablesEventos where  " + campo + " = \'" + valor + "\'").Tables[0];
            ResponsablesEventos ResponsablesEventos = new ResponsablesEventos();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ResponsablesEventos, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ResponsablesEventos;
        }
        public static List<ResponsablesEventos> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoResponsablesEventosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties())
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
                    queryStr = "select " + columnas + " from ResponsablesEventos where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ResponsablesEventos where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ResponsablesEventos> lista = new List<ResponsablesEventos>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ResponsablesEventos entidad = new ResponsablesEventos();
                    foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties())
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
			public static int HorarioEvento { get; set; } = 50;
			public static int HoraFinalizado { get; set; } = 50;
			public static int Caracteristica { get; set; } = 50;
			public static int Segmento { get; set; } = 50;
			public static int RazonSocial { get; set; } = 200;
			public static int ApellidoNombre { get; set; } = 200;
			public static int LOCACION { get; set; } = 50;
			public static int Resp. Cocina { get; set; } = 50;
			public static int Resp. Barra { get; set; } = 50;
			public static int Resp. Logistica { get; set; } = 50;
			public static int Resp. Operaciones { get; set; } = 50;
			public static int Resp. Salon { get; set; } = 50;
			public static int Coordinador 1 { get; set; } = 50;
			public static int Coordinador 2 { get; set; } = 50;
			public static int Organizador { get; set; } = 50;
			public static int Resp. Logistica Armado { get; set; } = 50;
			public static int Resp. Logistica Desarmado { get; set; } = 50;
			public static int HoraIngresoCoordinador1 { get; set; } = 5;
			public static int HoraIngresoCoordinador2 { get; set; } = 5;


        }

        public static ResponsablesEventos Save(ResponsablesEventos responsablesEventos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoResponsablesEventosSave")) throw new PermisoException();
            if (responsablesEventos. == -1) return Insert(responsablesEventos);
            else return Update(responsablesEventos);
        }

        public static ResponsablesEventos Insert(ResponsablesEventos responsablesEventos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoResponsablesEventosSave")) throw new PermisoException();
            string sql = "insert into ResponsablesEventos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(responsablesEventos, null));
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
            responsablesEventos. = Convert.ToInt32(resp);
            return responsablesEventos;
        }

        public static ResponsablesEventos Update(ResponsablesEventos responsablesEventos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoResponsablesEventosSave")) throw new PermisoException();
            string sql = "update ResponsablesEventos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ResponsablesEventos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(responsablesEventos, null));
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
            sql += " where  = " + responsablesEventos.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return responsablesEventos;
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
