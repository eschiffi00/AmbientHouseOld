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
    public partial class EmpleadoDepartamentosOperator
    {

        public static EmpleadoDepartamentos GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadoDepartamentosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from EmpleadoDepartamentos where Id = " + Id.ToString()).Tables[0];
            EmpleadoDepartamentos empleadoDepartamentos = new EmpleadoDepartamentos();
            foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(empleadoDepartamentos, value, null); }
                catch (System.ArgumentException) { }
            }
            return empleadoDepartamentos;
        }

        public static List<EmpleadoDepartamentos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadoDepartamentosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<EmpleadoDepartamentos> lista = new List<EmpleadoDepartamentos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from EmpleadoDepartamentos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                EmpleadoDepartamentos empleadoDepartamentos = new EmpleadoDepartamentos();
                foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(empleadoDepartamentos, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(empleadoDepartamentos);
            }
            return lista;
        }
        public static EmpleadoDepartamentos GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadoDepartamentosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from EmpleadoDepartamentos where  " + campo + " = \'" + valor + "\'").Tables[0];
            EmpleadoDepartamentos EmpleadoDepartamentos = new EmpleadoDepartamentos();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(EmpleadoDepartamentos, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return EmpleadoDepartamentos;
        }
        public static List<EmpleadoDepartamentos> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadoDepartamentosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties())
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
                    queryStr = "select " + columnas + " from EmpleadoDepartamentos where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from EmpleadoDepartamentos where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<EmpleadoDepartamentos> lista = new List<EmpleadoDepartamentos>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    EmpleadoDepartamentos entidad = new EmpleadoDepartamentos();
                    foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties())
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


        }

        public static EmpleadoDepartamentos Save(EmpleadoDepartamentos empleadoDepartamentos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadoDepartamentosSave")) throw new PermisoException();
            if (empleadoDepartamentos.Id == -1) return Insert(empleadoDepartamentos);
            else return Update(empleadoDepartamentos);
        }

        public static EmpleadoDepartamentos Insert(EmpleadoDepartamentos empleadoDepartamentos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadoDepartamentosSave")) throw new PermisoException();
            string sql = "insert into EmpleadoDepartamentos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(empleadoDepartamentos, null));
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
            empleadoDepartamentos.Id = Convert.ToInt32(resp);
            return empleadoDepartamentos;
        }

        public static EmpleadoDepartamentos Update(EmpleadoDepartamentos empleadoDepartamentos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadoDepartamentosSave")) throw new PermisoException();
            string sql = "update EmpleadoDepartamentos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EmpleadoDepartamentos).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(empleadoDepartamentos, null));
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
            sql += " where Id = " + empleadoDepartamentos.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return empleadoDepartamentos;
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
