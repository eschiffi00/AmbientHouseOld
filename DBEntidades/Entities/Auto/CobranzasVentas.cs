using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class CobranzasVentas
    {
		public int PresupuestoId { get; set; }
		public decimal Importe { get; set; }
		public string NroRecibo { get; set; }
		public string Concepto { get; set; }
		public DateTime FechaPago { get; set; }
		public string Descripcion { get; set; }
		public string RazonSocial { get; set; }
		public string FormaPago { get; set; }
		public DateTime? FechaEvento { get; set; }
		public decimal TOTALPRESUPUESTOSININDEXACION { get; set; }
		public decimal Indexacion { get; set; }
		public string TipoIndexacion { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"Importe: " + Importe.ToString() + "\r\n " + 
			"NroRecibo: " + NroRecibo.ToString() + "\r\n " + 
			"Concepto: " + Concepto.ToString() + "\r\n " + 
			"FechaPago: " + FechaPago.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"FormaPago: " + FormaPago.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " + 
			"TOTALPRESUPUESTOSININDEXACION: " + TOTALPRESUPUESTOSININDEXACION.ToString() + "\r\n " + 
			"Indexacion: " + Indexacion.ToString() + "\r\n " + 
			"TipoIndexacion: " + TipoIndexacion.ToString() + "\r\n " ;
		}
        public CobranzasVentas()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "PresupuestoId": return false;
				case "Importe": return true;
				case "NroRecibo": return true;
				case "Concepto": return true;
				case "FechaPago": return false;
				case "Descripcion": return false;
				case "RazonSocial": return false;
				case "FormaPago": return true;
				case "FechaEvento": return true;
				case "TOTALPRESUPUESTOSININDEXACION": return true;
				case "Indexacion": return true;
				case "TipoIndexacion": return true;
				default: return false;
			}
		}
    }
}

