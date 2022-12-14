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
    public partial class PersonasOperator
    {

        public static Personas GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPersonasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Personas).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Personas where Id = " + Id.ToString()).Tables[0];
            Personas personas = new Personas();
            foreach (PropertyInfo prop in typeof(Personas).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(personas, value, null); }
                catch (System.ArgumentException) { }
            }
            return personas;
        }

        public static List<Personas> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPersonasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Personas).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<Personas> lista = new List<Personas>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Personas").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Personas personas = new Personas();
                foreach (PropertyInfo prop in typeof(Personas).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(personas, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(personas);
            }
            return lista;
        }



        public class MaxLength
        {
            public static int Descripcion { get; set; } = 200;
            public static int CuitDni { get; set; } = 13;


        }

        public static Personas Save(Personas personas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPersonasSave")) throw new PermisoException();
            if (personas.Id == -1) return Insert(personas);
            else return Update(personas);
        }

        public static Personas Insert(Personas personas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPersonasSave")) throw new PermisoException();
            string sql = "insert into Personas(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Personas).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(personas, null));
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
            personas.Id = Convert.ToInt32(resp);
            return personas;
        }

        public static Personas Update(Personas personas)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPersonasSave")) throw new PermisoException();
            string sql = "update Personas set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Personas).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(personas, null));
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
            sql += " where Id = " + personas.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return personas;
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
