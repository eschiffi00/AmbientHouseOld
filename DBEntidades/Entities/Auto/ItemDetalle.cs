using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ItemDetalle
    {
		public int Id { get; set; }
		public int? ItemId { get; set; }
		public int? DetalleItemId { get; set; }
		public int? EstadoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ItemId: " + ItemId.ToString() + "\r\n " + 
			"DetalleItemId: " + DetalleItemId.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " ;
		}
        public ItemDetalle()
        {
            Id = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "ItemId": return true;
				case "DetalleItemId": return true;
				case "EstadoId": return true;
				default: return false;
			}
		}
    }
}

