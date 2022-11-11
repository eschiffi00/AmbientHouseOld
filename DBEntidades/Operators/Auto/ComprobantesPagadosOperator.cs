using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

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
            ComprobantesPagados ComprobantesPagados = new ComprobantesPagados();
            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(ComprobantesPagados, value, null); }
                catch (System.ArgumentException) { }
            }
            return ComprobantesPagados;
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
                ComprobantesPagados ComprobantesPagados = new ComprobantesPagados();
                foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ComprobantesPagados, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(ComprobantesPagados);
            }
            return lista;
        }



        public class MaxLength
        {


        }

        public static ComprobantesPagados Save(ComprobantesPagados ComprobantesPagados)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosSave")) throw new PermisoException();
            if (ComprobantesPagados.Id == -1) return Insert(ComprobantesPagados);
            else return Update(ComprobantesPagados);
        }

        public static ComprobantesPagados Insert(ComprobantesPagados ComprobantesPagados)
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
                valor.Add(prop.GetValue(ComprobantesPagados, null));
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
            ComprobantesPagados.Id = Convert.ToInt32(resp);
            return ComprobantesPagados;
        }

        public static ComprobantesPagados Update(ComprobantesPagados ComprobantesPagados)
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
                valor.Add(prop.GetValue(ComprobantesPagados, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            sql += columnas;
            List<object> parametros = new List<object>();
            for (int i = 0; i < param.Count; i++)
            {
                parametros.Add(param[i]);
                parametros.Add(valor[i]);
                SqlParameter p = new SqlParameter(param[i].ToString(), valor[i]);
                sqlParams.Add(p);
            }
            sql += " where  Id = " + ComprobantesPagados.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return ComprobantesPagados;
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
