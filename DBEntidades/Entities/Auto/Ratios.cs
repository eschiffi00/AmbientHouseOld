using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class Ratios
    {
		public int Id { get; set; }
		public int ItemId { get; set; }
		public int CategoriaId { get; set; }
		public string TipoRatio { get; set; }
		public string DetalleTipo { get; set; }
		public double? ValorRatio { get; set; }
		public double? TopeRatio { get; set; }
		public int Menores { get; set; }
		public int AdicionalRatio { get; set; }
		public int EstadoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ItemId: " + ItemId.ToString() + "\r\n " + 
			"CategoriaId: " + CategoriaId.ToString() + "\r\n " + 
			"TipoRatio: " + TipoRatio.ToString() + "\r\n " + 
			"DetalleTipo: " + DetalleTipo.ToString() + "\r\n " + 
			"ValorRatio: " + ValorRatio.ToString() + "\r\n " + 
			"TopeRatio: " + TopeRatio.ToString() + "\r\n " + 
			"Menores: " + Menores.ToString() + "\r\n " + 
			"AdicionalRatio: " + AdicionalRatio.ToString() + "\r\n " +
            "EstadoId: " + EstadoId.ToString() + "\r\n " ;
		}
        public Ratios()
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
				case "TipoRatio": return false;
				case "DetalleTipo": return false;
				case "ValorRatio": return false;
				case "TopeRatio": return false;
				case "Menores": return false;
				case "AdicionalRatio": return false;
				default: return false;
			}
		}
    }
}

