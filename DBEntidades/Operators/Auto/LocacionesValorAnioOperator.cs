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
    public partial class LocacionesValorAnioOperator
    {

        public static LocacionesValorAnio GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesValorAnioBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(LocacionesValorAnio).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from LocacionesValorAnio where Id = " + Id.ToString()).Tables[0];
            LocacionesValorAnio locacionesValorAnio = new LocacionesValorAnio();
            foreach (PropertyInfo prop in typeof(LocacionesValorAnio).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(locacionesValorAnio, value, null); }
                catch (System.ArgumentException) { }
            }
            return locacionesValorAnio;
        }

        public static List<LocacionesValorAnio> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesValorAnioBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(LocacionesValorAnio).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<LocacionesValorAnio> lista = new List<LocacionesValorAnio>();
            DataTable dt = db.GetDataSet("select " + columnas + " from LocacionesValorAnio").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                LocacionesValorAnio locacionesValorAnio = new LocacionesValorAnio();
                foreach (PropertyInfo prop in typeof(LocacionesValorAnio).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(locacionesValorAnio, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(locacionesValorAnio);
            }
            return lista;
        }



        public class MaxLength
        {


        }

        public static LocacionesValorAnio Save(LocacionesValorAnio locacionesValorAnio)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesValorAnioSave")) throw new PermisoException();
            if (locacionesValorAnio.Id == -1) return Insert(locacionesValorAnio);
            else return Update(locacionesValorAnio);
        }

        public static LocacionesValorAnio Insert(LocacionesValorAnio locacionesValorAnio)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesValorAnioSave")) throw new PermisoException();
            string sql = "insert into LocacionesValorAnio(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(LocacionesValorAnio).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(locacionesValorAnio, null));
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
            locacionesValorAnio.Id = Convert.ToInt32(resp);
            return locacionesValorAnio;
        }

        public static LocacionesValorAnio Update(LocacionesValorAnio locacionesValorAnio)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoLocacionesValorAnioSave")) throw new PermisoException();
            string sql = "update LocacionesValorAnio set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(LocacionesValorAnio).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(locacionesValorAnio, null));
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
            sql += " where Id = " + locacionesValorAnio.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return locacionesValorAnio;
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
