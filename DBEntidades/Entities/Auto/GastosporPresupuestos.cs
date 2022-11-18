using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class GastosporPresupuestos
    {
		public long NroComprobante { get; set; }
		public string TIPOMOVIMIENTO { get; set; }
		public string CENTROCOSTO { get; set; }
		public decimal Importe { get; set; }
		public string IMPUESTO { get; set; }
		public decimal ValorImpuesto { get; set; }
		public decimal ValorImpuestoInterno { get; set; }
		public int? PresupuestoId { get; set; }
		public string RazonSocial { get; set; }
		public string ApellidoNombre { get; set; }
		public string Leyenda { get; set; }
		public string ESTADO { get; set; }
		public DateTime Fecha { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"NroComprobante: " + NroComprobante.ToString() + "\r\n " + 
			"TIPOMOVIMIENTO: " + TIPOMOVIMIENTO.ToString() + "\r\n " + 
			"CENTROCOSTO: " + CENTROCOSTO.ToString() + "\r\n " + 
			"Importe: " + Importe.ToString() + "\r\n " + 
			"IMPUESTO: " + IMPUESTO.ToString() + "\r\n " + 
			"ValorImpuesto: " + ValorImpuesto.ToString() + "\r\n " + 
			"ValorImpuestoInterno: " + ValorImpuestoInterno.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"Leyenda: " + Leyenda.ToString() + "\r\n " + 
			"ESTADO: " + ESTADO.ToString() + "\r\n " + 
			"Fecha: " + Fecha.ToString() + "\r\n " ;
		}
        public GastosporPresupuestos()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "NroComprobante": return false;
				case "TIPOMOVIMIENTO": return false;
				case "CENTROCOSTO": return false;
				case "Importe": return false;
				case "IMPUESTO": return true;
				case "ValorImpuesto": return false;
				case "ValorImpuestoInterno": return false;
				case "PresupuestoId": return true;
				case "RazonSocial": return true;
				case "ApellidoNombre": return true;
				case "Leyenda": return false;
				case "ESTADO": return false;
				case "Fecha": return false;
				default: return false;
			}
		}
    }
}

