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
    public partial class ProductosOperator
    {

        public static Productos GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Productos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Productos where Id = " + Id.ToString()).Tables[0];
            Productos productos = new Productos();
            foreach (PropertyInfo prop in typeof(Productos).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(productos, value, null); }
                catch (System.ArgumentException) { }
            }
            return productos;
        }

        public static List<Productos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Productos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<Productos> lista = new List<Productos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Productos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Productos productos = new Productos();
                foreach (PropertyInfo prop in typeof(Productos).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(productos, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(productos);
            }
            return lista;
        }



        public class MaxLength
        {
            public static int Codigo { get; set; } = 100;
            public static int Descripcion { get; set; } = 1000;
            public static int Dia { get; set; } = 50;


        }

        public static Productos Save(Productos productos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductosSave")) throw new PermisoException();
            if (productos.Id == -1) return Insert(productos);
            else return Update(productos);
        }

        public static Productos Insert(Productos productos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductosSave")) throw new PermisoException();
            string sql = "insert into Productos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Productos).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(productos, null));
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
            productos.Id = Convert.ToInt32(resp);
            return productos;
        }

        public static Productos Update(Productos productos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductosSave")) throw new PermisoException();
            string sql = "update Productos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Productos).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(productos, null));
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
            sql += " where Id = " + productos.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return productos;
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
