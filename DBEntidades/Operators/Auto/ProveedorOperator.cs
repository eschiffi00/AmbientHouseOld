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
    public partial class ProveedorOperator
    {

        public static Proveedor GetOneByIdentity(int ID)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedorBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Proveedor).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Proveedor where ID = " + ID.ToString()).Tables[0];
            Proveedor proveedor = new Proveedor();
            foreach (PropertyInfo prop in typeof(Proveedor).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(proveedor, value, null); }
                catch (System.ArgumentException) { }
            }
            return proveedor;
        }

        public static List<Proveedor> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedorBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Proveedor).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<Proveedor> lista = new List<Proveedor>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Proveedor").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Proveedor proveedor = new Proveedor();
                foreach (PropertyInfo prop in typeof(Proveedor).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(proveedor, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(proveedor);
            }
            return lista;
        }



        public class MaxLength
        {
            public static int RazonSocial { get; set; } = 100;
            public static int NombreFantasia { get; set; } = 200;
            public static int Localidad { get; set; } = 100;
            public static int Provincia { get; set; } = 100;


        }

        public static Proveedor Save(Proveedor proveedor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedorSave")) throw new PermisoException();
            if (proveedor.ID == -1) return Insert(proveedor);
            else return Update(proveedor);
        }

        public static Proveedor Insert(Proveedor proveedor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedorSave")) throw new PermisoException();
            string sql = "insert into Proveedor(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Proveedor).GetProperties())
            {
                if (prop.Name == "ID") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(proveedor, null));
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
            proveedor.ID = Convert.ToInt32(resp);
            return proveedor;
        }

        public static Proveedor Update(Proveedor proveedor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProveedorSave")) throw new PermisoException();
            string sql = "update Proveedor set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Proveedor).GetProperties())
            {
                if (prop.Name == "ID") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(proveedor, null));
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
            sql += " where ID = " + proveedor.ID;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return proveedor;
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
