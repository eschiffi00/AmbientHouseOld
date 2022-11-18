using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ProveedoresExternos
    {
		public int Id { get; set; }
		public int? ANIO { get; set; }
		public int? MES { get; set; }
		public int? DIA { get; set; }
		public string HorarioEvento { get; set; }
		public string HoraFinalizado { get; set; }
		public string Ejecutivo { get; set; }
		public int? Total Invitados { get; set; }
		public string Locacion { get; set; }
		public string Proveedor { get; set; }
		public string Rubro { get; set; }
		public string Contacto { get; set; }
		public string Telefono { get; set; }
		public string Correo { get; set; }
		public DateTime? FechaEvento { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ANIO: " + ANIO.ToString() + "\r\n " + 
			"MES: " + MES.ToString() + "\r\n " + 
			"DIA: " + DIA.ToString() + "\r\n " + 
			"HorarioEvento: " + HorarioEvento.ToString() + "\r\n " + 
			"HoraFinalizado: " + HoraFinalizado.ToString() + "\r\n " + 
			"Ejecutivo: " + Ejecutivo.ToString() + "\r\n " + 
			"Total Invitados: " + Total Invitados.ToString() + "\r\n " + 
			"Locacion: " + Locacion.ToString() + "\r\n " + 
			"Proveedor: " + Proveedor.ToString() + "\r\n " + 
			"Rubro: " + Rubro.ToString() + "\r\n " + 
			"Contacto: " + Contacto.ToString() + "\r\n " + 
			"Telefono: " + Telefono.ToString() + "\r\n " + 
			"Correo: " + Correo.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " ;
		}
        public ProveedoresExternos()
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
				case "HorarioEvento": return true;
				case "HoraFinalizado": return true;
				case "Ejecutivo": return true;
				case "Total Invitados": return true;
				case "Locacion": return true;
				case "Proveedor": return true;
				case "Rubro": return true;
				case "Contacto": return true;
				case "Telefono": return true;
				case "Correo": return true;
				case "FechaEvento": return true;
				default: return false;
			}
		}
    }
}

