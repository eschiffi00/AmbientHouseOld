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
    public partial class LocacionesOperator
    {

        public static Locaciones GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Locaciones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Locaciones where Id = " + Id.ToString()).Tables[0];
            Locaciones locaciones = new Locaciones();
            foreach (PropertyInfo prop in typeof(Locaciones).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(locaciones, value, null); }
                catch (System.ArgumentException) { }
            }
            return locaciones;
        }

        public static List<Locaciones> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Locaciones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<Locaciones> lista = new List<Locaciones>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Locaciones").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Locaciones locaciones = new Locaciones();
                foreach (PropertyInfo prop in typeof(Locaciones).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(locaciones, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(locaciones);
            }
            return lista;
        }
        public static Locaciones GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(Locaciones).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from Locaciones where  " + campo + " = \'" + valor + "\'").Tables[0];
            Locaciones Locaciones = new Locaciones();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(Locaciones).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(Locaciones, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return Locaciones;
        }
        public static List<Locaciones> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(Locaciones).GetProperties())
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
                    queryStr = "select " + columnas + " from Locaciones where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from Locaciones where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<Locaciones> lista = new List<Locaciones>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    Locaciones entidad = new Locaciones();
                    foreach (PropertyInfo prop in typeof(Locaciones).GetProperties())
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
			public static int TipoLocacion { get; set; } = 10;
			public static int Verde { get; set; } = 50;
			public static int AireLibre { get; set; } = 50;
			public static int Estacionamiento { get; set; } = 50;
			public static int Comentarios { get; set; } = 2000;
			public static int TipoCannonCatering { get; set; } = 10;
			public static int TipoCannonBarra { get; set; } = 50;
			public static int TipoCannonAmbientacion { get; set; } = 50;
			public static int Telefono { get; set; } = 50;
			public static int Direccion { get; set; } = 100;
			public static int Mail { get; set; } = 100;
			public static int web { get; set; } = 100;
			public static int TieneLogistica { get; set; } = 1;
			public static int Comisiona { get; set; } = 1;


        }

        public static Locaciones Save(Locaciones locaciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesSave")) throw new PermisoException();
            if (locaciones.Id == -1) return Insert(locaciones);
            else return Update(locaciones);
        }

        public static Locaciones Insert(Locaciones locaciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesSave")) throw new PermisoException();
            string sql = "insert into Locaciones(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Locaciones).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(locaciones, null));
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
            locaciones.Id = Convert.ToInt32(resp);
            return locaciones;
        }

        public static Locaciones Update(Locaciones locaciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesSave")) throw new PermisoException();
            string sql = "update Locaciones set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Locaciones).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(locaciones, null));
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
            sql += " where  = " + locaciones.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return locaciones;
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
