using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ProveedoresPagos
    {
		public int NroPresupuesto { get; set; }
		public long NroFactura { get; set; }
		public DateTime FechaFactura { get; set; }
		public DateTime? FechaSena { get; set; }
		public string TipoComprobante { get; set; }
		public string CuentaContable { get; set; }
		public DateTime? FechaEvento { get; set; }
		public string UnidadNegocio { get; set; }
		public decimal Costo { get; set; }
		public decimal ValorNetoFactura { get; set; }
		public decimal ValorDetalleFactura { get; set; }
		public decimal ImportePago { get; set; }
		public string Cuit { get; set; }
		public string Proveedor { get; set; }
		public DateTime FechaPago { get; set; }
		public string FormaPago { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"NroPresupuesto: " + NroPresupuesto.ToString() + "\r\n " + 
			"NroFactura: " + NroFactura.ToString() + "\r\n " + 
			"FechaFactura: " + FechaFactura.ToString() + "\r\n " + 
			"FechaSena: " + FechaSena.ToString() + "\r\n " + 
			"TipoComprobante: " + TipoComprobante.ToString() + "\r\n " + 
			"CuentaContable: " + CuentaContable.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " + 
			"UnidadNegocio: " + UnidadNegocio.ToString() + "\r\n " + 
			"Costo: " + Costo.ToString() + "\r\n " + 
			"ValorNetoFactura: " + ValorNetoFactura.ToString() + "\r\n " + 
			"ValorDetalleFactura: " + ValorDetalleFactura.ToString() + "\r\n " + 
			"ImportePago: " + ImportePago.ToString() + "\r\n " + 
			"Cuit: " + Cuit.ToString() + "\r\n " + 
			"Proveedor: " + Proveedor.ToString() + "\r\n " + 
			"FechaPago: " + FechaPago.ToString() + "\r\n " + 
			"FormaPago: " + FormaPago.ToString() + "\r\n " ;
		}
        public ProveedoresPagos()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "NroPresupuesto": return false;
				case "NroFactura": return false;
				case "FechaFactura": return false;
				case "FechaSena": return true;
				case "TipoComprobante": return false;
				case "CuentaContable": return false;
				case "FechaEvento": return true;
				case "UnidadNegocio": return false;
				case "Costo": return true;
				case "ValorNetoFactura": return false;
				case "ValorDetalleFactura": return false;
				case "ImportePago": return true;
				case "Cuit": return true;
				case "Proveedor": return false;
				case "FechaPago": return false;
				case "FormaPago": return true;
				default: return false;
			}
		}
    }
}

