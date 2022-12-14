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
    public partial class FormasdePagoOperator
    {

        public static FormasdePago GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFormasdePagoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from FormasdePago where Id = " + Id.ToString()).Tables[0];
            FormasdePago formasdePago = new FormasdePago();
            foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(formasdePago, value, null); }
                catch (System.ArgumentException) { }
            }
            return formasdePago;
        }

        public static List<FormasdePago> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFormasdePagoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<FormasdePago> lista = new List<FormasdePago>();
            DataTable dt = db.GetDataSet("select " + columnas + " from FormasdePago").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                FormasdePago formasdePago = new FormasdePago();
                foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(formasdePago, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(formasdePago);
            }
            return lista;
        }
        public static FormasdePago GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFormasdePagoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from FormasdePago where  " + campo + " = \'" + valor + "\'").Tables[0];
            FormasdePago FormasdePago = new FormasdePago();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(FormasdePago, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return FormasdePago;
        }
        public static List<FormasdePago> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoFormasdePagoBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties())
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
                    queryStr = "select " + columnas + " from FormasdePago where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from FormasdePago where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<FormasdePago> lista = new List<FormasdePago>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    FormasdePago entidad = new FormasdePago();
                    foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties())
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
			public static int Descripcion { get; set; } = 100;


        }

        public static FormasdePago Save(FormasdePago formasdePago)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFormasdePagoSave")) throw new PermisoException();
            if (formasdePago.Id == -1) return Insert(formasdePago);
            else return Update(formasdePago);
        }

        public static FormasdePago Insert(FormasdePago formasdePago)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFormasdePagoSave")) throw new PermisoException();
            string sql = "insert into FormasdePago(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(formasdePago, null));
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
            formasdePago.Id = Convert.ToInt32(resp);
            return formasdePago;
        }

        public static FormasdePago Update(FormasdePago formasdePago)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoFormasdePagoSave")) throw new PermisoException();
            string sql = "update FormasdePago set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(FormasdePago).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(formasdePago, null));
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
            sql += " where Id = " + formasdePago.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return formasdePago;
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
