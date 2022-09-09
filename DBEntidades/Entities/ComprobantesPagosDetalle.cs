using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ComprobantesPagosDetalle
    {
		public int Id { get; set; }
		public int? ComprobanteProveedorDetalleId { get; set; }
		public int NroPresupuesto { get; set; }
		public string Descripcion { get; set; }
		public int TipoMovimiento { get; set; }
		public string TMDescripcion { get; set; }
		public double Costo { get; set; }
		public double ValorImpuesto { get; set; }
		public double CostoTotal { get; set; }
		public double MontoaPagar { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " +
            "NroComprobante: " + NroPresupuesto.ToString() + "\r\n " + 
			"NroPresupuesto: " + NroPresupuesto.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " +
            "TipoMovimiento: " + TipoMovimiento.ToString() + "\r\n " +
            "TMDescripcion: " + TMDescripcion.ToString() + "\r\n " + 
			"Costo: " + Costo.ToString() + "\r\n " +
            "ValorImpuesto: " + ValorImpuesto.ToString() + "\r\n " +
            "CostoTotal: " + CostoTotal.ToString() + "\r\n " +
			"Monto: " + MontoaPagar.ToString() + "\r\n " ;
		}
        public ComprobantesPagosDetalle()
        {
            ComprobanteProveedorDetalleId = 0;
			NroPresupuesto = 0;
			Descripcion = "";
            TipoMovimiento = 0;
            TMDescripcion = "";
			Costo = 0;
            ValorImpuesto = 0;
            CostoTotal = 0;
			MontoaPagar = 0;

        }
    }
}

