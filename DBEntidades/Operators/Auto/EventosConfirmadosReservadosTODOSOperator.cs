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
    public partial class EventosConfirmadosReservadosTODOSOperator
    {

        public static EventosConfirmadosReservadosTODOS GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosReservadosTODOSBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from EventosConfirmadosReservadosTODOS where  = " + .ToString()).Tables[0];
            EventosConfirmadosReservadosTODOS eventosConfirmadosReservadosTODOS = new EventosConfirmadosReservadosTODOS();
            foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(eventosConfirmadosReservadosTODOS, value, null); }
                catch (System.ArgumentException) { }
            }
            return eventosConfirmadosReservadosTODOS;
        }

        public static List<EventosConfirmadosReservadosTODOS> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosReservadosTODOSBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<EventosConfirmadosReservadosTODOS> lista = new List<EventosConfirmadosReservadosTODOS>();
            DataTable dt = db.GetDataSet("select " + columnas + " from EventosConfirmadosReservadosTODOS").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                EventosConfirmadosReservadosTODOS eventosConfirmadosReservadosTODOS = new EventosConfirmadosReservadosTODOS();
                foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(eventosConfirmadosReservadosTODOS, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(eventosConfirmadosReservadosTODOS);
            }
            return lista;
        }
        public static EventosConfirmadosReservadosTODOS GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosReservadosTODOSBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from EventosConfirmadosReservadosTODOS where  " + campo + " = \'" + valor + "\'").Tables[0];
            EventosConfirmadosReservadosTODOS EventosConfirmadosReservadosTODOS = new EventosConfirmadosReservadosTODOS();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(EventosConfirmadosReservadosTODOS, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return EventosConfirmadosReservadosTODOS;
        }
        public static List<EventosConfirmadosReservadosTODOS> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosReservadosTODOSBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties())
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
                    queryStr = "select " + columnas + " from EventosConfirmadosReservadosTODOS where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from EventosConfirmadosReservadosTODOS where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<EventosConfirmadosReservadosTODOS> lista = new List<EventosConfirmadosReservadosTODOS>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    EventosConfirmadosReservadosTODOS entidad = new EventosConfirmadosReservadosTODOS();
                    foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties())
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

		public static List<EventosConfirmadosReservadosTODOS> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<EventosConfirmadosReservadosTODOS> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<EventosConfirmadosReservadosTODOS> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<EventosConfirmadosReservadosTODOS> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int ApellidoNombre { get; set; } = 200;
			public static int RazonSocial { get; set; } = 200;
			public static int CARACTERISTICA { get; set; } = 50;
			public static int LOCACION { get; set; } = 50;
			public static int SECTOR { get; set; } = 200;
			public static int JORNADA { get; set; } = 50;
			public static int TipoEvento { get; set; } = 50;
			public static int Ejecutivo { get; set; } = 100;


        }

        public static EventosConfirmadosReservadosTODOS Save(EventosConfirmadosReservadosTODOS eventosConfirmadosReservadosTODOS)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosReservadosTODOSSave")) throw new PermisoException();
            if (eventosConfirmadosReservadosTODOS. == -1) return Insert(eventosConfirmadosReservadosTODOS);
            else return Update(eventosConfirmadosReservadosTODOS);
        }

        public static EventosConfirmadosReservadosTODOS Insert(EventosConfirmadosReservadosTODOS eventosConfirmadosReservadosTODOS)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosReservadosTODOSSave")) throw new PermisoException();
            string sql = "insert into EventosConfirmadosReservadosTODOS(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(eventosConfirmadosReservadosTODOS, null));
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
            eventosConfirmadosReservadosTODOS. = Convert.ToInt32(resp);
            return eventosConfirmadosReservadosTODOS;
        }

        public static EventosConfirmadosReservadosTODOS Update(EventosConfirmadosReservadosTODOS eventosConfirmadosReservadosTODOS)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosReservadosTODOSSave")) throw new PermisoException();
            string sql = "update EventosConfirmadosReservadosTODOS set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EventosConfirmadosReservadosTODOS).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(eventosConfirmadosReservadosTODOS, null));
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
            sql += " where  = " + eventosConfirmadosReservadosTODOS.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return eventosConfirmadosReservadosTODOS;
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
