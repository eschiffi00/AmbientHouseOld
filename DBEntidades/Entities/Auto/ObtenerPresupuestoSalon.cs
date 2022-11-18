using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerPresupuestoSalon
    {
		public int Id { get; set; }
		public int PresupuestoId { get; set; }
		public int LocacionId { get; set; }
		public decimal PrecioLista { get; set; }
		public decimal PrecioMas5 { get; set; }
		public decimal PrecioMenos5 { get; set; }
		public decimal PrecioMenos10 { get; set; }
		public DB_TYPE_DESCONOCIDO Adjunto { get; set; }
		public string AdjuntoExtension { get; set; }
		public decimal ValorSeleccionado { get; set; }
		public decimal Descuentos { get; set; }
		public string Locacion { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"LocacionId: " + LocacionId.ToString() + "\r\n " + 
			"PrecioLista: " + PrecioLista.ToString() + "\r\n " + 
			"PrecioMas5: " + PrecioMas5.ToString() + "\r\n " + 
			"PrecioMenos5: " + PrecioMenos5.ToString() + "\r\n " + 
			"PrecioMenos10: " + PrecioMenos10.ToString() + "\r\n " + 
			"Adjunto: " + Adjunto.ToString() + "\r\n " + 
			"AdjuntoExtension: " + AdjuntoExtension.ToString() + "\r\n " + 
			"ValorSeleccionado: " + ValorSeleccionado.ToString() + "\r\n " + 
			"Descuentos: " + Descuentos.ToString() + "\r\n " + 
			"Locacion: " + Locacion.ToString() + "\r\n " ;
		}
        public ObtenerPresupuestoSalon()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "PresupuestoId": return false;
				case "LocacionId": return false;
				case "PrecioLista": return false;
				case "PrecioMas5": return false;
				case "PrecioMenos5": return false;
				case "PrecioMenos10": return false;
				case "Adjunto": return true;
				case "AdjuntoExtension": return true;
				case "ValorSeleccionado": return true;
				case "Descuentos": return true;
				case "Locacion": return false;
				default: return false;
			}
		}
    }
}

