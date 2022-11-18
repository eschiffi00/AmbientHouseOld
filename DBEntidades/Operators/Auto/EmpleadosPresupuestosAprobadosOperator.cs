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
    public partial class EmpleadosPresupuestosAprobadosOperator
    {

        public static EmpleadosPresupuestosAprobados GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosPresupuestosAprobadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from EmpleadosPresupuestosAprobados where Id = " + Id.ToString()).Tables[0];
            EmpleadosPresupuestosAprobados empleadosPresupuestosAprobados = new EmpleadosPresupuestosAprobados();
            foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(empleadosPresupuestosAprobados, value, null); }
                catch (System.ArgumentException) { }
            }
            return empleadosPresupuestosAprobados;
        }

        public static List<EmpleadosPresupuestosAprobados> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosPresupuestosAprobadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<EmpleadosPresupuestosAprobados> lista = new List<EmpleadosPresupuestosAprobados>();
            DataTable dt = db.GetDataSet("select " + columnas + " from EmpleadosPresupuestosAprobados").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                EmpleadosPresupuestosAprobados empleadosPresupuestosAprobados = new EmpleadosPresupuestosAprobados();
                foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(empleadosPresupuestosAprobados, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(empleadosPresupuestosAprobados);
            }
            return lista;
        }
        public static EmpleadosPresupuestosAprobados GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosPresupuestosAprobadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from EmpleadosPresupuestosAprobados where  " + campo + " = \'" + valor + "\'").Tables[0];
            EmpleadosPresupuestosAprobados EmpleadosPresupuestosAprobados = new EmpleadosPresupuestosAprobados();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(EmpleadosPresupuestosAprobados, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return EmpleadosPresupuestosAprobados;
        }
        public static List<EmpleadosPresupuestosAprobados> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosPresupuestosAprobadosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties())
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
                    queryStr = "select " + columnas + " from EmpleadosPresupuestosAprobados where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from EmpleadosPresupuestosAprobados where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<EmpleadosPresupuestosAprobados> lista = new List<EmpleadosPresupuestosAprobados>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    EmpleadosPresupuestosAprobados entidad = new EmpleadosPresupuestosAprobados();
                    foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties())
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
			public static int HoraIngresoCoordinador1 { get; set; } = 5;
			public static int HoraIngresoCoordinador2 { get; set; } = 5;


        }

        public static EmpleadosPresupuestosAprobados Save(EmpleadosPresupuestosAprobados empleadosPresupuestosAprobados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosPresupuestosAprobadosSave")) throw new PermisoException();
            if (empleadosPresupuestosAprobados.Id == -1) return Insert(empleadosPresupuestosAprobados);
            else return Update(empleadosPresupuestosAprobados);
        }

        public static EmpleadosPresupuestosAprobados Insert(EmpleadosPresupuestosAprobados empleadosPresupuestosAprobados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosPresupuestosAprobadosSave")) throw new PermisoException();
            string sql = "insert into EmpleadosPresupuestosAprobados(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(empleadosPresupuestosAprobados, null));
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
            empleadosPresupuestosAprobados.Id = Convert.ToInt32(resp);
            return empleadosPresupuestosAprobados;
        }

        public static EmpleadosPresupuestosAprobados Update(EmpleadosPresupuestosAprobados empleadosPresupuestosAprobados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosPresupuestosAprobadosSave")) throw new PermisoException();
            string sql = "update EmpleadosPresupuestosAprobados set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EmpleadosPresupuestosAprobados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(empleadosPresupuestosAprobados, null));
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
            sql += " where Id = " + empleadosPresupuestosAprobados.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return empleadosPresupuestosAprobados;
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
