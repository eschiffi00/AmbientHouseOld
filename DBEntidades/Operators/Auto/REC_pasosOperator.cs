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
    public partial class REC_pasosOperator
    {

        public static REC_pasos GetOneByIdentity(int ID)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoREC_pasosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(REC_pasos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from REC_pasos where ID = " + ID.ToString()).Tables[0];
            REC_pasos rEC_pasos = new REC_pasos();
            foreach (PropertyInfo prop in typeof(REC_pasos).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(rEC_pasos, value, null); }
                catch (System.ArgumentException) { }
            }
            return rEC_pasos;
        }

        public static List<REC_pasos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoREC_pasosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(REC_pasos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<REC_pasos> lista = new List<REC_pasos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from REC_pasos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                REC_pasos rEC_pasos = new REC_pasos();
                foreach (PropertyInfo prop in typeof(REC_pasos).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(rEC_pasos, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(rEC_pasos);
            }
            return lista;
        }



        public class MaxLength
        {
            public static int Orden { get; set; } = 10;


        }

        public static REC_pasos Save(REC_pasos rEC_pasos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoREC_pasosSave")) throw new PermisoException();
            if (rEC_pasos.ID == -1) return Insert(rEC_pasos);
            else return Update(rEC_pasos);
        }

        public static REC_pasos Insert(REC_pasos rEC_pasos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoREC_pasosSave")) throw new PermisoException();
            string sql = "insert into REC_pasos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(REC_pasos).GetProperties())
            {
                if (prop.Name == "ID") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(rEC_pasos, null));
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
            rEC_pasos.ID = Convert.ToInt32(resp);
            return rEC_pasos;
        }

        public static REC_pasos Update(REC_pasos rEC_pasos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoREC_pasosSave")) throw new PermisoException();
            string sql = "update REC_pasos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(REC_pasos).GetProperties())
            {
                if (prop.Name == "ID") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(rEC_pasos, null));
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
            sql += " where ID = " + rEC_pasos.ID;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return rEC_pasos;
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
