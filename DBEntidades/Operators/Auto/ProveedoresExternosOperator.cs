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
    public partial class ProveedoresExternosOperator
    {

        public static ProveedoresExternos GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresExternosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresExternos where  = " + .ToString()).Tables[0];
            ProveedoresExternos proveedoresExternos = new ProveedoresExternos();
            foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(proveedoresExternos, value, null); }
                catch (System.ArgumentException) { }
            }
            return proveedoresExternos;
        }

        public static List<ProveedoresExternos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresExternosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ProveedoresExternos> lista = new List<ProveedoresExternos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresExternos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ProveedoresExternos proveedoresExternos = new ProveedoresExternos();
                foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(proveedoresExternos, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(proveedoresExternos);
            }
            return lista;
        }
        public static ProveedoresExternos GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresExternosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresExternos where  " + campo + " = \'" + valor + "\'").Tables[0];
            ProveedoresExternos ProveedoresExternos = new ProveedoresExternos();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ProveedoresExternos, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ProveedoresExternos;
        }
        public static List<ProveedoresExternos> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresExternosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties())
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
                    queryStr = "select " + columnas + " from ProveedoresExternos where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ProveedoresExternos where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ProveedoresExternos> lista = new List<ProveedoresExternos>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ProveedoresExternos entidad = new ProveedoresExternos();
                    foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties())
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
			public static int Ejecutivo { get; set; } = 50;
			public static int Locacion { get; set; } = 50;
			public static int Proveedor { get; set; } = 8000;
			public static int Rubro { get; set; } = 200;
			public static int Contacto { get; set; } = 200;
			public static int Telefono { get; set; } = 200;
			public static int Correo { get; set; } = 200;


        }

        public static ProveedoresExternos Save(ProveedoresExternos proveedoresExternos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresExternosSave")) throw new PermisoException();
            if (proveedoresExternos. == -1) return Insert(proveedoresExternos);
            else return Update(proveedoresExternos);
        }

        public static ProveedoresExternos Insert(ProveedoresExternos proveedoresExternos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresExternosSave")) throw new PermisoException();
            string sql = "insert into ProveedoresExternos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(proveedoresExternos, null));
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
            proveedoresExternos. = Convert.ToInt32(resp);
            return proveedoresExternos;
        }

        public static ProveedoresExternos Update(ProveedoresExternos proveedoresExternos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresExternosSave")) throw new PermisoException();
            string sql = "update ProveedoresExternos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ProveedoresExternos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(proveedoresExternos, null));
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
            sql += " where  = " + proveedoresExternos.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return proveedoresExternos;
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
