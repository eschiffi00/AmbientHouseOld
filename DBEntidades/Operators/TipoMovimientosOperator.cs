using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class TipoMovimientosOperator
    {
        
        public static TipoMovimientos GetOneByStrParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoMovimientosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoMovimientos).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoMovimientos where " + campo + " = \'" + valor.ToString() + "\'").Tables[0];
            TipoMovimientos TipoMovimientos = new TipoMovimientos();
            foreach (PropertyInfo prop in typeof(TipoMovimientos).GetProperties())
            {
                object value = dt.Rows[0][prop.Name];
                if (value == DBNull.Value) value = null;
                try { prop.SetValue(TipoMovimientos, value, null); }
                catch (System.ArgumentException) { }
            }
            return TipoMovimientos;
        }
        

    }
}
