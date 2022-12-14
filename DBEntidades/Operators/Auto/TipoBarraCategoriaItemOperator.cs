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
    public partial class TipoBarraCategoriaItemOperator
    {

        public static TipoBarraCategoriaItem GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoBarraCategoriaItemBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoBarraCategoriaItem where Id = " + Id.ToString()).Tables[0];
            TipoBarraCategoriaItem tipoBarraCategoriaItem = new TipoBarraCategoriaItem();
            foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(tipoBarraCategoriaItem, value, null); }
                catch (System.ArgumentException) { }
            }
            return tipoBarraCategoriaItem;
        }

        public static List<TipoBarraCategoriaItem> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoBarraCategoriaItemBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TipoBarraCategoriaItem> lista = new List<TipoBarraCategoriaItem>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoBarraCategoriaItem").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TipoBarraCategoriaItem tipoBarraCategoriaItem = new TipoBarraCategoriaItem();
                foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(tipoBarraCategoriaItem, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(tipoBarraCategoriaItem);
            }
            return lista;
        }
        public static TipoBarraCategoriaItem GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoBarraCategoriaItemBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoBarraCategoriaItem where  " + campo + " = \'" + valor + "\'").Tables[0];
            TipoBarraCategoriaItem TipoBarraCategoriaItem = new TipoBarraCategoriaItem();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(TipoBarraCategoriaItem, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return TipoBarraCategoriaItem;
        }
        public static List<TipoBarraCategoriaItem> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoTipoBarraCategoriaItemBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties())
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
                    queryStr = "select " + columnas + " from TipoBarraCategoriaItem where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from TipoBarraCategoriaItem where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<TipoBarraCategoriaItem> lista = new List<TipoBarraCategoriaItem>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    TipoBarraCategoriaItem entidad = new TipoBarraCategoriaItem();
                    foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties())
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

		public static List<TipoBarraCategoriaItem> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<TipoBarraCategoriaItem> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<TipoBarraCategoriaItem> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<TipoBarraCategoriaItem> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {


        }

        public static TipoBarraCategoriaItem Save(TipoBarraCategoriaItem tipoBarraCategoriaItem)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoBarraCategoriaItemSave")) throw new PermisoException();
            if (tipoBarraCategoriaItem.Id == -1) return Insert(tipoBarraCategoriaItem);
            else return Update(tipoBarraCategoriaItem);
        }

        public static TipoBarraCategoriaItem Insert(TipoBarraCategoriaItem tipoBarraCategoriaItem)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoBarraCategoriaItemSave")) throw new PermisoException();
            string sql = "insert into TipoBarraCategoriaItem(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoBarraCategoriaItem, null));
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
            tipoBarraCategoriaItem.Id = Convert.ToInt32(resp);
            return tipoBarraCategoriaItem;
        }

        public static TipoBarraCategoriaItem Update(TipoBarraCategoriaItem tipoBarraCategoriaItem)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoBarraCategoriaItemSave")) throw new PermisoException();
            string sql = "update TipoBarraCategoriaItem set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoBarraCategoriaItem).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoBarraCategoriaItem, null));
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
            sql += " where Id = " + tipoBarraCategoriaItem.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return tipoBarraCategoriaItem;
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
