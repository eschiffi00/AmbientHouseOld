using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class ItemDetalleOperator
    {
        public static void Delete(int Id)
        {
            string query = "delete from ItemDetalle where Id = " + Id.ToString();
            DB db = new DB();
            db.ExecuteNonQuery(query);
        }

        public static int GetOneRelative(int IdItem, int IdRel)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoItemDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ItemDetalle).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ItemDetalle where ItemId = " + IdItem.ToString() + "and ItemDetalleId = " + IdRel.ToString()).Tables[0];
            ItemDetalle itemDetalle = new ItemDetalle();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ItemDetalle).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(itemDetalle, value, null); }
                    catch (System.ArgumentException) { }
                }

            }
            return itemDetalle.Id;
        }
        public static List<ItemDetalle> GetAllByParameter(string campo, int valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoItemDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ItemDetalle).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ItemDetalle where " + campo + " = " + valor.ToString()).Tables[0];
            List<ItemDetalle> lista = new List<ItemDetalle>();
            foreach (DataRow dr in dt.AsEnumerable())
            {

                ItemDetalle comprobante = new ItemDetalle();
                foreach (PropertyInfo prop in typeof(ItemDetalle).GetProperties())
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

        public static ItemDetalle GetOneByParameter(string campo, string valor)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoItemDetalleBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(ItemDetalle).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from ItemDetalle where  " + campo + " = \'" + valor + "\'").Tables[0];
            ItemDetalle ItemDetalle = new ItemDetalle();
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(ItemDetalle).GetProperties())
                {
                    object value = dt.Rows[0][prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(ItemDetalle, value, null); }
                    catch (System.ArgumentException) { }
                }
            }
            return ItemDetalle;
        }
    }
}
