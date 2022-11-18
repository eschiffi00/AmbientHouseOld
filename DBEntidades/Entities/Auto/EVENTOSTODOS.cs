using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class EVENTOSTODOS
    {
		public int Id { get; set; }
		public int? ANIO { get; set; }
		public int? MES { get; set; }
		public int? DIA { get; set; }
		public string ApellidoNombre { get; set; }
		public string RazonSocial { get; set; }
		public string LOCACION { get; set; }
		public int? CantidadInicialInvitados { get; set; }
		public string Ejecutivo { get; set; }
		public string TipoEventos { get; set; }
		public string Estado { get; set; }
		public int NROPRESUPUESTO { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ANIO: " + ANIO.ToString() + "\r\n " + 
			"MES: " + MES.ToString() + "\r\n " + 
			"DIA: " + DIA.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"LOCACION: " + LOCACION.ToString() + "\r\n " + 
			"CantidadInicialInvitados: " + CantidadInicialInvitados.ToString() + "\r\n " + 
			"Ejecutivo: " + Ejecutivo.ToString() + "\r\n " + 
			"TipoEventos: " + TipoEventos.ToString() + "\r\n " + 
			"Estado: " + Estado.ToString() + "\r\n " + 
			"NROPRESUPUESTO: " + NROPRESUPUESTO.ToString() + "\r\n " ;
		}
        public EVENTOSTODOS()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "ANIO": return true;
				case "MES": return true;
				case "DIA": return true;
				case "ApellidoNombre": return true;
				case "RazonSocial": return true;
				case "LOCACION": return true;
				case "CantidadInicialInvitados": return true;
				case "Ejecutivo": return true;
				case "TipoEventos": return true;
				case "Estado": return true;
				case "NROPRESUPUESTO": return false;
				default: return false;
			}
		}
    }
}

