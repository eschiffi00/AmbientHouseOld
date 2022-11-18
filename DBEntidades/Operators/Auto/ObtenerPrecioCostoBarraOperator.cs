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
    public partial class ObtenerPrecioCostoBarraOperator
    {

        public static ObtenerPrecioCostoBarra GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoBarraBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoBarra where  = " + .ToString()).Tables[0];
            ObtenerPrecioCostoBarra obtenerPrecioCostoBarra = new ObtenerPrecioCostoBarra();
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerPrecioCostoBarra, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerPrecioCostoBarra;
        }

        public static List<ObtenerPrecioCostoBarra> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoBarraBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerPrecioCostoBarra> lista = new List<ObtenerPrecioCostoBarra>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoBarra").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerPrecioCostoBarra obtenerPrecioCostoBarra = new ObtenerPrecioCostoBarra();
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerPrecioCostoBarra, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerPrecioCostoBarra);
            }
            return lista;
        }
        public static ObtenerPrecioCostoBarra GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoBarraBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPrecioCostoBarra where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerPrecioCostoBarra ObtenerPrecioCostoBarra = new ObtenerPrecioCostoBarra();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerPrecioCostoBarra, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerPrecioCostoBarra;
        }
        public static List<ObtenerPrecioCostoBarra> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoBarraBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerPrecioCostoBarra where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerPrecioCostoBarra where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerPrecioCostoBarra> lista = new List<ObtenerPrecioCostoBarra>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerPrecioCostoBarra entidad = new ObtenerPrecioCostoBarra();
                    foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties())
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
			public static int Descripcion { get; set; } = 50;


        }

        public static ObtenerPrecioCostoBarra Save(ObtenerPrecioCostoBarra obtenerPrecioCostoBarra)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoBarraSave")) throw new PermisoException();
            if (obtenerPrecioCostoBarra. == -1) return Insert(obtenerPrecioCostoBarra);
            else return Update(obtenerPrecioCostoBarra);
        }

        public static ObtenerPrecioCostoBarra Insert(ObtenerPrecioCostoBarra obtenerPrecioCostoBarra)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoBarraSave")) throw new PermisoException();
            string sql = "insert into ObtenerPrecioCostoBarra(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPrecioCostoBarra, null));
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
            obtenerPrecioCostoBarra. = Convert.ToInt32(resp);
            return obtenerPrecioCostoBarra;
        }

        public static ObtenerPrecioCostoBarra Update(ObtenerPrecioCostoBarra obtenerPrecioCostoBarra)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPrecioCostoBarraSave")) throw new PermisoException();
            string sql = "update ObtenerPrecioCostoBarra set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPrecioCostoBarra).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPrecioCostoBarra, null));
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
            sql += " where  = " + obtenerPrecioCostoBarra.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerPrecioCostoBarra;
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
