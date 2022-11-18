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
    public partial class GastosporPresupuestosOperator
    {

        public static GastosporPresupuestos GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoGastosporPresupuestosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from GastosporPresupuestos where  = " + .ToString()).Tables[0];
            GastosporPresupuestos gastosporPresupuestos = new GastosporPresupuestos();
            foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(gastosporPresupuestos, value, null); }
                catch (System.ArgumentException) { }
            }
            return gastosporPresupuestos;
        }

        public static List<GastosporPresupuestos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoGastosporPresupuestosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<GastosporPresupuestos> lista = new List<GastosporPresupuestos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from GastosporPresupuestos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                GastosporPresupuestos gastosporPresupuestos = new GastosporPresupuestos();
                foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(gastosporPresupuestos, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(gastosporPresupuestos);
            }
            return lista;
        }
        public static GastosporPresupuestos GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoGastosporPresupuestosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from GastosporPresupuestos where  " + campo + " = \'" + valor + "\'").Tables[0];
            GastosporPresupuestos GastosporPresupuestos = new GastosporPresupuestos();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(GastosporPresupuestos, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return GastosporPresupuestos;
        }
        public static List<GastosporPresupuestos> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoGastosporPresupuestosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties())
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
                    queryStr = "select " + columnas + " from GastosporPresupuestos where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from GastosporPresupuestos where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<GastosporPresupuestos> lista = new List<GastosporPresupuestos>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    GastosporPresupuestos entidad = new GastosporPresupuestos();
                    foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties())
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
			public static int TIPOMOVIMIENTO { get; set; } = 500;
			public static int CENTROCOSTO { get; set; } = 300;
			public static int IMPUESTO { get; set; } = 100;
			public static int RazonSocial { get; set; } = 200;
			public static int ApellidoNombre { get; set; } = 200;
			public static int Leyenda { get; set; } = 200;
			public static int ESTADO { get; set; } = 50;


        }

        public static GastosporPresupuestos Save(GastosporPresupuestos gastosporPresupuestos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoGastosporPresupuestosSave")) throw new PermisoException();
            if (gastosporPresupuestos. == -1) return Insert(gastosporPresupuestos);
            else return Update(gastosporPresupuestos);
        }

        public static GastosporPresupuestos Insert(GastosporPresupuestos gastosporPresupuestos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoGastosporPresupuestosSave")) throw new PermisoException();
            string sql = "insert into GastosporPresupuestos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(gastosporPresupuestos, null));
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
            gastosporPresupuestos. = Convert.ToInt32(resp);
            return gastosporPresupuestos;
        }

        public static GastosporPresupuestos Update(GastosporPresupuestos gastosporPresupuestos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoGastosporPresupuestosSave")) throw new PermisoException();
            string sql = "update GastosporPresupuestos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(GastosporPresupuestos).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(gastosporPresupuestos, null));
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
            sql += " where  = " + gastosporPresupuestos.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return gastosporPresupuestos;
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
