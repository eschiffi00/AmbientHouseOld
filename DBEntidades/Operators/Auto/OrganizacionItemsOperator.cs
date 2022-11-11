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
    public partial class OrganizacionItemsOperator
    {

        public static OrganizacionItems GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoOrganizacionItemsBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(OrganizacionItems).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from OrganizacionItems where Id = " + Id.ToString()).Tables[0];
            OrganizacionItems organizacionItems = new OrganizacionItems();
            foreach (PropertyInfo prop in typeof(OrganizacionItems).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(organizacionItems, value, null); }
                catch (System.ArgumentException) { }
            }
            return organizacionItems;
        }

        public static List<OrganizacionItems> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoOrganizacionItemsBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(OrganizacionItems).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<OrganizacionItems> lista = new List<OrganizacionItems>();
            DataTable dt = db.GetDataSet("select " + columnas + " from OrganizacionItems").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                OrganizacionItems organizacionItems = new OrganizacionItems();
                foreach (PropertyInfo prop in typeof(OrganizacionItems).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(organizacionItems, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(organizacionItems);
            }
            return lista;
        }



        public class MaxLength
        {
            public static int Descripcion { get; set; } = 200;
            public static int RequiereCantidad { get; set; } = 1;


        }

        public static OrganizacionItems Save(OrganizacionItems organizacionItems)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoOrganizacionItemsSave")) throw new PermisoException();
            if (organizacionItems.Id == -1) return Insert(organizacionItems);
            else return Update(organizacionItems);
        }

        public static OrganizacionItems Insert(OrganizacionItems organizacionItems)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoOrganizacionItemsSave")) throw new PermisoException();
            string sql = "insert into OrganizacionItems(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(OrganizacionItems).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(organizacionItems, null));
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
            organizacionItems.Id = Convert.ToInt32(resp);
            return organizacionItems;
        }

        public static OrganizacionItems Update(OrganizacionItems organizacionItems)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoOrganizacionItemsSave")) throw new PermisoException();
            string sql = "update OrganizacionItems set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(OrganizacionItems).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(organizacionItems, null));
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
            sql += " where Id = " + organizacionItems.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return organizacionItems;
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
