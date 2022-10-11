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
		public string TipoDependencia { get; set; }
		public string DetalleDependencia { get; set; }
		public int TopeRatio { get; set; }
		public int Menores { get; set; }
		public int AdicionalRatio { get; set; }
		public int EstadoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ItemId: " + ItemId.ToString() + "\r\n " + 
			"CategoriaId: " + CategoriaId.ToString() + "\r\n " + 
			"TipoDependencia: " + TipoDependencia.ToString() + "\r\n " + 
			"DetalleDependencia: " + DetalleDependencia.ToString() + "\r\n " + 
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
				case "TipoDependencia": return false;
				case "DetalleDependencia": return false;
				case "TopeRatio": return false;
				case "Menores": return false;
				case "AdicionalRatio": return false;
				default: return false;
			}
		}
    }
}

