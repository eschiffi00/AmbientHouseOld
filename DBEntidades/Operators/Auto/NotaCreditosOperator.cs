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
    public partial class NotaCreditosOperator
    {

        public static NotaCreditos GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNotaCreditosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from NotaCreditos where Id = " + Id.ToString()).Tables[0];
            NotaCreditos notaCreditos = new NotaCreditos();
            foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(notaCreditos, value, null); }
                catch (System.ArgumentException) { }
            }
            return notaCreditos;
        }

        public static List<NotaCreditos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNotaCreditosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<NotaCreditos> lista = new List<NotaCreditos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from NotaCreditos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                NotaCreditos notaCreditos = new NotaCreditos();
                foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(notaCreditos, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(notaCreditos);
            }
            return lista;
        }
        public static NotaCreditos GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNotaCreditosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from NotaCreditos where  " + campo + " = \'" + valor + "\'").Tables[0];
            NotaCreditos NotaCreditos = new NotaCreditos();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(NotaCreditos, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return NotaCreditos;
        }
        public static List<NotaCreditos> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoNotaCreditosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties())
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
                    queryStr = "select " + columnas + " from NotaCreditos where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from NotaCreditos where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<NotaCreditos> lista = new List<NotaCreditos>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    NotaCreditos entidad = new NotaCreditos();
                    foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties())
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

        public static NotaCreditos Save(NotaCreditos notaCreditos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNotaCreditosSave")) throw new PermisoException();
            if (notaCreditos.Id == -1) return Insert(notaCreditos);
            else return Update(notaCreditos);
        }

        public static NotaCreditos Insert(NotaCreditos notaCreditos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNotaCreditosSave")) throw new PermisoException();
            string sql = "insert into NotaCreditos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(notaCreditos, null));
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
            notaCreditos.Id = Convert.ToInt32(resp);
            return notaCreditos;
        }

        public static NotaCreditos Update(NotaCreditos notaCreditos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNotaCreditosSave")) throw new PermisoException();
            string sql = "update NotaCreditos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(NotaCreditos).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(notaCreditos, null));
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
            sql += " where Id = " + notaCreditos.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return notaCreditos;
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
