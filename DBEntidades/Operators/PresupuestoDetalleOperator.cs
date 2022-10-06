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
    public partial class PresupuestoDetalleOperator
    {

        public static PresupuestoDetalle GetOneByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestoDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(PresupuestoDetalle).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from PresupuestoDetalle where " + campo + " = " + valor.ToString()).Tables[0];
            PresupuestoDetalle presupuestoDetalle = new PresupuestoDetalle();
            foreach (PropertyInfo prop in typeof(PresupuestoDetalle).GetProperties())
            {
				object value = dt.Rows[0][prop.Name];
				if (value == DBNull.Value) value = null;
                try { prop.SetValue(presupuestoDetalle, value, null); }
                catch (System.ArgumentException) { }
            }
            return presupuestoDetalle;
        }

        public static List<PresupuestoDetalle> GetAllByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoPresupuestoDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            var tipo = string.Empty;
            foreach (PropertyInfo prop in typeof(PresupuestoDetalle).GetProperties())
            {
                if(prop.Name == campo)
                {
                    tipo = prop.PropertyType.Name.ToString();
                }
                if(prop.Name == "Delete")
                {
                    columnas += "["+prop.Name+"]" + ", ";
                }
                else
                {
                    columnas += prop.Name + ", ";
                }
                
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            var queryStr = string.Empty;
            if(tipo == "String")
            {
                queryStr = "select " + columnas + " from PresupuestoDetalle where " + campo + " = \'" + valor.ToString() + "\'";
            }
            else
            {
                queryStr = "select " + columnas + " from PresupuestoDetalle where " + campo + " = " + valor.ToString();
            }
            DataTable dt = db.GetDataSet(queryStr).Tables[0];
            List<PresupuestoDetalle> lista = new List<PresupuestoDetalle>();
            foreach (DataRow dr in dt.AsEnumerable())
            {

                PresupuestoDetalle comprobante = new PresupuestoDetalle();
                foreach (PropertyInfo prop in typeof(PresupuestoDetalle).GetProperties())
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
