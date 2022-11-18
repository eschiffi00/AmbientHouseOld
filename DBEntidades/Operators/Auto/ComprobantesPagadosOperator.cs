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
    public partial class ComprobantesPagadosOperator
    {

        public static ComprobantesPagados GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesPagados where Id = " + Id.ToString()).Tables[0];
            ComprobantesPagados comprobantesPagados = new ComprobantesPagados();
            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(comprobantesPagados, value, null); }
                catch (System.ArgumentException) { }
            }
            return comprobantesPagados;
        }

        public static List<ComprobantesPagados> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ComprobantesPagados> lista = new List<ComprobantesPagados>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesPagados").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ComprobantesPagados comprobantesPagados = new ComprobantesPagados();
                foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(comprobantesPagados, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(comprobantesPagados);
            }
            return lista;
        }
        public static ComprobantesPagados GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesPagados where  " + campo + " = \'" + valor + "\'").Tables[0];
            ComprobantesPagados ComprobantesPagados = new ComprobantesPagados();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ComprobantesPagados, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ComprobantesPagados;
        }
        public static List<ComprobantesPagados> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
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
                    queryStr = "select " + columnas + " from ComprobantesPagados where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from ComprobantesPagados where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<ComprobantesPagados> lista = new List<ComprobantesPagados>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    ComprobantesPagados entidad = new ComprobantesPagados();
                    foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
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
			public static int TMDescripcion { get; set; } = 50;


        }

        public static ComprobantesPagados Save(ComprobantesPagados comprobantesPagados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosSave")) throw new PermisoException();
            if (comprobantesPagados.Id == -1) return Insert(comprobantesPagados);
            else return Update(comprobantesPagados);
        }

        public static ComprobantesPagados Insert(ComprobantesPagados comprobantesPagados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosSave")) throw new PermisoException();
            string sql = "insert into ComprobantesPagados(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(comprobantesPagados, null));
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
            comprobantesPagados.Id = Convert.ToInt32(resp);
            return comprobantesPagados;
        }

        public static ComprobantesPagados Update(ComprobantesPagados comprobantesPagados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosSave")) throw new PermisoException();
            string sql = "update ComprobantesPagados set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(comprobantesPagados, null));
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
            sql += " where Id = " + comprobantesPagados.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return comprobantesPagados;
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
