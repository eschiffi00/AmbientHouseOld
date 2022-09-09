using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ComprobantesPagados
    {
		public int? Id { get; set; }
		public int? ComprobanteProveedorDetalleId { get; set; }
		public int  NroPresupuesto { get; set; }
		public int TipoMovimiento { get; set; }
		public string TMDescripcion { get; set;}
		public double MontoPagado { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " +
            "NroComprobante: " + ComprobanteProveedorDetalleId.ToString() + "\r\n " +  
			"NroPresupuesto: " + NroPresupuesto.ToString() + "\r\n " +
            "TipoMovimiento: " + TipoMovimiento.ToString() + "\r\n " +
            "TMDescripcion: "  + TMDescripcion.ToString() + "\r\n " +
            "MontoPagado: " + MontoPagado.ToString() + "\r\n " ;
		}
        public ComprobantesPagados()
        {
			Id = -1;
            ComprobanteProveedorDetalleId = 0;
			NroPresupuesto = 0;
            TipoMovimiento = 0;
            TMDescripcion = "";
			MontoPagado = 0;

        }


		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "NroPresupuesto": return false;
				case "TipoMovimiento": return true;
				case "TMDescripcion": return true;
				case "MontoPagado": return false;
				default: return false;
			}
		}
    }
}

