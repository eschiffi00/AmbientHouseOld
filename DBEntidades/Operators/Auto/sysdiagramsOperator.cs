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
    public partial class sysdiagramsOperator
    {

        public static sysdiagrams GetOneByIdentity(int diagram_id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisosysdiagramsBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from sysdiagrams where diagram_id = " + diagram_id.ToString()).Tables[0];
            sysdiagrams _sysdiagrams = new sysdiagrams();
            foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(_sysdiagrams, value, null); }
                catch (System.ArgumentException) { }
            }
            return _sysdiagrams;
        }

        public static List<sysdiagrams> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisosysdiagramsBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<sysdiagrams> lista = new List<sysdiagrams>();
            DataTable dt = db.GetDataSet("select " + columnas + " from sysdiagrams").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                sysdiagrams _sysdiagrams = new sysdiagrams();
                foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(_sysdiagrams, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(_sysdiagrams);
            }
            return lista;
        }
        public static sysdiagrams GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisosysdiagramsBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties())
        {
            if (prop.Name == campo)
            {
                tipo = prop.PropertyType.Name.ToString();
            }
            if (prop.Name == "Delete")
            {
                columnas += "[" + prop.Name + "]" + ", ";
            }
            else
            {
                columnas += prop.Name + ", ";
            }

        }
        columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from sysdiagrams where  " + campo + " = \'" + valor + "\'").Tables[0];
            sysdiagrams sysdiagrams = new sysdiagrams();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(sysdiagrams, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return sysdiagrams;
        }
        public static List<sysdiagrams> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisosysdiagramsBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties())
                {
                    if (prop.Name == campo)
                    {
                        tipo = prop.PropertyType.Name.ToString();
                    }
                    if (prop.Name == "Delete")
                    {
                        columnas += "[" + prop.Name + "]" + ", ";
                    }
                    else
                    {
                        columnas += prop.Name + ", ";
                    }

                }
                columnas = columnas.Substring(0, columnas.Length - 2);
                DB db = new DB();
                var queryStr = string.Empty;
                if (tipo == "String")
                {
                    queryStr = "select " + columnas + " from sysdiagrams where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from sysdiagrams where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<sysdiagrams> lista = new List<sysdiagrams>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    sysdiagrams entidad = new sysdiagrams();
                    foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties())
                    {
                        object value = dr[prop.Name];
                        if (value == DBNull.Value) value = null;
                        try { prop.SetValue(entidad, value, null); }
                        catch (System.ArgumentException) { }
                    }
                    lista.Add(entidad);
                }
                return lista;
            }



        public class MaxLength
        {
			public static int name { get; set; } = 128;


        }

        public static sysdiagrams Save(sysdiagrams _sysdiagrams)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisosysdiagramsSave")) throw new PermisoException();
            if (_sysdiagrams.diagram_id == -1) return Insert(_sysdiagrams);
            else return Update(_sysdiagrams);
        }

        public static sysdiagrams Insert(sysdiagrams _sysdiagrams)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisosysdiagramsSave")) throw new PermisoException();
            string sql = "insert into sysdiagrams(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties())
            {
                if (prop.Name == "diagram_id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(_sysdiagrams, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            valores = valores.Substring(0, valores.Length - 2);
            sql += columnas + ") output inserted.diagram_id values (" + valores + ")";
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
            _sysdiagrams.diagram_id = Convert.ToInt32(resp);
            return _sysdiagrams;
        }

        public static sysdiagrams Update(sysdiagrams _sysdiagrams)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisosysdiagramsSave")) throw new PermisoException();
            string sql = "update sysdiagrams set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(sysdiagrams).GetProperties())
            {
                if (prop.Name == "diagram_id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(_sysdiagrams, null));
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
            sql += " where diagram_id = " + _sysdiagrams.diagram_id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return _sysdiagrams;
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
