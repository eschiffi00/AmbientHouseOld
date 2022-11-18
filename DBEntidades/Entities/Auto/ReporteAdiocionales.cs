using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ReporteAdiocionales
    {
		public int NROEVENTO { get; set; }
		public int NROPRESUPUESTO { get; set; }
		public string FECHAEVENTO { get; set; }
		public string Rubro { get; set; }
		public string Descripcion { get; set; }
		public int? Cantidad { get; set; }
		public decimal ValorAdicional { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"NROEVENTO: " + NROEVENTO.ToString() + "\r\n " + 
			"NROPRESUPUESTO: " + NROPRESUPUESTO.ToString() + "\r\n " + 
			"FECHAEVENTO: " + FECHAEVENTO.ToString() + "\r\n " + 
			"Rubro: " + Rubro.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"Cantidad: " + Cantidad.ToString() + "\r\n " + 
			"ValorAdicional: " + ValorAdicional.ToString() + "\r\n " ;
		}
        public ReporteAdiocionales()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "NROEVENTO": return false;
				case "NROPRESUPUESTO": return false;
				case "FECHAEVENTO": return true;
				case "Rubro": return false;
				case "Descripcion": return false;
				case "Cantidad": return true;
				case "ValorAdicional": return true;
				default: return false;
			}
		}
    }
}

