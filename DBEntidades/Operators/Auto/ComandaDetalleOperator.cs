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
    public partial class ComandaDetalleOperator
    {

        public static ComandaDetalle GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComandaDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComandaDetalle where Id = " + Id.ToString()).Tables[0];
            ComandaDetalle comandaDetalle = new ComandaDetalle();
            foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(comandaDetalle, value, null); }
                catch (System.ArgumentException) { }
            }
            return comandaDetalle;
        }

        public static List<ComandaDetalle> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComandaDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ComandaDetalle> lista = new List<ComandaDetalle>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComandaDetalle").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ComandaDetalle comandaDetalle = new ComandaDetalle();
                foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(comandaDetalle, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(comandaDetalle);
            }
            return lista;
        }
        public static ComandaDetalle GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComandaDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ComandaDetalle where  " + campo + " = \'" + valor + "\'").Tables[0];
            ComandaDetalle ComandaDetalle = new ComandaDetalle();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ComandaDetalle, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ComandaDetalle;
        }
        public static List<ComandaDetalle> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoComandaDetalleBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties())
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
                    queryStr = "select " + columnas + " from ComandaDetalle where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ComandaDetalle where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ComandaDetalle> lista = new List<ComandaDetalle>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ComandaDetalle entidad = new ComandaDetalle();
                    foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties())
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
			public static int Clave { get; set; } = 50;


        }

        public static ComandaDetalle Save(ComandaDetalle comandaDetalle)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComandaDetalleSave")) throw new PermisoException();
            if (comandaDetalle.Id == -1) return Insert(comandaDetalle);
            else return Update(comandaDetalle);
        }

        public static ComandaDetalle Insert(ComandaDetalle comandaDetalle)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComandaDetalleSave")) throw new PermisoException();
            string sql = "insert into ComandaDetalle(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(comandaDetalle, null));
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
            comandaDetalle.Id = Convert.ToInt32(resp);
            return comandaDetalle;
        }

        public static ComandaDetalle Update(ComandaDetalle comandaDetalle)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComandaDetalleSave")) throw new PermisoException();
            string sql = "update ComandaDetalle set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ComandaDetalle).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(comandaDetalle, null));
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
            sql += " where Id = " + comandaDetalle.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return comandaDetalle;
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
