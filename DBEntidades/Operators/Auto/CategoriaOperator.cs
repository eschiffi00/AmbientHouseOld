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
    public partial class CategoriaOperator
    {

        public static Categoria GetOneByIdentity(int ID)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCategoriaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Categoria).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Categoria where ID = " + ID.ToString()).Tables[0];
            Categoria categoria = new Categoria();
            foreach (PropertyInfo prop in typeof(Categoria).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(categoria, value, null); }
                catch (System.ArgumentException) { }
            }
            return categoria;
        }

        public static List<Categoria> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCategoriaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Categoria).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<Categoria> lista = new List<Categoria>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Categoria").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Categoria categoria = new Categoria();
                foreach (PropertyInfo prop in typeof(Categoria).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(categoria, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(categoria);
            }
            return lista;
        }



        public class MaxLength
        {
            public static int Descripcion { get; set; } = 50;


        }

        public static Categoria Save(Categoria categoria)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCategoriaSave")) throw new PermisoException();
            if (categoria.ID == -1) return Insert(categoria);
            else return Update(categoria);
        }

        public static Categoria Insert(Categoria categoria)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCategoriaSave")) throw new PermisoException();
            string sql = "insert into Categoria(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Categoria).GetProperties())
            {
                if (prop.Name == "ID") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(categoria, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            valores = valores.Substring(0, valores.Length - 2);
            sql += columnas + ") output inserted.ID values (" + valores + ")";
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
            categoria.ID = Convert.ToInt32(resp);
            return categoria;
        }

        public static Categoria Update(Categoria categoria)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCategoriaSave")) throw new PermisoException();
            string sql = "update Categoria set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Categoria).GetProperties())
            {
                if (prop.Name == "ID") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(categoria, null));
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
            sql += " where ID = " + categoria.ID;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return categoria;
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
