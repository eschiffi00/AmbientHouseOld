using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class TipoCateringOperator
    {
        public static List<TipoCateringComun> GetAllForCombo()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoCatering).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<TipoCateringComun> lista = new List<TipoCateringComun>();
            DataTable dt = db.GetDataSet("select " + columnas + " from TipoCatering").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                TipoCatering TipoCatering = new TipoCatering();
                foreach (PropertyInfo prop in typeof(TipoCatering).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(TipoCatering, value, null); }
                    catch (System.ArgumentException) { }
                }
                TipoCateringComun TipoCateringComun = new TipoCateringComun();
                TipoCateringComun.Id = TipoCatering.Id;
                TipoCateringComun.Descripcion = TipoCatering.Descripcion;
                lista.Add(TipoCateringComun);
            }
            return lista;
        }

        
        public static bool TipoCateringValidation(string campo, string valor)
        {
            bool result = false;
            if (!DbEntidades.Seguridad.Permiso("PermisoTipoCateringBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            var tipo = string.Empty;
            foreach (PropertyInfo prop in typeof(TipoCatering).GetProperties())
            {
                if (prop.Name == campo)
                {
                    tipo = prop.PropertyType.Name.ToString();
                }
                columnas += prop.Name + ", ";
            }
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            var queryStr = string.Empty;
            if (tipo == "String")
            {
                queryStr = "select " + columnas + " from TipoCatering where " + campo + " = \'" + valor.ToString() + "\'";
            }
            else
            {
                queryStr = "select " + columnas + " from TipoCatering where " + campo + " = " + valor.ToString();
            }
            DataTable dt = db.GetDataSet(queryStr).Tables[0];

            if (dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
