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
    public partial class EVENTOSTODOSOperator
    {

        public static EVENTOSTODOS GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEVENTOSTODOSBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from EVENTOSTODOS where  = " + .ToString()).Tables[0];
            EVENTOSTODOS eVENTOSTODOS = new EVENTOSTODOS();
            foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(eVENTOSTODOS, value, null); }
                catch (System.ArgumentException) { }
            }
            return eVENTOSTODOS;
        }

        public static List<EVENTOSTODOS> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEVENTOSTODOSBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<EVENTOSTODOS> lista = new List<EVENTOSTODOS>();
            DataTable dt = db.GetDataSet("select " + columnas + " from EVENTOSTODOS").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                EVENTOSTODOS eVENTOSTODOS = new EVENTOSTODOS();
                foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(eVENTOSTODOS, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(eVENTOSTODOS);
            }
            return lista;
        }
        public static EVENTOSTODOS GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEVENTOSTODOSBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from EVENTOSTODOS where  " + campo + " = \'" + valor + "\'").Tables[0];
            EVENTOSTODOS EVENTOSTODOS = new EVENTOSTODOS();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(EVENTOSTODOS, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return EVENTOSTODOS;
        }
        public static List<EVENTOSTODOS> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoEVENTOSTODOSBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties())
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
                    queryStr = "select " + columnas + " from EVENTOSTODOS where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from EVENTOSTODOS where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<EVENTOSTODOS> lista = new List<EVENTOSTODOS>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    EVENTOSTODOS entidad = new EVENTOSTODOS();
                    foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties())
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
			public static int ApellidoNombre { get; set; } = 200;
			public static int RazonSocial { get; set; } = 200;
			public static int LOCACION { get; set; } = 50;
			public static int Ejecutivo { get; set; } = 50;
			public static int TipoEventos { get; set; } = 50;
			public static int Estado { get; set; } = 50;


        }

        public static EVENTOSTODOS Save(EVENTOSTODOS eVENTOSTODOS)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEVENTOSTODOSSave")) throw new PermisoException();
            if (eVENTOSTODOS. == -1) return Insert(eVENTOSTODOS);
            else return Update(eVENTOSTODOS);
        }

        public static EVENTOSTODOS Insert(EVENTOSTODOS eVENTOSTODOS)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEVENTOSTODOSSave")) throw new PermisoException();
            string sql = "insert into EVENTOSTODOS(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(eVENTOSTODOS, null));
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
            eVENTOSTODOS. = Convert.ToInt32(resp);
            return eVENTOSTODOS;
        }

        public static EVENTOSTODOS Update(EVENTOSTODOS eVENTOSTODOS)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEVENTOSTODOSSave")) throw new PermisoException();
            string sql = "update EVENTOSTODOS set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EVENTOSTODOS).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(eVENTOSTODOS, null));
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
            sql += " where  = " + eVENTOSTODOS.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return eVENTOSTODOS;
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
