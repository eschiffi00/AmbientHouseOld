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
    public partial class TABLA_RetencionesOperator
    {

        public static TABLA_Retenciones GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTABLA_RetencionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from TABLA_Retenciones where Id = " + Id.ToString()).Tables[0];
            TABLA_Retenciones tABLA_Retenciones = new TABLA_Retenciones();
            foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(tABLA_Retenciones, value, null); }
                catch (System.ArgumentException) { }
            }
            return tABLA_Retenciones;
        }

        public static List<TABLA_Retenciones> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTABLA_RetencionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TABLA_Retenciones> lista = new List<TABLA_Retenciones>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TABLA_Retenciones").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TABLA_Retenciones tABLA_Retenciones = new TABLA_Retenciones();
                foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(tABLA_Retenciones, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(tABLA_Retenciones);
            }
            return lista;
        }
        public static TABLA_Retenciones GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTABLA_RetencionesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from TABLA_Retenciones where  " + campo + " = \'" + valor + "\'").Tables[0];
            TABLA_Retenciones TABLA_Retenciones = new TABLA_Retenciones();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(TABLA_Retenciones, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return TABLA_Retenciones;
        }
        public static List<TABLA_Retenciones> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoTABLA_RetencionesBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties())
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
                    queryStr = "select " + columnas + " from TABLA_Retenciones where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from TABLA_Retenciones where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<TABLA_Retenciones> lista = new List<TABLA_Retenciones>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    TABLA_Retenciones entidad = new TABLA_Retenciones();
                    foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties())
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
			public static int Concepto { get; set; } = 100;


        }

        public static TABLA_Retenciones Save(TABLA_Retenciones tABLA_Retenciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTABLA_RetencionesSave")) throw new PermisoException();
            if (tABLA_Retenciones.Id == -1) return Insert(tABLA_Retenciones);
            else return Update(tABLA_Retenciones);
        }

        public static TABLA_Retenciones Insert(TABLA_Retenciones tABLA_Retenciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTABLA_RetencionesSave")) throw new PermisoException();
            string sql = "insert into TABLA_Retenciones(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tABLA_Retenciones, null));
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
            tABLA_Retenciones.Id = Convert.ToInt32(resp);
            return tABLA_Retenciones;
        }

        public static TABLA_Retenciones Update(TABLA_Retenciones tABLA_Retenciones)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTABLA_RetencionesSave")) throw new PermisoException();
            string sql = "update TABLA_Retenciones set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(TABLA_Retenciones).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(tABLA_Retenciones, null));
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
            sql += " where Id = " + tABLA_Retenciones.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return tABLA_Retenciones;
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
