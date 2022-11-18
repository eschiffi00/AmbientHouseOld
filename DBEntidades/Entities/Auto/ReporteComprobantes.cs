using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ReporteComprobantes
    {
		public int Id { get; set; }
		public long NroComprobante { get; set; }
		public DateTime Fecha { get; set; }
		public decimal MontoFactura { get; set; }
		public string Descripcion { get; set; }
		public string RazonSocial { get; set; }
		public string Cuenta { get; set; }
		public decimal NETO { get; set; }
		public string TipoImpuesto { get; set; }
		public decimal IMPUESTO { get; set; }
		public decimal IMPUESTOINTERNO { get; set; }
		public string FormadePago { get; set; }
		public string CC { get; set; }
		public string Leyenda { get; set; }
		public string Codigo { get; set; }
		public int TipoMoviemientoId { get; set; }
		public int? PresupuestoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"NroComprobante: " + NroComprobante.ToString() + "\r\n " + 
			"Fecha: " + Fecha.ToString() + "\r\n " + 
			"MontoFactura: " + MontoFactura.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"Cuenta: " + Cuenta.ToString() + "\r\n " + 
			"NETO: " + NETO.ToString() + "\r\n " + 
			"TipoImpuesto: " + TipoImpuesto.ToString() + "\r\n " + 
			"IMPUESTO: " + IMPUESTO.ToString() + "\r\n " + 
			"IMPUESTOINTERNO: " + IMPUESTOINTERNO.ToString() + "\r\n " + 
			"FormadePago: " + FormadePago.ToString() + "\r\n " + 
			"CC: " + CC.ToString() + "\r\n " + 
			"Leyenda: " + Leyenda.ToString() + "\r\n " + 
			"Codigo: " + Codigo.ToString() + "\r\n " + 
			"TipoMoviemientoId: " + TipoMoviemientoId.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " ;
		}
        public ReporteComprobantes()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "NroComprobante": return false;
				case "Fecha": return false;
				case "MontoFactura": return true;
				case "Descripcion": return false;
				case "RazonSocial": return true;
				case "Cuenta": return false;
				case "NETO": return false;
				case "TipoImpuesto": return false;
				case "IMPUESTO": return false;
				case "IMPUESTOINTERNO": return false;
				case "FormadePago": return true;
				case "CC": return false;
				case "Leyenda": return false;
				case "Codigo": return false;
				case "TipoMoviemientoId": return false;
				case "PresupuestoId": return true;
				default: return false;
			}
		}
    }
}

