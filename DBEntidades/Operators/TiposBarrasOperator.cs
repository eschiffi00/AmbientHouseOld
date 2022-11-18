using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class TiposBarrasOperator
    {
        public static List<TiposBarrasComun> GetAllForCombo()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TiposBarras).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TiposBarrasComun> lista = new List<TiposBarrasComun>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TiposBarras").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TiposBarras TiposBarras = new TiposBarras();
                foreach (PropertyInfo prop in typeof(TiposBarras).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(TiposBarras, value, null); }
                    catch (System.ArgumentException) { }
                }
                TiposBarrasComun TiposBarrasComun = new TiposBarrasComun();
                TiposBarrasComun.Id = TiposBarras.Id;
                TiposBarrasComun.Descripcion = TiposBarras.Descripcion;
                lista.Add(TiposBarrasComun);
            }
            return lista;
        }
        
    }
}
