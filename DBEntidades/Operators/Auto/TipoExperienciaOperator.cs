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
    public partial class TipoExperienciaOperator
    {

        public static TipoExperiencia GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoExperienciaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoExperiencia).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoExperiencia where Id = " + Id.ToString()).Tables[0];
            TipoExperiencia tipoExperiencia = new TipoExperiencia();
            foreach (PropertyInfo prop in typeof(TipoExperiencia).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(tipoExperiencia, value, null); }
                catch (System.ArgumentException) { }
            }
            return tipoExperiencia;
        }

        public static List<TipoExperiencia> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoExperienciaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoExperiencia).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TipoExperiencia> lista = new List<TipoExperiencia>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoExperiencia").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TipoExperiencia tipoExperiencia = new TipoExperiencia();
                foreach (PropertyInfo prop in typeof(TipoExperiencia).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(tipoExperiencia, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(tipoExperiencia);
            }
            return lista;
        }



        public class MaxLength
        {
            public static int Descripcion { get; set; } = 100;


        }

        public static TipoExperiencia Save(TipoExperiencia tipoExperiencia)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoExperienciaSave")) throw new PermisoException();
            if (tipoExperiencia.ID == -1) return Insert(tipoExperiencia);
            else return Update(tipoExperiencia);
        }

        public static TipoExperiencia Insert(TipoExperiencia tipoExperiencia)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoExperienciaSave")) throw new PermisoException();
            string sql = "insert into TipoExperiencia(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoExperiencia).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoExperiencia, null));
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
            tipoExperiencia.ID = Convert.ToInt32(resp);
            return tipoExperiencia;
        }

        public static TipoExperiencia Update(TipoExperiencia tipoExperiencia)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoExperienciaSave")) throw new PermisoException();
            string sql = "update TipoExperiencia set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoExperiencia).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoExperiencia, null));
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
            sql += " where ID = " + tipoExperiencia.ID;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return tipoExperiencia;
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
