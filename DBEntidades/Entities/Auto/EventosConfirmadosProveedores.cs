using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class EventosConfirmadosProveedores
    {
		public int NROPRESUPUESTO { get; set; }
		public int? DIAEVENTO { get; set; }
		public int? MESEVENTO { get; set; }
		public int? ANIOEVENTO { get; set; }
		public long NroComprobante { get; set; }
		public string RazonSocial { get; set; }
		public string Cuit { get; set; }
		public string Descripcion { get; set; }
		public string CUENTA { get; set; }
		public decimal IMPORTEPAGADO { get; set; }
		public decimal COSTOS { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"NROPRESUPUESTO: " + NROPRESUPUESTO.ToString() + "\r\n " + 
			"DIAEVENTO: " + DIAEVENTO.ToString() + "\r\n " + 
			"MESEVENTO: " + MESEVENTO.ToString() + "\r\n " + 
			"ANIOEVENTO: " + ANIOEVENTO.ToString() + "\r\n " + 
			"NroComprobante: " + NroComprobante.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"Cuit: " + Cuit.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"CUENTA: " + CUENTA.ToString() + "\r\n " + 
			"IMPORTEPAGADO: " + IMPORTEPAGADO.ToString() + "\r\n " + 
			"COSTOS: " + COSTOS.ToString() + "\r\n " ;
		}
        public EventosConfirmadosProveedores()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "NROPRESUPUESTO": return false;
				case "DIAEVENTO": return true;
				case "MESEVENTO": return true;
				case "ANIOEVENTO": return true;
				case "NroComprobante": return false;
				case "RazonSocial": return false;
				case "Cuit": return true;
				case "Descripcion": return false;
				case "CUENTA": return false;
				case "IMPORTEPAGADO": return true;
				case "COSTOS": return true;
				default: return false;
			}
		}
    }
}

