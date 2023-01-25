using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
	public partial class ComandaDetalle
	{
		public int Id { get; set; }
		public int ComandaId { get; set; }	
		public string Clave { get; set; }
		public int? ItemId { get; set; }
		public double? Cantidad { get; set; }
		public int? EsItem { get; set; }
		public int? EsProducto { get; set; }
		public int? EsAdicional { get; set; }
		public int? Orden { get; set; }

		public override string ToString()
		{
			return "\r\n " +
			"Id: " + Id.ToString() + "\r\n " +
            "ComandaId: " + Clave.ToString() + "\r\n " +
			"Clave: " + Clave.ToString() + "\r\n " +
			"ItemId: " + ItemId.ToString() + "\r\n " +
			"Cantidad: " + Cantidad.ToString() + "\r\n " +
			"EsItem: " + EsItem.ToString() + "\r\n " +
			"EsProducto: " + EsProducto.ToString() + "\r\n " +
			"EsAdicional: " + EsAdicional.ToString() + "\r\n "+
			"Orden: " + Orden.ToString() + "\r\n ";
		}
		public ComandaDetalle()
		{
			Id = -1;
			ComandaId = 0;
			Clave = " ";
            ItemId = 0;
            Cantidad = 0;
            EsItem = 0;
            EsProducto = 0;
            EsAdicional = 0;
            Orden = 0;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName)
			{
				case "Id": return false;
				case "ComandaId": return false;
				case "Clave": return false;
				case "ItemId": return true;
				case "Cantidad": return true;
				case "EsItem": return true;
				case "EsProducto": return true;
				case "EsAdicional": return true;
				case "Orden": return true;
				default: return false;
			}
		}
	}
	public partial class ComandaDetalleDescripcion
	{
		public int ItemId { get; set; }
		public int ProductoId { get; set; }
		public int CategoriaId { get; set; }
		public string Descripcion { get; set; }
		public int Tiempo { get; set; }
	}
}

