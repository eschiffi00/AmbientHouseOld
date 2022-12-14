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
    public partial class CostoLogisticaOperator
    {

        public static CostoLogistica GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCostoLogisticaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from CostoLogistica where Id = " + Id.ToString()).Tables[0];
            CostoLogistica costoLogistica = new CostoLogistica();
            foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(costoLogistica, value, null); }
                catch (System.ArgumentException) { }
            }
            return costoLogistica;
        }

        public static List<CostoLogistica> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCostoLogisticaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<CostoLogistica> lista = new List<CostoLogistica>();
            DataTable dt = db.GetDataSet("select " + columnas + " from CostoLogistica").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                CostoLogistica costoLogistica = new CostoLogistica();
                foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(costoLogistica, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(costoLogistica);
            }
            return lista;
        }
        public static CostoLogistica GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCostoLogisticaBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from CostoLogistica where  " + campo + " = \'" + valor + "\'").Tables[0];
            CostoLogistica CostoLogistica = new CostoLogistica();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(CostoLogistica, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return CostoLogistica;
        }
        public static List<CostoLogistica> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoCostoLogisticaBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties())
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
                    queryStr = "select " + columnas + " from CostoLogistica where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from CostoLogistica where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<CostoLogistica> lista = new List<CostoLogistica>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    CostoLogistica entidad = new CostoLogistica();
                    foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties())
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

        public static CostoLogistica Save(CostoLogistica costoLogistica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCostoLogisticaSave")) throw new PermisoException();
            if (costoLogistica.Id == -1) return Insert(costoLogistica);
            else return Update(costoLogistica);
        }

        public static CostoLogistica Insert(CostoLogistica costoLogistica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCostoLogisticaSave")) throw new PermisoException();
            string sql = "insert into CostoLogistica(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(costoLogistica, null));
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
            costoLogistica.Id = Convert.ToInt32(resp);
            return costoLogistica;
        }

        public static CostoLogistica Update(CostoLogistica costoLogistica)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCostoLogisticaSave")) throw new PermisoException();
            string sql = "update CostoLogistica set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(CostoLogistica).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(costoLogistica, null));
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
            sql += " where Id = " + costoLogistica.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return costoLogistica;
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
