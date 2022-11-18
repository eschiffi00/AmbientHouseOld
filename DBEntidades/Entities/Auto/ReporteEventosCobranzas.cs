using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ReporteEventosCobranzas
    {
		public int PresupuestoId { get; set; }
		public int? ANIO { get; set; }
		public int? MES { get; set; }
		public int? DIA { get; set; }
		public int? Total Invitados { get; set; }
		public string Unidad de Negocio { get; set; }
		public string UnidadNegocioAdicional { get; set; }
		public string PrecioSeleccionado { get; set; }
		public string RazonSocial { get; set; }
		public string ApellidoNombre { get; set; }
		public string Locacion { get; set; }
		public int? ANIOSENIA { get; set; }
		public int? MESSENIA { get; set; }
		public int? DIASENIA { get; set; }
		public string Ejecutivo { get; set; }
		public decimal Comision { get; set; }
		public decimal Cannon { get; set; }
		public decimal Logistica { get; set; }
		public decimal Fee { get; set; }
		public decimal Organizador { get; set; }
		public decimal Descuentos { get; set; }
		public decimal Incrementos { get; set; }
		public decimal COSTO TOTAL { get; set; }
		public decimal PRECIO TOTAL { get; set; }
		public decimal TOTAL PRESUPUESTO SIN INDEXACION { get; set; }
		public decimal TOTAL PAGADO { get; set; }
		public decimal VALOR COMISIONABLE { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"ANIO: " + ANIO.ToString() + "\r\n " + 
			"MES: " + MES.ToString() + "\r\n " + 
			"DIA: " + DIA.ToString() + "\r\n " + 
			"Total Invitados: " + Total Invitados.ToString() + "\r\n " + 
			"Unidad de Negocio: " + Unidad de Negocio.ToString() + "\r\n " + 
			"UnidadNegocioAdicional: " + UnidadNegocioAdicional.ToString() + "\r\n " + 
			"PrecioSeleccionado: " + PrecioSeleccionado.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"Locacion: " + Locacion.ToString() + "\r\n " + 
			"ANIOSENIA: " + ANIOSENIA.ToString() + "\r\n " + 
			"MESSENIA: " + MESSENIA.ToString() + "\r\n " + 
			"DIASENIA: " + DIASENIA.ToString() + "\r\n " + 
			"Ejecutivo: " + Ejecutivo.ToString() + "\r\n " + 
			"Comision: " + Comision.ToString() + "\r\n " + 
			"Cannon: " + Cannon.ToString() + "\r\n " + 
			"Logistica: " + Logistica.ToString() + "\r\n " + 
			"Fee: " + Fee.ToString() + "\r\n " + 
			"Organizador: " + Organizador.ToString() + "\r\n " + 
			"Descuentos: " + Descuentos.ToString() + "\r\n " + 
			"Incrementos: " + Incrementos.ToString() + "\r\n " + 
			"COSTO TOTAL: " + COSTO TOTAL.ToString() + "\r\n " + 
			"PRECIO TOTAL: " + PRECIO TOTAL.ToString() + "\r\n " + 
			"TOTAL PRESUPUESTO SIN INDEXACION: " + TOTAL PRESUPUESTO SIN INDEXACION.ToString() + "\r\n " + 
			"TOTAL PAGADO: " + TOTAL PAGADO.ToString() + "\r\n " + 
			"VALOR COMISIONABLE: " + VALOR COMISIONABLE.ToString() + "\r\n " ;
		}
        public ReporteEventosCobranzas()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "PresupuestoId": return false;
				case "ANIO": return true;
				case "MES": return true;
				case "DIA": return true;
				case "Total Invitados": return true;
				case "Unidad de Negocio": return true;
				case "UnidadNegocioAdicional": return false;
				case "PrecioSeleccionado": return false;
				case "RazonSocial": return true;
				case "ApellidoNombre": return true;
				case "Locacion": return true;
				case "ANIOSENIA": return true;
				case "MESSENIA": return true;
				case "DIASENIA": return true;
				case "Ejecutivo": return true;
				case "Comision": return false;
				case "Cannon": return false;
				case "Logistica": return false;
				case "Fee": return false;
				case "Organizador": return false;
				case "Descuentos": return false;
				case "Incrementos": return false;
				case "COSTO TOTAL": return true;
				case "PRECIO TOTAL": return true;
				case "TOTAL PRESUPUESTO SIN INDEXACION": return true;
				case "TOTAL PAGADO": return false;
				case "VALOR COMISIONABLE": return true;
				default: return false;
			}
		}
    }
}

