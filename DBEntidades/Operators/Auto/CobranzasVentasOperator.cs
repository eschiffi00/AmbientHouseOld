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
    public partial class CobranzasVentasOperator
    {

        public static CobranzasVentas GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCobranzasVentasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from CobranzasVentas where  = " + .ToString()).Tables[0];
            CobranzasVentas cobranzasVentas = new CobranzasVentas();
            foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(cobranzasVentas, value, null); }
                catch (System.ArgumentException) { }
            }
            return cobranzasVentas;
        }

        public static List<CobranzasVentas> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCobranzasVentasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<CobranzasVentas> lista = new List<CobranzasVentas>();
            DataTable dt = db.GetDataSet("select " + columnas + " from CobranzasVentas").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                CobranzasVentas cobranzasVentas = new CobranzasVentas();
                foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(cobranzasVentas, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(cobranzasVentas);
            }
            return lista;
        }
        public static CobranzasVentas GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCobranzasVentasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from CobranzasVentas where  " + campo + " = \'" + valor + "\'").Tables[0];
            CobranzasVentas CobranzasVentas = new CobranzasVentas();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(CobranzasVentas, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return CobranzasVentas;
        }
        public static List<CobranzasVentas> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoCobranzasVentasBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties())
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
                    queryStr = "select " + columnas + " from CobranzasVentas where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from CobranzasVentas where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<CobranzasVentas> lista = new List<CobranzasVentas>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    CobranzasVentas entidad = new CobranzasVentas();
                    foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties())
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
			public static int NroRecibo { get; set; } = 50;
			public static int Concepto { get; set; } = 500;
			public static int Descripcion { get; set; } = 500;
			public static int RazonSocial { get; set; } = 300;
			public static int FormaPago { get; set; } = 100;
			public static int TipoIndexacion { get; set; } = 50;


        }

        public static CobranzasVentas Save(CobranzasVentas cobranzasVentas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCobranzasVentasSave")) throw new PermisoException();
            if (cobranzasVentas. == -1) return Insert(cobranzasVentas);
            else return Update(cobranzasVentas);
        }

        public static CobranzasVentas Insert(CobranzasVentas cobranzasVentas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCobranzasVentasSave")) throw new PermisoException();
            string sql = "insert into CobranzasVentas(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(cobranzasVentas, null));
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
            cobranzasVentas. = Convert.ToInt32(resp);
            return cobranzasVentas;
        }

        public static CobranzasVentas Update(CobranzasVentas cobranzasVentas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCobranzasVentasSave")) throw new PermisoException();
            string sql = "update CobranzasVentas set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(CobranzasVentas).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(cobranzasVentas, null));
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
            sql += " where  = " + cobranzasVentas.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return cobranzasVentas;
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
