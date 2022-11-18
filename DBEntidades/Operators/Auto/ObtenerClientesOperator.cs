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
    public partial class ObtenerClientesOperator
    {

        public static ObtenerClientes GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerClientesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerClientes where  = " + .ToString()).Tables[0];
            ObtenerClientes obtenerClientes = new ObtenerClientes();
            foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerClientes, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerClientes;
        }

        public static List<ObtenerClientes> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerClientesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerClientes> lista = new List<ObtenerClientes>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerClientes").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerClientes obtenerClientes = new ObtenerClientes();
                foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerClientes, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerClientes);
            }
            return lista;
        }
        public static ObtenerClientes GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerClientesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerClientes where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerClientes ObtenerClientes = new ObtenerClientes();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerClientes, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerClientes;
        }
        public static List<ObtenerClientes> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerClientesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerClientes where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerClientes where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerClientes> lista = new List<ObtenerClientes>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerClientes entidad = new ObtenerClientes();
                    foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties())
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
			public static int Mail { get; set; } = 100;
			public static int Telefono { get; set; } = 50;
			public static int Celular { get; set; } = 50;
			public static int ComoLlegoOtro { get; set; } = 50;
			public static int Comentario { get; set; } = 3000;
			public static int RazonSocial { get; set; } = 200;
			public static int TipoCliente { get; set; } = 1;
			public static int Ejecutivo { get; set; } = 50;


        }

        public static ObtenerClientes Save(ObtenerClientes obtenerClientes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerClientesSave")) throw new PermisoException();
            if (obtenerClientes. == -1) return Insert(obtenerClientes);
            else return Update(obtenerClientes);
        }

        public static ObtenerClientes Insert(ObtenerClientes obtenerClientes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerClientesSave")) throw new PermisoException();
            string sql = "insert into ObtenerClientes(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerClientes, null));
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
            obtenerClientes. = Convert.ToInt32(resp);
            return obtenerClientes;
        }

        public static ObtenerClientes Update(ObtenerClientes obtenerClientes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerClientesSave")) throw new PermisoException();
            string sql = "update ObtenerClientes set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerClientes).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerClientes, null));
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
            sql += " where  = " + obtenerClientes.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerClientes;
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
