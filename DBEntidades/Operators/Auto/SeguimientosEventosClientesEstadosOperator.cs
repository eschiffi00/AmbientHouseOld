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
    public partial class SeguimientosEventosClientesEstadosOperator
    {

        public static SeguimientosEventosClientesEstados GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoSeguimientosEventosClientesEstadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from SeguimientosEventosClientesEstados where  = " + .ToString()).Tables[0];
            SeguimientosEventosClientesEstados seguimientosEventosClientesEstados = new SeguimientosEventosClientesEstados();
            foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(seguimientosEventosClientesEstados, value, null); }
                catch (System.ArgumentException) { }
            }
            return seguimientosEventosClientesEstados;
        }

        public static List<SeguimientosEventosClientesEstados> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoSeguimientosEventosClientesEstadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<SeguimientosEventosClientesEstados> lista = new List<SeguimientosEventosClientesEstados>();
            DataTable dt = db.GetDataSet("select " + columnas + " from SeguimientosEventosClientesEstados").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                SeguimientosEventosClientesEstados seguimientosEventosClientesEstados = new SeguimientosEventosClientesEstados();
                foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(seguimientosEventosClientesEstados, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(seguimientosEventosClientesEstados);
            }
            return lista;
        }
        public static SeguimientosEventosClientesEstados GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoSeguimientosEventosClientesEstadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from SeguimientosEventosClientesEstados where  " + campo + " = \'" + valor + "\'").Tables[0];
            SeguimientosEventosClientesEstados SeguimientosEventosClientesEstados = new SeguimientosEventosClientesEstados();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(SeguimientosEventosClientesEstados, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return SeguimientosEventosClientesEstados;
        }
        public static List<SeguimientosEventosClientesEstados> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoSeguimientosEventosClientesEstadosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties())
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
                    queryStr = "select " + columnas + " from SeguimientosEventosClientesEstados where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from SeguimientosEventosClientesEstados where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<SeguimientosEventosClientesEstados> lista = new List<SeguimientosEventosClientesEstados>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    SeguimientosEventosClientesEstados entidad = new SeguimientosEventosClientesEstados();
                    foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties())
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

		public static List<SeguimientosEventosClientesEstados> GetAllEstado1()
		{
			return GetAll().Where(x => x.EstadoId == 1).ToList();
		}
		public static List<SeguimientosEventosClientesEstados> GetAllEstadoNot1()
		{
			return GetAll().Where(x => x.EstadoId != 1).ToList();
		}
		public static List<SeguimientosEventosClientesEstados> GetAllEstadoN(int estado)
		{
			return GetAll().Where(x => x.EstadoId == estado).ToList();
		}
		public static List<SeguimientosEventosClientesEstados> GetAllEstadoNotN(int estado)
		{
			return GetAll().Where(x => x.EstadoId != estado).ToList();
		}


        public class MaxLength
        {
			public static int RazonSocial { get; set; } = 200;
			public static int ApellidoNombreCliente { get; set; } = 100;
			public static int Mail { get; set; } = 100;
			public static int Celular { get; set; } = 50;
			public static int ApellidoNombre { get; set; } = 50;
			public static int Comentario { get; set; } = 2000;
			public static int Descripcion { get; set; } = 50;
			public static int Caracteristica { get; set; } = 50;
			public static int TipoEvento { get; set; } = 50;
			public static int EstadoPresupuesto { get; set; } = 50;


        }

        public static SeguimientosEventosClientesEstados Save(SeguimientosEventosClientesEstados seguimientosEventosClientesEstados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoSeguimientosEventosClientesEstadosSave")) throw new PermisoException();
            if (seguimientosEventosClientesEstados. == -1) return Insert(seguimientosEventosClientesEstados);
            else return Update(seguimientosEventosClientesEstados);
        }

        public static SeguimientosEventosClientesEstados Insert(SeguimientosEventosClientesEstados seguimientosEventosClientesEstados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoSeguimientosEventosClientesEstadosSave")) throw new PermisoException();
            string sql = "insert into SeguimientosEventosClientesEstados(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(seguimientosEventosClientesEstados, null));
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
            seguimientosEventosClientesEstados. = Convert.ToInt32(resp);
            return seguimientosEventosClientesEstados;
        }

        public static SeguimientosEventosClientesEstados Update(SeguimientosEventosClientesEstados seguimientosEventosClientesEstados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoSeguimientosEventosClientesEstadosSave")) throw new PermisoException();
            string sql = "update SeguimientosEventosClientesEstados set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(SeguimientosEventosClientesEstados).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(seguimientosEventosClientesEstados, null));
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
            sql += " where  = " + seguimientosEventosClientesEstados.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return seguimientosEventosClientesEstados;
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
