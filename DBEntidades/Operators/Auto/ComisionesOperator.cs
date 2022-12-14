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
    public partial class ComisionesOperator
    {

        public static Comisiones GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComisionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Comisiones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Comisiones where Id = " + Id.ToString()).Tables[0];
            Comisiones comisiones = new Comisiones();
            foreach (PropertyInfo prop in typeof(Comisiones).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(comisiones, value, null); }
                catch (System.ArgumentException) { }
            }
            return comisiones;
        }

        public static List<Comisiones> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComisionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Comisiones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<Comisiones> lista = new List<Comisiones>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Comisiones").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Comisiones comisiones = new Comisiones();
                foreach (PropertyInfo prop in typeof(Comisiones).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(comisiones, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(comisiones);
            }
            return lista;
        }
        public static Comisiones GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComisionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(Comisiones).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from Comisiones where  " + campo + " = \'" + valor + "\'").Tables[0];
            Comisiones Comisiones = new Comisiones();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(Comisiones).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(Comisiones, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return Comisiones;
        }
        public static List<Comisiones> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoComisionesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(Comisiones).GetProperties())
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
                    queryStr = "select " + columnas + " from Comisiones where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from Comisiones where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<Comisiones> lista = new List<Comisiones>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    Comisiones entidad = new Comisiones();
                    foreach (PropertyInfo prop in typeof(Comisiones).GetProperties())
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
			public static int Precio { get; set; } = 50;


        }

        public static Comisiones Save(Comisiones comisiones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComisionesSave")) throw new PermisoException();
            if (comisiones.Id == -1) return Insert(comisiones);
            else return Update(comisiones);
        }

        public static Comisiones Insert(Comisiones comisiones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComisionesSave")) throw new PermisoException();
            string sql = "insert into Comisiones(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Comisiones).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(comisiones, null));
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
            comisiones.Id = Convert.ToInt32(resp);
            return comisiones;
        }

        public static Comisiones Update(Comisiones comisiones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComisionesSave")) throw new PermisoException();
            string sql = "update Comisiones set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Comisiones).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(comisiones, null));
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
            sql += " where Id = " + comisiones.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return comisiones;
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
