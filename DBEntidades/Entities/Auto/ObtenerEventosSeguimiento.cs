using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerEventosSeguimiento
    {
		public int EventoId { get; set; }
		public int ClienteId { get; set; }
		public string RazonSocial { get; set; }
		public string ApellidoNombreCliente { get; set; }
		public string Mail { get; set; }
		public string Celular { get; set; }
		public string ApellidoNombre { get; set; }
		public string Descripcion { get; set; }
		public int EstadoId { get; set; }
		public DateTime Fecha { get; set; }
		public int EmpleadoId { get; set; }
		public string Comentario { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"EventoId: " + EventoId.ToString() + "\r\n " + 
			"ClienteId: " + ClienteId.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"ApellidoNombreCliente: " + ApellidoNombreCliente.ToString() + "\r\n " + 
			"Mail: " + Mail.ToString() + "\r\n " + 
			"Celular: " + Celular.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " + 
			"Fecha: " + Fecha.ToString() + "\r\n " + 
			"EmpleadoId: " + EmpleadoId.ToString() + "\r\n " + 
			"Comentario: " + Comentario.ToString() + "\r\n " ;
		}
        public ObtenerEventosSeguimiento()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "EventoId": return false;
				case "ClienteId": return false;
				case "RazonSocial": return true;
				case "ApellidoNombreCliente": return true;
				case "Mail": return true;
				case "Celular": return true;
				case "ApellidoNombre": return true;
				case "Descripcion": return false;
				case "EstadoId": return false;
				case "Fecha": return false;
				case "EmpleadoId": return false;
				case "Comentario": return true;
				default: return false;
			}
		}
    }
}

