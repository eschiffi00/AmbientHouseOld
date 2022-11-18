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
    public partial class INVENTARIO_DepositosOperator
    {

        public static INVENTARIO_Depositos GetOneByIdentity(int Id)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_DepositosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Depositos where Id = " + Id.ToString()).Tables[0];
            INVENTARIO_Depositos iNVENTARIO_Depositos = new INVENTARIO_Depositos();
            foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(iNVENTARIO_Depositos, value, null); }
                catch (System.ArgumentException) { }
            }
            return iNVENTARIO_Depositos;
        }

        public static List<INVENTARIO_Depositos> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_DepositosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<INVENTARIO_Depositos> lista = new List<INVENTARIO_Depositos>();
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Depositos").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                INVENTARIO_Depositos iNVENTARIO_Depositos = new INVENTARIO_Depositos();
                foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(iNVENTARIO_Depositos, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(iNVENTARIO_Depositos);
            }
            return lista;
        }
        public static INVENTARIO_Depositos GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_DepositosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from INVENTARIO_Depositos where  " + campo + " = \'" + valor + "\'").Tables[0];
            INVENTARIO_Depositos INVENTARIO_Depositos = new INVENTARIO_Depositos();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(INVENTARIO_Depositos, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return INVENTARIO_Depositos;
        }
        public static List<INVENTARIO_Depositos> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_DepositosBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties())
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
                    queryStr = "select " + columnas + " from INVENTARIO_Depositos where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from INVENTARIO_Depositos where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<INVENTARIO_Depositos> lista = new List<INVENTARIO_Depositos>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    INVENTARIO_Depositos entidad = new INVENTARIO_Depositos();
                    foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties())
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

        public static INVENTARIO_Depositos Save(INVENTARIO_Depositos iNVENTARIO_Depositos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_DepositosSave")) throw new PermisoException();
            if (iNVENTARIO_Depositos.Id == -1) return Insert(iNVENTARIO_Depositos);
            else return Update(iNVENTARIO_Depositos);
        }

        public static INVENTARIO_Depositos Insert(INVENTARIO_Depositos iNVENTARIO_Depositos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_DepositosSave")) throw new PermisoException();
            string sql = "insert into INVENTARIO_Depositos(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(iNVENTARIO_Depositos, null));
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
            iNVENTARIO_Depositos.Id = Convert.ToInt32(resp);
            return iNVENTARIO_Depositos;
        }

        public static INVENTARIO_Depositos Update(INVENTARIO_Depositos iNVENTARIO_Depositos)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoINVENTARIO_DepositosSave")) throw new PermisoException();
            string sql = "update INVENTARIO_Depositos set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(INVENTARIO_Depositos).GetProperties())
            {
                if (prop.Name == "Id") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(iNVENTARIO_Depositos, null));
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
            sql += " where Id = " + iNVENTARIO_Depositos.Id;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return iNVENTARIO_Depositos;
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
