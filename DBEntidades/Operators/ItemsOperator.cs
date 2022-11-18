using DbEntidades.Entities;
using LibDB2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DbEntidades.Operators
{
    public partial class ItemsOperator
    {
        public static List<ItemsListado> GetAllWithDetails()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Items).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ItemsListado> lista = new List<ItemsListado>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Items").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Items Items = new Items();
                foreach (PropertyInfo prop in typeof(Items).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(Items, value, null); }
                    catch (System.ArgumentException) { }
                }
                ItemsListado ItemsDetail = new ItemsListado();
                ItemsDetail.Id = Items.Id;
                ItemsDetail.Detalle = Items.Detalle;
                ItemsDetail.NombreFantasiaId = Items.NombreFantasiaId != null ? Items.NombreFantasiaId.Value : 0;
                if(ItemsDetail.NombreFantasiaId != 0 && ItemsDetail.NombreFantasiaId != -1)
                {
                    ItemsDetail.NombreFantasia = NombreFantasiaOperator.GetOneByIdentity(Items.NombreFantasiaId.Value).Descripcion != null ? NombreFantasiaOperator.GetOneByIdentity(Items.NombreFantasiaId.Value).Descripcion : "";
                }
                ItemsDetail.CategoriaItemId = Items.CategoriaItemId;
                ItemsDetail.CategoriaDescripcion = CategoriasItemOperator.GetOneByIdentity(Items.CategoriaItemId).Descripcion;

                ItemsDetail.CuentaId = Items.CuentaId;
                if (ItemsDetail.CuentaId == 0 || ItemsDetail.CuentaId == null)
                {
                    ItemsDetail.CuentaDescripcion = "";
                }
                else
                {
                    ItemsDetail.CuentaDescripcion = CentroCostosOperator.GetOneByIdentity((int)ItemsDetail.CuentaId).Descripcion;
                }
                ItemsDetail.Costo = Items.Costo;
                ItemsDetail.Margen = Items.Margen;
                ItemsDetail.Precio = Items.Precio;
                //ItemsDetail.DepositoId = Items.DepositoId;
                ItemsDetail.DepositoId = 1;
                //ItemsDetail.Unidad = INVENTARIO_UnidadesOperator.GetOneByIdentity(INVENTARIO_ProductoOperator.GetOneByIdentity(Items.DepositoId).UnidadId).Descripcion;
                //ItemsDetail.Cantidad = INVENTARIO_ProductoOperator.GetOneByIdentity(INVENTARIO_DepositosOperator.GetOneByIdentity(Items.DepositoId).Id).Cantidad;
                ItemsDetail.Unidad = "";
                ItemsDetail.Cantidad = 0;
                ItemsDetail.EstadoId = Items.EstadoId.Value;
                List<string> fields = new List<string>();
                List<string> values = new List<string>();

                fields.Add("ItemId");
                values.Add(Items.ItemDetalleId.ToString());
                if (Items.ItemDetalleId != 99 && Items.ItemDetalleId != 0 && Items.ItemDetalleId != null) 
                {
                    if (CommonOperator.CommonValidation("ItemDetalle", fields, values))
                    {
                        var commonOut = ItemDetalleOperator.GetAllByParameter("ItemId", Items.ItemDetalleId.ToString());
                        for (var i = 0; i < commonOut.Count - 1; i++)
                        {
                            if (i == commonOut.Count - 2)
                            {
                                ItemsDetail.ItemsAsociados = ItemsDetail.ItemsAsociados + ItemsOperator.GetOneByIdentity(commonOut[i].DetalleItemId.Value).Detalle;
                            }
                            else
                            {
                                ItemsDetail.ItemsAsociados = ItemsDetail.ItemsAsociados + ItemsOperator.GetOneByIdentity(commonOut[i].DetalleItemId.Value).Detalle + ",";
                            }
                        }
                    }
                }
                else
                {
                    ItemsDetail.ItemDetalleId = 0;
                }
                if (Items.EstadoId == 36)
                {
                    ItemsDetail.Estado = "Activo";
                }
                else { ItemsDetail.Estado = "Inactivo"; }

                lista.Add(ItemsDetail);
            }
            return lista;
        }
        public static List<ItemsCombo> GetAllForCombo()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Items).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<ItemsCombo> lista = new List<ItemsCombo>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Items").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Items Items = new Items();
                foreach (PropertyInfo prop in typeof(Items).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(Items, value, null); }
                    catch (System.ArgumentException) { }
                }
                ItemsCombo ItemsStock = new ItemsCombo();
                ItemsStock.Id = Items.Id;
                ItemsStock.Detalle = Items.Detalle;
                lista.Add(ItemsStock);
            }
            return lista;
        }
        public static void Delete(int id)
        {
            Items u = ItemsOperator.GetOneByIdentity(id);
            u.EstadoId = EstadosOperator.GetDeshabilitadoID("Items");
            Update(u);
        }
        
    }
}