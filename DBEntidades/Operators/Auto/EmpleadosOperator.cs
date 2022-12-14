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
    public partial class EmpleadosOperator
    {

        public static Empleados GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Empleados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Empleados where Id = " + Id.ToString()).Tables[0];
            Empleados empleados = new Empleados();
            foreach (PropertyInfo prop in typeof(Empleados).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(empleados, value, null); }
                catch (System.ArgumentException) { }
            }
            return empleados;
        }

        public static List<Empleados> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Empleados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<Empleados> lista = new List<Empleados>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Empleados").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Empleados empleados = new Empleados();
                foreach (PropertyInfo prop in typeof(Empleados).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(empleados, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(empleados);
            }
            return lista;
        }
        public static Empleados GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(Empleados).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from Empleados where  " + campo + " = \'" + valor + "\'").Tables[0];
            Empleados Empleados = new Empleados();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(Empleados).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(Empleados, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return Empleados;
        }
        public static List<Empleados> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(Empleados).GetProperties())
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
                    queryStr = "select " + columnas + " from Empleados where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from Empleados where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<Empleados> lista = new List<Empleados>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    Empleados entidad = new Empleados();
                    foreach (PropertyInfo prop in typeof(Empleados).GetProperties())
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

		public static List<Empleados> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<Empleados> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<Empleados> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<Empleados> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int ApellidoNombre { get; set; } = 100;
			public static int Nombre { get; set; } = 100;
			public static int Mail { get; set; } = 100;
			public static int MailLaboral { get; set; } = 100;
			public static int TipoDocumento { get; set; } = 10;
			public static int Cuil { get; set; } = 20;
			public static int Direccion { get; set; } = 100;
			public static int DireccionLegal { get; set; } = 100;
			public static int CP { get; set; } = 10;
			public static int CPLegal { get; set; } = 10;
			public static int TelefonoFijo { get; set; } = 50;
			public static int TelefonoMovil { get; set; } = 50;
			public static int TelefonoFijoLaboral { get; set; } = 50;
			public static int CelularFijoLaboral { get; set; } = 50;
			public static int NroPc { get; set; } = 50;
			public static int HorarioDesde { get; set; } = 5;
			public static int HorarioHasta { get; set; } = 5;
			public static int Observaciones { get; set; } = 2000;


        }

        public static Empleados Save(Empleados empleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosSave")) throw new PermisoException();
            if (empleados.Id == -1) return Insert(empleados);
            else return Update(empleados);
        }

        public static Empleados Insert(Empleados empleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosSave")) throw new PermisoException();
            string sql = "insert into Empleados(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Empleados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(empleados, null));
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
            empleados.Id = Convert.ToInt32(resp);
            return empleados;
        }

        public static Empleados Update(Empleados empleados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEmpleadosSave")) throw new PermisoException();
            string sql = "update Empleados set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Empleados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(empleados, null));
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
            sql += " where Id = " + empleados.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return empleados;
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
