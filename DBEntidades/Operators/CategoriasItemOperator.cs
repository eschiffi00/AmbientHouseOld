using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class CategoriasItemOperator
    {
        public static DataTable GetAllWithGroups()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoCategoriasItemBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(CategoriasItem).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<CategoriasItem> lista = new List<CategoriasItem>();
            DataTable dt = db.GetDataSet("select " + columnas + " from CategoriasItem").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                CategoriasItem categoriasItem = new CategoriasItem();
                foreach (PropertyInfo prop in typeof(CategoriasItem).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(categoriasItem, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(categoriasItem);
            }
            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[3] { new DataColumn("Value"), new DataColumn("Text"), new DataColumn("Categoria") });
            var categoria = "";
            foreach (var item in lista)
            {
                if (item.CategoriaItemPadreId != null)
                {
                    categoria = CategoriasItemOperator.GetOneByIdentity(item.CategoriaItemPadreId.Value).Descripcion;
                }
                else
                {
                    categoria = item.Descripcion;
                }

                dt2.Rows.Add(item.Id, item.Descripcion, categoria);
            }

            return dt2;
        }

        //public static CategoriasItem GetOneByParameter(string campo, string valor)
        //{
        //    if (!DbEntidades.Seguridad.Permiso("PermisoCategoriasItemBrowse")) throw new PermisoException();
        //    string columnas = string.Empty;
        //    foreach (PropertyInfo prop in typeof(CategoriasItem).GetProperties()) columnas += prop.Name + ", ";
        //    columnas = columnas.Substring(0, columnas.Length - 2);
        //    DB db = new DB();
        //    DataTable dt = db.GetDataSet("select " + columnas + " from CategoriasItem where  " + campo + " = \'" + valor + "\'").Tables[0];
        //    CategoriasItem CategoriasItem = new CategoriasItem();
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (PropertyInfo prop in typeof(CategoriasItem).GetProperties())
        //        {
        //            object value = dt.Rows[0][prop.Name];
        //            if (value == DBNull.Value) value = null;
        //            try { prop.SetValue(CategoriasItem, value, null); }
        //            catch (System.ArgumentException) { }
        //        }
        //    }
        //    return CategoriasItem;
        //}

    }
}
