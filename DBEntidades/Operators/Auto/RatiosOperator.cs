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
    public partial class RatiosOperator
    {

        public static Ratios GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios where Id = " + Id.ToString()).Tables[0];
            Ratios ratios = new Ratios();
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(ratios, value, null); }
                catch (System.ArgumentException) { }
            }
            return ratios;
        }

        public static List<Ratios> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<Ratios> lista = new List<Ratios>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Ratios ratios = new Ratios();
                foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(ratios, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(ratios);
            }
            return lista;
        }



        public class MaxLength
        {
			public static int TipoDependencia { get; set; } = 5;


        }

        public static Ratios Save(Ratios ratios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosSave")) throw new PermisoException();
            if (ratios.Id == -1) return Insert(ratios);
            else return Update(ratios);
        }

        public static Ratios Insert(Ratios ratios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosSave")) throw new PermisoException();
            string sql = "insert into Ratios(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(ratios, null));
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
            ratios.Id = Convert.ToInt32(resp);
            return ratios;
        }

        public static Ratios Update(Ratios ratios)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosSave")) throw new PermisoException();
            string sql = "update Ratios set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(ratios, null));
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
            sql += " where Id = " + ratios.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return ratios;
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
