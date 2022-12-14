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
    public partial class FacturasClienteOperator
    {

        public static FacturasCliente GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFacturasClienteBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from FacturasCliente where Id = " + Id.ToString()).Tables[0];
            FacturasCliente facturasCliente = new FacturasCliente();
            foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(facturasCliente, value, null); }
                catch (System.ArgumentException) { }
            }
            return facturasCliente;
        }

        public static List<FacturasCliente> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFacturasClienteBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<FacturasCliente> lista = new List<FacturasCliente>();
            DataTable dt = db.GetDataSet("select " + columnas + " from FacturasCliente").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                FacturasCliente facturasCliente = new FacturasCliente();
                foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(facturasCliente, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(facturasCliente);
            }
            return lista;
        }
        public static FacturasCliente GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFacturasClienteBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from FacturasCliente where  " + campo + " = \'" + valor + "\'").Tables[0];
            FacturasCliente FacturasCliente = new FacturasCliente();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(FacturasCliente, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return FacturasCliente;
        }
        public static List<FacturasCliente> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoFacturasClienteBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties())
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
                    queryStr = "select " + columnas + " from FacturasCliente where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from FacturasCliente where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<FacturasCliente> lista = new List<FacturasCliente>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    FacturasCliente entidad = new FacturasCliente();
                    foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties())
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

		public static List<FacturasCliente> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<FacturasCliente> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<FacturasCliente> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<FacturasCliente> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {


        }

        public static FacturasCliente Save(FacturasCliente facturasCliente)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFacturasClienteSave")) throw new PermisoException();
            if (facturasCliente.Id == -1) return Insert(facturasCliente);
            else return Update(facturasCliente);
        }

        public static FacturasCliente Insert(FacturasCliente facturasCliente)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFacturasClienteSave")) throw new PermisoException();
            string sql = "insert into FacturasCliente(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(facturasCliente, null));
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
            facturasCliente.Id = Convert.ToInt32(resp);
            return facturasCliente;
        }

        public static FacturasCliente Update(FacturasCliente facturasCliente)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFacturasClienteSave")) throw new PermisoException();
            string sql = "update FacturasCliente set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(FacturasCliente).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(facturasCliente, null));
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
            sql += " where Id = " + facturasCliente.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return facturasCliente;
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
