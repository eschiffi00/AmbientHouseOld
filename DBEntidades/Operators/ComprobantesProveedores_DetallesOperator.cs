using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class ComprobantesProveedores_DetallesOperator
    {

        public static ComprobantesProveedores_Detalles GetOneByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesProveedores_DetallesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComprobantesProveedores_Detalles).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesProveedores_Detalles where " + campo + " = " + valor.ToString()).Tables[0];
            ComprobantesProveedores_Detalles comprobantesProveedores_Detalles = new ComprobantesProveedores_Detalles();
            foreach (PropertyInfo prop in typeof(ComprobantesProveedores_Detalles).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(comprobantesProveedores_Detalles, value, null); }
                catch (System.ArgumentException) { }
            }
            return comprobantesProveedores_Detalles;
        }
        public static List<ComprobantesProveedores_Detalles> GetAllByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesProveedores_DetallesBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComprobantesProveedores_Detalles).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesProveedores_Detalles where " + campo + " = " + valor.ToString()).Tables[0];
            List<ComprobantesProveedores_Detalles> lista = new List<ComprobantesProveedores_Detalles>();
            foreach (DataRow dr in dt.AsEnumerable())
            {

                ComprobantesProveedores_Detalles comprobante = new ComprobantesProveedores_Detalles();
                foreach (PropertyInfo prop in typeof(ComprobantesProveedores_Detalles).GetProperties())
                {
                    object value = dr[prop.Name];
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
