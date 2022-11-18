using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class TABLA_Retenciones
    {
		public int Id { get; set; }
		public string Concepto { get; set; }
		public decimal PorcentajeInscripto { get; set; }
		public decimal PorcentajeNoInscripto { get; set; }
		public decimal ValorMaximoaRetenerInscriptos { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Concepto: " + Concepto.ToString() + "\r\n " + 
			"PorcentajeInscripto: " + PorcentajeInscripto.ToString() + "\r\n " + 
			"PorcentajeNoInscripto: " + PorcentajeNoInscripto.ToString() + "\r\n " + 
			"ValorMaximoaRetenerInscriptos: " + ValorMaximoaRetenerInscriptos.ToString() + "\r\n " ;
		}
        public TABLA_Retenciones()
        {
            Id = -1;

        }



		public List<ProveedoresRetenciones> GetRelatedProveedoresRetencioneses()
		{
			return ProveedoresRetencionesOperator.GetAll().Where(x => x.TablaRetencionId == Id).ToList();
		}


		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "Concepto": return false;
				case "PorcentajeInscripto": return true;
				case "PorcentajeNoInscripto": return true;
				case "ValorMaximoaRetenerInscriptos": return true;
				default: return false;
			}
		}
    }
}

