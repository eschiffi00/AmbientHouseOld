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
		public int ItemId { get; set; }
		public string CategoriaId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ItemId: " + ItemId.ToString() + "\r\n " ;
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
				case "ItemId": return false;
				case "CategoriaId": return false;

				default: return false;
			}
		}
    }
}

