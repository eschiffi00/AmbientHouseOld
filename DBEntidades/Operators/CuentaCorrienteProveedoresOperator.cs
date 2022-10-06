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
    public partial class CuentaCorrienteProveedoresOperator
    {
        public static List<CuentaCorrienteProveedores> GetAll()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCuentaCorrienteProveedoresBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(CuentaCorrienteProveedores).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<CuentaCorrienteProveedores> lista = new List<CuentaCorrienteProveedores>();
            DataTable dt = db.GetDataSet("select " + columnas + " from CuentaCorrienteProveedoresGral()").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                CuentaCorrienteProveedores CuentaCorrienteProveedores = new CuentaCorrienteProveedores();
                foreach (PropertyInfo prop in typeof(CuentaCorrienteProveedores).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(CuentaCorrienteProveedores, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(CuentaCorrienteProveedores);
            }
            return lista;
        }
        public static CuentaCorrienteProveedores GetOneByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCuentaCorrienteProveedoresBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(CuentaCorrienteProveedores).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from CuentaCorrienteProveedoresGral() where " + campo + " = " + valor.ToString()).Tables[0];
            CuentaCorrienteProveedores CuentaCorrienteProveedores = new CuentaCorrienteProveedores();
            foreach (PropertyInfo prop in typeof(CuentaCorrienteProveedores).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(CuentaCorrienteProveedores, value, null); }
                catch (System.ArgumentException) { }
            }
            return CuentaCorrienteProveedores;
        }
        public static List<CuentaCorrienteProveedores> GetAllByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCuentaCorrienteProveedoresBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(CuentaCorrienteProveedores).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from CuentaCorrienteProveedoresGral() where " + campo + " = " + valor.ToString()).Tables[0];
            List<CuentaCorrienteProveedores> lista = new List<CuentaCorrienteProveedores>();
            foreach (DataRow dr in dt.AsEnumerable())
            {

                CuentaCorrienteProveedores comprobante = new CuentaCorrienteProveedores();
                foreach (PropertyInfo prop in typeof(CuentaCorrienteProveedores).GetProperties())
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
        public static List<CuentaCorrienteProveedores> FiltrarCuentaCorriente(parametros2 parametros)
        {
            List<CuentaCorrienteProveedores> list = GetAll();
            if (parametros.CuitProveedor != "")
            {
                list = list.Where(x => x.CuitProveedor == parametros.CuitProveedor).ToList();
            }
            if (parametros.NroPresupuesto != 0)
            {
                list = list.Where(x => x.NroPresupuesto == parametros.NroPresupuesto).ToList();
            }
            if(parametros.FechaDesde != "")
            {
                list = list.Where(x => x.FechaTransaccion > DateTime.Parse(parametros.FechaDesde)).ToList();
            }
            if(parametros.FechaHasta != "")
            {
                list = list.Where(x => x.FechaTransaccion < DateTime.Parse(parametros.FechaHasta)).ToList();
            }
            if (parametros.TipoMovimiento != "")
            {
                list = list.Where(x => x.TipoMovimiento == parametros.TipoMovimiento).ToList();
            }
            var comprobante = 0;
            var valormontofactura = 0.0;
            var importe = 0.0;
            List<CuentaCorrienteProveedores> listFiltro = new List<CuentaCorrienteProveedores>();
            CuentaCorrienteProveedores itemfiltro = new CuentaCorrienteProveedores();
            CuentaCorrienteProveedores itemfiltro2 = new CuentaCorrienteProveedores();
            foreach (var item in list)
            {
                
                if(Int32.Parse(item.NroComprobante) != comprobante)
                {
                    comprobante = Int32.Parse(item.NroComprobante);
                    valormontofactura = 0.0;
                    importe = 0.0;
                }
                if ((valormontofactura - importe) != item.SaldoPendiente && item.TipoTransaccion == "RESULTADO")
                {
                    listFiltro.Add(item);
                }
                valormontofactura += item.ValorNetoFactura;
                importe += item.ImporteSinIVA;
            }

            foreach(var x in listFiltro)
            {
                list.Remove(x);
            }

            return list;

        }
    }
}
