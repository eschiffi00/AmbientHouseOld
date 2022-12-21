using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class Items
    {
		public int Id { get; set; }
		public string Detalle { get; set; }
		public int CategoriaItemId { get; set; }
		public double Costo { get; set; }
		public double Margen { get; set; }
		public double Precio { get; set; }
		public int? EstadoId { get; set; }
		public int? ItemDetalleId { get; set; }
		public int? CuentaId { get; set; }
		public int? DepositoId { get; set; }
		public string TipoItem { get; set; }
		public int? NombreFantasiaId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Detalle: " + Detalle.ToString() + "\r\n " + 
			"CategoriaItemId: " + CategoriaItemId.ToString() + "\r\n " + 
			"Costo: " + Costo.ToString() + "\r\n " + 
			"Margen: " + Margen.ToString() + "\r\n " + 
			"Precio: " + Precio.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " + 
			"ItemDetalleId: " + ItemDetalleId.ToString() + "\r\n " + 
			"CuentaId: " + CuentaId.ToString() + "\r\n " + 
			"DepositoId: " + DepositoId.ToString() + "\r\n " + 
			"TipoItem: " + TipoItem.ToString() + "\r\n " + 
			"NombreFantasiaId: " + NombreFantasiaId.ToString() + "\r\n " ;
		}
        public Items()
        {
            Id = -1;
			Detalle = "";
			CategoriaItemId = 0;
			Costo = 0;
			Margen = 0;
			Precio = 0;
			EstadoId = 0;
			ItemDetalleId = 0;
			CuentaId = 0;
			DepositoId = 0;
			TipoItem = "";
			NombreFantasiaId = 0;

        }

		public CategoriasItem GetRelatedCategoriaItemId()
		{
			CategoriasItem categoriasItem = CategoriasItemOperator.GetOneByIdentity(CategoriaItemId);
			return categoriasItem;
		}



		public List<ProductosCateringItems> GetRelatedProductosCateringItemses()
		{
			return ProductosCateringItemsOperator.GetAll().Where(x => x.ItemId == Id).ToList();
		}
		public List<AdicionalesItems> GetRelatedAdicionalesItemses()
		{
			return AdicionalesItemsOperator.GetAll().Where(x => x.ItemId == Id).ToList();
		}


		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "Detalle": return false;
				case "CategoriaItemId": return false;
				case "Costo": return false;
				case "Margen": return false;
				case "Precio": return false;
				case "EstadoId": return true;
				case "ItemDetalleId": return true;
				case "CuentaId": return true;
				case "DepositoId": return true;
				case "TipoItem": return true;
				case "NombreFantasiaId": return true;
				default: return false;
			}
		}
    }
}

