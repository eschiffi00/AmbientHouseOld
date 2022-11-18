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
    public partial class EMPLEADODEPARTAMENTOOperator
    {

        public static EMPLEADODEPARTAMENTO GetOneByIdentity(int )
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEMPLEADODEPARTAMENTOBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from EMPLEADODEPARTAMENTO where  = " + .ToString()).Tables[0];
            EMPLEADODEPARTAMENTO eMPLEADODEPARTAMENTO = new EMPLEADODEPARTAMENTO();
            foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(eMPLEADODEPARTAMENTO, value, null); }
                catch (System.ArgumentException) { }
            }
            return eMPLEADODEPARTAMENTO;
        }

        public static List<EMPLEADODEPARTAMENTO> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEMPLEADODEPARTAMENTOBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<EMPLEADODEPARTAMENTO> lista = new List<EMPLEADODEPARTAMENTO>();
            DataTable dt = db.GetDataSet("select " + columnas + " from EMPLEADODEPARTAMENTO").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                EMPLEADODEPARTAMENTO eMPLEADODEPARTAMENTO = new EMPLEADODEPARTAMENTO();
                foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties())
                {
					object value = dr[prop.Name];
					if (value == DBNull.Value) value = null;
					try { prop.SetValue(eMPLEADODEPARTAMENTO, value, null); }
					catch (System.ArgumentException) { }
                }
                lista.Add(eMPLEADODEPARTAMENTO);
            }
            return lista;
        }
        public static EMPLEADODEPARTAMENTO GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEMPLEADODEPARTAMENTOBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            string tipo = string.Empty;

        foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties())
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
            DataTable dt = db.GetDataSet("select " + columnas + " from EMPLEADODEPARTAMENTO where  " + campo + " = \'" + valor + "\'").Tables[0];
            EMPLEADODEPARTAMENTO EMPLEADODEPARTAMENTO = new EMPLEADODEPARTAMENTO();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(EMPLEADODEPARTAMENTO, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return EMPLEADODEPARTAMENTO;
        }
        public static List<EMPLEADODEPARTAMENTO> GetAllByParameter(string campo, string valor)
            {
                if (!DbEntidades.Seguridad.Permiso("PermisoEMPLEADODEPARTAMENTOBrowse")) throw new PermisoException();
                string columnas = string.Empty;
                var tipo = string.Empty;
                foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties())
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
                    queryStr = "select " + columnas + " from EMPLEADODEPARTAMENTO where " + campo + " = \'" + valor.ToString() + "\'";
                }
                else
                {
                    queryStr = "select " + columnas + " from EMPLEADODEPARTAMENTO where " + campo + " = " + valor.ToString();
                }
                DataTable dt = db.GetDataSet(queryStr).Tables[0];
                List<EMPLEADODEPARTAMENTO> lista = new List<EMPLEADODEPARTAMENTO>();
                foreach (DataRow dr in dt.AsEnumerable())
                {

                    EMPLEADODEPARTAMENTO entidad = new EMPLEADODEPARTAMENTO();
                    foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties())
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
			public static int ApellidoNombre { get; set; } = 50;


        }

        public static EMPLEADODEPARTAMENTO Save(EMPLEADODEPARTAMENTO eMPLEADODEPARTAMENTO)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEMPLEADODEPARTAMENTOSave")) throw new PermisoException();
            if (eMPLEADODEPARTAMENTO. == -1) return Insert(eMPLEADODEPARTAMENTO);
            else return Update(eMPLEADODEPARTAMENTO);
        }

        public static EMPLEADODEPARTAMENTO Insert(EMPLEADODEPARTAMENTO eMPLEADODEPARTAMENTO)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEMPLEADODEPARTAMENTOSave")) throw new PermisoException();
            string sql = "insert into EMPLEADODEPARTAMENTO(";
            string columnas = string.Empty;
            string valores = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + ", ";
                valores += "@" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(eMPLEADODEPARTAMENTO, null));
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            valores = valores.Substring(0, valores.Length - 2);
            sql += columnas + ") output inserted. values (" + valores + ")";
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
            eMPLEADODEPARTAMENTO. = Convert.ToInt32(resp);
            return eMPLEADODEPARTAMENTO;
        }

        public static EMPLEADODEPARTAMENTO Update(EMPLEADODEPARTAMENTO eMPLEADODEPARTAMENTO)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoEMPLEADODEPARTAMENTOSave")) throw new PermisoException();
            string sql = "update EMPLEADODEPARTAMENTO set ";
            string columnas = string.Empty;
            List<object> param = new List<object>();
            List<object> valor = new List<object>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            foreach (PropertyInfo prop in typeof(EMPLEADODEPARTAMENTO).GetProperties())
            {
                if (prop.Name == "") continue; //es identity
                columnas += prop.Name + " = @" + prop.Name + ", ";
                param.Add("@" + prop.Name);
                valor.Add(prop.GetValue(eMPLEADODEPARTAMENTO, null));
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
            sql += " where  = " + eMPLEADODEPARTAMENTO.;
            DB db = new DB();
            //db.execute_scalar(sql, parametros.ToArray());
            object resp = db.ExecuteScalar(sql, sqlParams.ToArray());
            return eMPLEADODEPARTAMENTO;
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
