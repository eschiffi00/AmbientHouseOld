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
    public partial class ObtenerPresupuestoBarraOperator
    {

        public static ObtenerPresupuestoBarra GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoBarraBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoBarra where  = " + .ToString()).Tables[0];
            ObtenerPresupuestoBarra obtenerPresupuestoBarra = new ObtenerPresupuestoBarra();
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(obtenerPresupuestoBarra, value, null); }
                catch (System.ArgumentException) { }
            }
            return obtenerPresupuestoBarra;
        }

        public static List<ObtenerPresupuestoBarra> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoBarraBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ObtenerPresupuestoBarra> lista = new List<ObtenerPresupuestoBarra>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoBarra").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ObtenerPresupuestoBarra obtenerPresupuestoBarra = new ObtenerPresupuestoBarra();
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(obtenerPresupuestoBarra, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(obtenerPresupuestoBarra);
            }
            return lista;
        }
        public static ObtenerPresupuestoBarra GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoBarraBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ObtenerPresupuestoBarra where  " + campo + " = \'" + valor + "\'").Tables[0];
            ObtenerPresupuestoBarra ObtenerPresupuestoBarra = new ObtenerPresupuestoBarra();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ObtenerPresupuestoBarra, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ObtenerPresupuestoBarra;
        }
        public static List<ObtenerPresupuestoBarra> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoBarraBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties())
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
                    queryStr = "select " + columnas + " from ObtenerPresupuestoBarra where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ObtenerPresupuestoBarra where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ObtenerPresupuestoBarra> lista = new List<ObtenerPresupuestoBarra>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ObtenerPresupuestoBarra entidad = new ObtenerPresupuestoBarra();
                    foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties())
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
			public static int SalonInOut { get; set; } = 50;
			public static int AdjuntoExtension { get; set; } = 50;
			public static int Descripcion { get; set; } = 50;
			public static int RazonSocial { get; set; } = 50;


        }

        public static ObtenerPresupuestoBarra Save(ObtenerPresupuestoBarra obtenerPresupuestoBarra)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoBarraSave")) throw new PermisoException();
            if (obtenerPresupuestoBarra. == -1) return Insert(obtenerPresupuestoBarra);
            else return Update(obtenerPresupuestoBarra);
        }

        public static ObtenerPresupuestoBarra Insert(ObtenerPresupuestoBarra obtenerPresupuestoBarra)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoBarraSave")) throw new PermisoException();
            string sql = "insert into ObtenerPresupuestoBarra(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoBarra, null));
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
            obtenerPresupuestoBarra. = Convert.ToInt32(resp);
            return obtenerPresupuestoBarra;
        }

        public static ObtenerPresupuestoBarra Update(ObtenerPresupuestoBarra obtenerPresupuestoBarra)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoObtenerPresupuestoBarraSave")) throw new PermisoException();
            string sql = "update ObtenerPresupuestoBarra set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ObtenerPresupuestoBarra).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(obtenerPresupuestoBarra, null));
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
            sql += " where  = " + obtenerPresupuestoBarra.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return obtenerPresupuestoBarra;
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
