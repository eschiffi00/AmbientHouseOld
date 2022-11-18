using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerClientes
    {
		public int Id { get; set; }
		public string ApellidoNombre { get; set; }
		public string Mail { get; set; }
		public string Telefono { get; set; }
		public string Celular { get; set; }
		public DateTime? FechaContacto { get; set; }
		public int? ComollegoId { get; set; }
		public string ComoLlegoOtro { get; set; }
		public string Comentario { get; set; }
		public string RazonSocial { get; set; }
		public string TipoCliente { get; set; }
		public int? EmpleadoAsignadoId { get; set; }
		public string Ejecutivo { get; set; }
		public int? EmpleadoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"Mail: " + Mail.ToString() + "\r\n " + 
			"Telefono: " + Telefono.ToString() + "\r\n " + 
			"Celular: " + Celular.ToString() + "\r\n " + 
			"FechaContacto: " + FechaContacto.ToString() + "\r\n " + 
			"ComollegoId: " + ComollegoId.ToString() + "\r\n " + 
			"ComoLlegoOtro: " + ComoLlegoOtro.ToString() + "\r\n " + 
			"Comentario: " + Comentario.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"TipoCliente: " + TipoCliente.ToString() + "\r\n " + 
			"EmpleadoAsignadoId: " + EmpleadoAsignadoId.ToString() + "\r\n " + 
			"Ejecutivo: " + Ejecutivo.ToString() + "\r\n " + 
			"EmpleadoId: " + EmpleadoId.ToString() + "\r\n " ;
		}
        public ObtenerClientes()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "ApellidoNombre": return true;
				case "Mail": return true;
				case "Telefono": return true;
				case "Celular": return true;
				case "FechaContacto": return true;
				case "ComollegoId": return true;
				case "ComoLlegoOtro": return true;
				case "Comentario": return true;
				case "RazonSocial": return true;
				case "TipoCliente": return true;
				case "EmpleadoAsignadoId": return true;
				case "Ejecutivo": return true;
				case "EmpleadoId": return true;
				default: return false;
			}
		}
    }
}

