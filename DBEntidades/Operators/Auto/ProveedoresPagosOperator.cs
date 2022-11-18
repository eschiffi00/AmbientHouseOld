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
    public partial class ProveedoresPagosOperator
    {

        public static ProveedoresPagos GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresPagosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresPagos where  = " + .ToString()).Tables[0];
            ProveedoresPagos proveedoresPagos = new ProveedoresPagos();
            foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(proveedoresPagos, value, null); }
                catch (System.ArgumentException) { }
            }
            return proveedoresPagos;
        }

        public static List<ProveedoresPagos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresPagosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ProveedoresPagos> lista = new List<ProveedoresPagos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresPagos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ProveedoresPagos proveedoresPagos = new ProveedoresPagos();
                foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(proveedoresPagos, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(proveedoresPagos);
            }
            return lista;
        }
        public static ProveedoresPagos GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresPagosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresPagos where  " + campo + " = \'" + valor + "\'").Tables[0];
            ProveedoresPagos ProveedoresPagos = new ProveedoresPagos();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ProveedoresPagos, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ProveedoresPagos;
        }
        public static List<ProveedoresPagos> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresPagosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties())
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
                    queryStr = "select " + columnas + " from ProveedoresPagos where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ProveedoresPagos where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ProveedoresPagos> lista = new List<ProveedoresPagos>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ProveedoresPagos entidad = new ProveedoresPagos();
                    foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties())
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
			public static int TipoComprobante { get; set; } = 500;
			public static int CuentaContable { get; set; } = 500;
			public static int UnidadNegocio { get; set; } = 50;
			public static int Cuit { get; set; } = 50;
			public static int Proveedor { get; set; } = 50;
			public static int FormaPago { get; set; } = 100;


        }

        public static ProveedoresPagos Save(ProveedoresPagos proveedoresPagos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresPagosSave")) throw new PermisoException();
            if (proveedoresPagos. == -1) return Insert(proveedoresPagos);
            else return Update(proveedoresPagos);
        }

        public static ProveedoresPagos Insert(ProveedoresPagos proveedoresPagos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresPagosSave")) throw new PermisoException();
            string sql = "insert into ProveedoresPagos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(proveedoresPagos, null));
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
            proveedoresPagos. = Convert.ToInt32(resp);
            return proveedoresPagos;
        }

        public static ProveedoresPagos Update(ProveedoresPagos proveedoresPagos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresPagosSave")) throw new PermisoException();
            string sql = "update ProveedoresPagos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ProveedoresPagos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(proveedoresPagos, null));
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
            sql += " where  = " + proveedoresPagos.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return proveedoresPagos;
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
