using DbEntidades.Entities;
using LibDB2;
using System;
using System.Data;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class CuentasOperator
    {
        public static Cuentas GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCuentasBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Cuentas).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Cuentas where  " + campo + " = \'" + valor + "\'").Tables[0];
            Cuentas Cuentas = new Cuentas();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(Cuentas).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(Cuentas, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return Cuentas;
        }
    }
}
