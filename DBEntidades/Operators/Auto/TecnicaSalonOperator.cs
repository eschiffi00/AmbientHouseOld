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
    public partial class TecnicaSalonOperator
    {

        public static TecnicaSalon GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTecnicaSalonBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from TecnicaSalon where Id = " + Id.ToString()).Tables[0];
            TecnicaSalon tecnicaSalon = new TecnicaSalon();
            foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(tecnicaSalon, value, null); }
                catch (System.ArgumentException) { }
            }
            return tecnicaSalon;
        }

        public static List<TecnicaSalon> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTecnicaSalonBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TecnicaSalon> lista = new List<TecnicaSalon>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TecnicaSalon").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TecnicaSalon tecnicaSalon = new TecnicaSalon();
                foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(tecnicaSalon, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(tecnicaSalon);
            }
            return lista;
        }
        public static TecnicaSalon GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTecnicaSalonBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from TecnicaSalon where  " + campo + " = \'" + valor + "\'").Tables[0];
            TecnicaSalon TecnicaSalon = new TecnicaSalon();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(TecnicaSalon, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return TecnicaSalon;
        }
        public static List<TecnicaSalon> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoTecnicaSalonBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties())
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
                    queryStr = "select " + columnas + " from TecnicaSalon where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from TecnicaSalon where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<TecnicaSalon> lista = new List<TecnicaSalon>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    TecnicaSalon entidad = new TecnicaSalon();
                    foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties())
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


        }

        public static TecnicaSalon Save(TecnicaSalon tecnicaSalon)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTecnicaSalonSave")) throw new PermisoException();
            if (tecnicaSalon.Id == -1) return Insert(tecnicaSalon);
            else return Update(tecnicaSalon);
        }

        public static TecnicaSalon Insert(TecnicaSalon tecnicaSalon)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTecnicaSalonSave")) throw new PermisoException();
            string sql = "insert into TecnicaSalon(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tecnicaSalon, null));
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
            tecnicaSalon.Id = Convert.ToInt32(resp);
            return tecnicaSalon;
        }

        public static TecnicaSalon Update(TecnicaSalon tecnicaSalon)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTecnicaSalonSave")) throw new PermisoException();
            string sql = "update TecnicaSalon set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TecnicaSalon).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tecnicaSalon, null));
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
            sql += " where Id = " + tecnicaSalon.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return tecnicaSalon;
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
