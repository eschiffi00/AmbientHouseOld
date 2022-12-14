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
    public partial class TipoComprobantesOperator
    {

        public static TipoComprobantes GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoComprobantesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoComprobantes where Id = " + Id.ToString()).Tables[0];
            TipoComprobantes tipoComprobantes = new TipoComprobantes();
            foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(tipoComprobantes, value, null); }
                catch (System.ArgumentException) { }
            }
            return tipoComprobantes;
        }

        public static List<TipoComprobantes> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoComprobantesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TipoComprobantes> lista = new List<TipoComprobantes>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoComprobantes").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TipoComprobantes tipoComprobantes = new TipoComprobantes();
                foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(tipoComprobantes, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(tipoComprobantes);
            }
            return lista;
        }
        public static TipoComprobantes GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoComprobantesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoComprobantes where  " + campo + " = \'" + valor + "\'").Tables[0];
            TipoComprobantes TipoComprobantes = new TipoComprobantes();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(TipoComprobantes, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return TipoComprobantes;
        }
        public static List<TipoComprobantes> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoTipoComprobantesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties())
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
                    queryStr = "select " + columnas + " from TipoComprobantes where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from TipoComprobantes where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<TipoComprobantes> lista = new List<TipoComprobantes>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    TipoComprobantes entidad = new TipoComprobantes();
                    foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties())
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
			public static int Descripcion { get; set; } = 500;


        }

        public static TipoComprobantes Save(TipoComprobantes tipoComprobantes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoComprobantesSave")) throw new PermisoException();
            if (tipoComprobantes.Id == -1) return Insert(tipoComprobantes);
            else return Update(tipoComprobantes);
        }

        public static TipoComprobantes Insert(TipoComprobantes tipoComprobantes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoComprobantesSave")) throw new PermisoException();
            string sql = "insert into TipoComprobantes(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoComprobantes, null));
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
            tipoComprobantes.Id = Convert.ToInt32(resp);
            return tipoComprobantes;
        }

        public static TipoComprobantes Update(TipoComprobantes tipoComprobantes)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoComprobantesSave")) throw new PermisoException();
            string sql = "update TipoComprobantes set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TipoComprobantes).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tipoComprobantes, null));
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
            sql += " where Id = " + tipoComprobantes.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return tipoComprobantes;
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
