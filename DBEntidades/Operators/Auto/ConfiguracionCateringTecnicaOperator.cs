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
    public partial class ConfiguracionCateringTecnicaOperator
    {

        public static ConfiguracionCateringTecnica GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoConfiguracionCateringTecnicaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ConfiguracionCateringTecnica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ConfiguracionCateringTecnica where Id = " + Id.ToString()).Tables[0];
            ConfiguracionCateringTecnica configuracionCateringTecnica = new ConfiguracionCateringTecnica();
            foreach (PropertyInfo prop in typeof(ConfiguracionCateringTecnica).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(configuracionCateringTecnica, value, null); }
                catch (System.ArgumentException) { }
            }
            return configuracionCateringTecnica;
        }

        public static List<ConfiguracionCateringTecnica> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoConfiguracionCateringTecnicaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ConfiguracionCateringTecnica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ConfiguracionCateringTecnica> lista = new List<ConfiguracionCateringTecnica>();
            DataTable dt = db.GetDataSet("select " + columnas + " from ConfiguracionCateringTecnica").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ConfiguracionCateringTecnica configuracionCateringTecnica = new ConfiguracionCateringTecnica();
                foreach (PropertyInfo prop in typeof(ConfiguracionCateringTecnica).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(configuracionCateringTecnica, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(configuracionCateringTecnica);
            }
            return lista;
        }

        public static List<ConfiguracionCateringTecnica> GetAllEstado1()
        {
            return GetAll().Where(x => x.EstadoId == 1).ToList();
        }
        public static List<ConfiguracionCateringTecnica> GetAllEstadoNot1()
        {
            return GetAll().Where(x => x.EstadoId != 1).ToList();
        }
        public static List<ConfiguracionCateringTecnica> GetAllEstadoN(int estado)
        {
            return GetAll().Where(x => x.EstadoId == estado).ToList();
        }
        public static List<ConfiguracionCateringTecnica> GetAllEstadoNotN(int estado)
        {
            return GetAll().Where(x => x.EstadoId != estado).ToList();
        }


        public class MaxLength
        {


        }

        public static ConfiguracionCateringTecnica Save(ConfiguracionCateringTecnica configuracionCateringTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoConfiguracionCateringTecnicaSave")) throw new PermisoException();
            if (configuracionCateringTecnica.Id == -1) return Insert(configuracionCateringTecnica);
            else return Update(configuracionCateringTecnica);
        }

        public static ConfiguracionCateringTecnica Insert(ConfiguracionCateringTecnica configuracionCateringTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoConfiguracionCateringTecnicaSave")) throw new PermisoException();
            string sql = "insert into ConfiguracionCateringTecnica(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ConfiguracionCateringTecnica).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(configuracionCateringTecnica, null));
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
            configuracionCateringTecnica.Id = Convert.ToInt32(resp);
            return configuracionCateringTecnica;
        }

        public static ConfiguracionCateringTecnica Update(ConfiguracionCateringTecnica configuracionCateringTecnica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoConfiguracionCateringTecnicaSave")) throw new PermisoException();
            string sql = "update ConfiguracionCateringTecnica set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(ConfiguracionCateringTecnica).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(configuracionCateringTecnica, null));
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
            sql += " where Id = " + configuracionCateringTecnica.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return configuracionCateringTecnica;
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
