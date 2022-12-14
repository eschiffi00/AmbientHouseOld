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
    public partial class INVENTARIO_Movimiento_ProductoOperator
    {

        public static INVENTARIO_Movimiento_Producto GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_Movimiento_ProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Movimiento_Producto where Id = " + Id.ToString()).Tables[0];
            INVENTARIO_Movimiento_Producto iNVENTARIO_Movimiento_Producto = new INVENTARIO_Movimiento_Producto();
            foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(iNVENTARIO_Movimiento_Producto, value, null); }
                catch (System.ArgumentException) { }
            }
            return iNVENTARIO_Movimiento_Producto;
        }

        public static List<INVENTARIO_Movimiento_Producto> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_Movimiento_ProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<INVENTARIO_Movimiento_Producto> lista = new List<INVENTARIO_Movimiento_Producto>();
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Movimiento_Producto").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                INVENTARIO_Movimiento_Producto iNVENTARIO_Movimiento_Producto = new INVENTARIO_Movimiento_Producto();
                foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(iNVENTARIO_Movimiento_Producto, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(iNVENTARIO_Movimiento_Producto);
            }
            return lista;
        }
        public static INVENTARIO_Movimiento_Producto GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_Movimiento_ProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Movimiento_Producto where  " + campo + " = \'" + valor + "\'").Tables[0];
            INVENTARIO_Movimiento_Producto INVENTARIO_Movimiento_Producto = new INVENTARIO_Movimiento_Producto();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(INVENTARIO_Movimiento_Producto, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return INVENTARIO_Movimiento_Producto;
        }
        public static List<INVENTARIO_Movimiento_Producto> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_Movimiento_ProductoBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties())
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
                    queryStr = "select " + columnas + " from INVENTARIO_Movimiento_Producto where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from INVENTARIO_Movimiento_Producto where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<INVENTARIO_Movimiento_Producto> lista = new List<INVENTARIO_Movimiento_Producto>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    INVENTARIO_Movimiento_Producto entidad = new INVENTARIO_Movimiento_Producto();
                    foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties())
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

        public static INVENTARIO_Movimiento_Producto Save(INVENTARIO_Movimiento_Producto iNVENTARIO_Movimiento_Producto)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_Movimiento_ProductoSave")) throw new PermisoException();
            if (iNVENTARIO_Movimiento_Producto.Id == -1) return Insert(iNVENTARIO_Movimiento_Producto);
            else return Update(iNVENTARIO_Movimiento_Producto);
        }

        public static INVENTARIO_Movimiento_Producto Insert(INVENTARIO_Movimiento_Producto iNVENTARIO_Movimiento_Producto)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_Movimiento_ProductoSave")) throw new PermisoException();
            string sql = "insert into INVENTARIO_Movimiento_Producto(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(iNVENTARIO_Movimiento_Producto, null));
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
            iNVENTARIO_Movimiento_Producto.Id = Convert.ToInt32(resp);
            return iNVENTARIO_Movimiento_Producto;
        }

        public static INVENTARIO_Movimiento_Producto Update(INVENTARIO_Movimiento_Producto iNVENTARIO_Movimiento_Producto)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_Movimiento_ProductoSave")) throw new PermisoException();
            string sql = "update INVENTARIO_Movimiento_Producto set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(INVENTARIO_Movimiento_Producto).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(iNVENTARIO_Movimiento_Producto, null));
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
            sql += " where Id = " + iNVENTARIO_Movimiento_Producto.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return iNVENTARIO_Movimiento_Producto;
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
