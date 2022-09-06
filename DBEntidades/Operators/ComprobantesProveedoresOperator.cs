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
    public partial class ComprobantesProveedoresOperator
    {

        public static ComprobantesProveedores GetOneByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesProveedoresBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComprobantesProveedores_Detalles).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesProveedores where " + campo + " = " + valor.ToString()).Tables[0];
            ComprobantesProveedores comprobantesProveedores_Detalles = new ComprobantesProveedores();
            foreach (PropertyInfo prop in typeof(ComprobantesProveedores).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(comprobantesProveedores_Detalles, value, null); }
                catch (System.ArgumentException) { }
            }
            return comprobantesProveedores_Detalles;
        }
        public static List<ComprobantesProveedores> GetAllByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesProveedoresBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComprobantesProveedores).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesProveedores where " + campo + " = " + valor.ToString()).Tables[0];
            List<ComprobantesProveedores> lista = new List<ComprobantesProveedores>();
            foreach (DataRow dr in dt.AsEnumerable())
            {
                ComprobantesProveedores comprobante = new ComprobantesProveedores();
                foreach (PropertyInfo prop in typeof(ComprobantesProveedores).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(comprobante, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(comprobante);
            }
            return lista;
        }
    }
}
