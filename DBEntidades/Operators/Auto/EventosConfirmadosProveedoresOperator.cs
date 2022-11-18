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
    public partial class EventosConfirmadosProveedoresOperator
    {

        public static EventosConfirmadosProveedores GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosProveedoresBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from EventosConfirmadosProveedores where  = " + .ToString()).Tables[0];
            EventosConfirmadosProveedores eventosConfirmadosProveedores = new EventosConfirmadosProveedores();
            foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(eventosConfirmadosProveedores, value, null); }
                catch (System.ArgumentException) { }
            }
            return eventosConfirmadosProveedores;
        }

        public static List<EventosConfirmadosProveedores> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosProveedoresBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<EventosConfirmadosProveedores> lista = new List<EventosConfirmadosProveedores>();
            DataTable dt = db.GetDataSet("select " + columnas + " from EventosConfirmadosProveedores").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                EventosConfirmadosProveedores eventosConfirmadosProveedores = new EventosConfirmadosProveedores();
                foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(eventosConfirmadosProveedores, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(eventosConfirmadosProveedores);
            }
            return lista;
        }
        public static EventosConfirmadosProveedores GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosProveedoresBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from EventosConfirmadosProveedores where  " + campo + " = \'" + valor + "\'").Tables[0];
            EventosConfirmadosProveedores EventosConfirmadosProveedores = new EventosConfirmadosProveedores();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(EventosConfirmadosProveedores, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return EventosConfirmadosProveedores;
        }
        public static List<EventosConfirmadosProveedores> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosProveedoresBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties())
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
                    queryStr = "select " + columnas + " from EventosConfirmadosProveedores where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from EventosConfirmadosProveedores where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<EventosConfirmadosProveedores> lista = new List<EventosConfirmadosProveedores>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    EventosConfirmadosProveedores entidad = new EventosConfirmadosProveedores();
                    foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties())
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
			public static int RazonSocial { get; set; } = 50;
			public static int Cuit { get; set; } = 50;
			public static int Descripcion { get; set; } = 200;
			public static int CUENTA { get; set; } = 500;


        }

        public static EventosConfirmadosProveedores Save(EventosConfirmadosProveedores eventosConfirmadosProveedores)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosProveedoresSave")) throw new PermisoException();
            if (eventosConfirmadosProveedores. == -1) return Insert(eventosConfirmadosProveedores);
            else return Update(eventosConfirmadosProveedores);
        }

        public static EventosConfirmadosProveedores Insert(EventosConfirmadosProveedores eventosConfirmadosProveedores)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosProveedoresSave")) throw new PermisoException();
            string sql = "insert into EventosConfirmadosProveedores(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(eventosConfirmadosProveedores, null));
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
            eventosConfirmadosProveedores. = Convert.ToInt32(resp);
            return eventosConfirmadosProveedores;
        }

        public static EventosConfirmadosProveedores Update(EventosConfirmadosProveedores eventosConfirmadosProveedores)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEventosConfirmadosProveedoresSave")) throw new PermisoException();
            string sql = "update EventosConfirmadosProveedores set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EventosConfirmadosProveedores).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(eventosConfirmadosProveedores, null));
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
            sql += " where  = " + eventosConfirmadosProveedores.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return eventosConfirmadosProveedores;
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
