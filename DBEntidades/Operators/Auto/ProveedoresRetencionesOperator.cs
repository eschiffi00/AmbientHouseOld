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
    public partial class ProveedoresRetencionesOperator
    {

        public static ProveedoresRetenciones GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresRetencionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresRetenciones where Id = " + Id.ToString()).Tables[0];
            ProveedoresRetenciones proveedoresRetenciones = new ProveedoresRetenciones();
            foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(proveedoresRetenciones, value, null); }
                catch (System.ArgumentException) { }
            }
            return proveedoresRetenciones;
        }

        public static List<ProveedoresRetenciones> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresRetencionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ProveedoresRetenciones> lista = new List<ProveedoresRetenciones>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresRetenciones").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ProveedoresRetenciones proveedoresRetenciones = new ProveedoresRetenciones();
                foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(proveedoresRetenciones, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(proveedoresRetenciones);
            }
            return lista;
        }
        public static ProveedoresRetenciones GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresRetencionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ProveedoresRetenciones where  " + campo + " = \'" + valor + "\'").Tables[0];
            ProveedoresRetenciones ProveedoresRetenciones = new ProveedoresRetenciones();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ProveedoresRetenciones, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ProveedoresRetenciones;
        }
        public static List<ProveedoresRetenciones> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresRetencionesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties())
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
                    queryStr = "select " + columnas + " from ProveedoresRetenciones where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ProveedoresRetenciones where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ProveedoresRetenciones> lista = new List<ProveedoresRetenciones>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ProveedoresRetenciones entidad = new ProveedoresRetenciones();
                    foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties())
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


        }

        public static ProveedoresRetenciones Save(ProveedoresRetenciones proveedoresRetenciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresRetencionesSave")) throw new PermisoException();
            if (proveedoresRetenciones.Id == -1) return Insert(proveedoresRetenciones);
            else return Update(proveedoresRetenciones);
        }

        public static ProveedoresRetenciones Insert(ProveedoresRetenciones proveedoresRetenciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresRetencionesSave")) throw new PermisoException();
            string sql = "insert into ProveedoresRetenciones(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(proveedoresRetenciones, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            valores = valores.Substring(0, valores.Length - 2);
            sql += columnas + ") output inserted.Id values (" + valores + ")";
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
            proveedoresRetenciones.Id = Convert.ToInt32(resp);
            return proveedoresRetenciones;
        }

        public static ProveedoresRetenciones Update(ProveedoresRetenciones proveedoresRetenciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedoresRetencionesSave")) throw new PermisoException();
            string sql = "update ProveedoresRetenciones set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ProveedoresRetenciones).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(proveedoresRetenciones, null));
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
            sql += " where Id = " + proveedoresRetenciones.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return proveedoresRetenciones;
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
