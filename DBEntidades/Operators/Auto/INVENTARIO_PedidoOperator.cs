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
    public partial class INVENTARIO_PedidoOperator
    {

        public static INVENTARIO_Pedido GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_PedidoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Pedido where Id = " + Id.ToString()).Tables[0];
            INVENTARIO_Pedido iNVENTARIO_Pedido = new INVENTARIO_Pedido();
            foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(iNVENTARIO_Pedido, value, null); }
                catch (System.ArgumentException) { }
            }
            return iNVENTARIO_Pedido;
        }

        public static List<INVENTARIO_Pedido> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_PedidoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<INVENTARIO_Pedido> lista = new List<INVENTARIO_Pedido>();
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Pedido").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                INVENTARIO_Pedido iNVENTARIO_Pedido = new INVENTARIO_Pedido();
                foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(iNVENTARIO_Pedido, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(iNVENTARIO_Pedido);
            }
            return lista;
        }
        public static INVENTARIO_Pedido GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_PedidoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Pedido where  " + campo + " = \'" + valor + "\'").Tables[0];
            INVENTARIO_Pedido INVENTARIO_Pedido = new INVENTARIO_Pedido();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(INVENTARIO_Pedido, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return INVENTARIO_Pedido;
        }
        public static List<INVENTARIO_Pedido> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_PedidoBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties())
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
                    queryStr = "select " + columnas + " from INVENTARIO_Pedido where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from INVENTARIO_Pedido where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<INVENTARIO_Pedido> lista = new List<INVENTARIO_Pedido>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    INVENTARIO_Pedido entidad = new INVENTARIO_Pedido();
                    foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties())
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

		public static List<INVENTARIO_Pedido> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<INVENTARIO_Pedido> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<INVENTARIO_Pedido> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<INVENTARIO_Pedido> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {


        }

        public static INVENTARIO_Pedido Save(INVENTARIO_Pedido iNVENTARIO_Pedido)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_PedidoSave")) throw new PermisoException();
            if (iNVENTARIO_Pedido.Id == -1) return Insert(iNVENTARIO_Pedido);
            else return Update(iNVENTARIO_Pedido);
        }

        public static INVENTARIO_Pedido Insert(INVENTARIO_Pedido iNVENTARIO_Pedido)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_PedidoSave")) throw new PermisoException();
            string sql = "insert into INVENTARIO_Pedido(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(iNVENTARIO_Pedido, null));
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
            iNVENTARIO_Pedido.Id = Convert.ToInt32(resp);
            return iNVENTARIO_Pedido;
        }

        public static INVENTARIO_Pedido Update(INVENTARIO_Pedido iNVENTARIO_Pedido)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_PedidoSave")) throw new PermisoException();
            string sql = "update INVENTARIO_Pedido set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(INVENTARIO_Pedido).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(iNVENTARIO_Pedido, null));
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
            sql += " where Id = " + iNVENTARIO_Pedido.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return iNVENTARIO_Pedido;
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
