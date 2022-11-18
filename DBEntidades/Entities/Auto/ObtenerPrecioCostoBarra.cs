using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerPrecioCostoBarra
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public int CantidadPersonas { get; set; }
		public decimal Precios { get; set; }
		public decimal Costo { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"CantidadPersonas: " + CantidadPersonas.ToString() + "\r\n " + 
			"Precios: " + Precios.ToString() + "\r\n " + 
			"Costo: " + Costo.ToString() + "\r\n " ;
		}
        public ObtenerPrecioCostoBarra()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "Descripcion": return false;
				case "CantidadPersonas": return false;
				case "Precios": return false;
				case "Costo": return true;
				default: return false;
			}
		}
    }
}

