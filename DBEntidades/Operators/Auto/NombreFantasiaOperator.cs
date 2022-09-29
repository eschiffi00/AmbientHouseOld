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
    public partial class NombreFantasiaOperator
    {

        public static NombreFantasia GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNombreFantasiaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(NombreFantasia).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from NombreFantasia where Id = " + Id.ToString()).Tables[0];
            NombreFantasia nombreFantasia = new NombreFantasia();
            foreach (PropertyInfo prop in typeof(NombreFantasia).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(nombreFantasia, value, null); }
                catch (System.ArgumentException) { }
            }
            return nombreFantasia;
        }

        public static List<NombreFantasia> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNombreFantasiaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(NombreFantasia).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<NombreFantasia> lista = new List<NombreFantasia>();
            DataTable dt = db.GetDataSet("select " + columnas + " from NombreFantasia").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                NombreFantasia nombreFantasia = new NombreFantasia();
                foreach (PropertyInfo prop in typeof(NombreFantasia).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(nombreFantasia, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(nombreFantasia);
            }
            return lista;
        }



        public class MaxLength
        {
			public static int Descripcion { get; set; } = 100;


        }

        public static NombreFantasia Save(NombreFantasia nombreFantasia)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNombreFantasiaSave")) throw new PermisoException();
            if (nombreFantasia.Id == -1) return Insert(nombreFantasia);
            else return Update(nombreFantasia);
        }

        public static NombreFantasia Insert(NombreFantasia nombreFantasia)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNombreFantasiaSave")) throw new PermisoException();
            string sql = "insert into NombreFantasia(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(NombreFantasia).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(nombreFantasia, null));
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
            nombreFantasia.Id = Convert.ToInt32(resp);
            return nombreFantasia;
        }

        public static NombreFantasia Update(NombreFantasia nombreFantasia)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoNombreFantasiaSave")) throw new PermisoException();
            string sql = "update NombreFantasia set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(NombreFantasia).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(nombreFantasia, null));
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
            sql += " where Id = " + nombreFantasia.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return nombreFantasia;
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
