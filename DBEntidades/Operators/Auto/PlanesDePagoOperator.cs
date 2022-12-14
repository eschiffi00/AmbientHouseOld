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
    public partial class PlanesDePagoOperator
    {

        public static PlanesDePago GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPlanesDePagoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from PlanesDePago where Id = " + Id.ToString()).Tables[0];
            PlanesDePago planesDePago = new PlanesDePago();
            foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(planesDePago, value, null); }
                catch (System.ArgumentException) { }
            }
            return planesDePago;
        }

        public static List<PlanesDePago> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPlanesDePagoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<PlanesDePago> lista = new List<PlanesDePago>();
            DataTable dt = db.GetDataSet("select " + columnas + " from PlanesDePago").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                PlanesDePago planesDePago = new PlanesDePago();
                foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(planesDePago, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(planesDePago);
            }
            return lista;
        }
        public static PlanesDePago GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPlanesDePagoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from PlanesDePago where  " + campo + " = \'" + valor + "\'").Tables[0];
            PlanesDePago PlanesDePago = new PlanesDePago();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(PlanesDePago, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return PlanesDePago;
        }
        public static List<PlanesDePago> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoPlanesDePagoBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties())
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
                    queryStr = "select " + columnas + " from PlanesDePago where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from PlanesDePago where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<PlanesDePago> lista = new List<PlanesDePago>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    PlanesDePago entidad = new PlanesDePago();
                    foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties())
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
			public static int Descripcion { get; set; } = 100;


        }

        public static PlanesDePago Save(PlanesDePago planesDePago)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPlanesDePagoSave")) throw new PermisoException();
            if (planesDePago.Id == -1) return Insert(planesDePago);
            else return Update(planesDePago);
        }

        public static PlanesDePago Insert(PlanesDePago planesDePago)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPlanesDePagoSave")) throw new PermisoException();
            string sql = "insert into PlanesDePago(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(planesDePago, null));
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
            planesDePago.Id = Convert.ToInt32(resp);
            return planesDePago;
        }

        public static PlanesDePago Update(PlanesDePago planesDePago)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPlanesDePagoSave")) throw new PermisoException();
            string sql = "update PlanesDePago set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(PlanesDePago).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(planesDePago, null));
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
            sql += " where Id = " + planesDePago.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return planesDePago;
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
