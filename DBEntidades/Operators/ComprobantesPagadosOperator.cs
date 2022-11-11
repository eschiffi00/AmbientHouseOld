using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class ComprobantesPagadosOperator
    {

        public static ComprobantesPagados GetOneByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesPagados where " + campo + " = " + valor.ToString()).Tables[0];
            ComprobantesPagados ComprobantesPagados = new ComprobantesPagados();
            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(ComprobantesPagados, value, null); }
                catch (System.ArgumentException) { }
            }
            return ComprobantesPagados;
        }
        public static List<ComprobantesPagados> GetAllByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoComprobantesPagadosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ComprobantesPagados where " + campo + " = " + valor.ToString()).Tables[0];
            List<ComprobantesPagados> lista = new List<ComprobantesPagados>();
            foreach (DataRow dr in dt.AsEnumerable())
            {

                ComprobantesPagados comprobante = new ComprobantesPagados();
                foreach (PropertyInfo prop in typeof(ComprobantesPagados).GetProperties())
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
