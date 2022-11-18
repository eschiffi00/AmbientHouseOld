using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class AvisosClientesPorFecha
    {
		public int Id { get; set; }
		public string ApellidoNombre { get; set; }
		public string RazonSocial { get; set; }
		public string Comentario { get; set; }
		public DateTime? FechaAviso { get; set; }
		public int EmpleadoId { get; set; }
		public int ClienteId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"Comentario: " + Comentario.ToString() + "\r\n " + 
			"FechaAviso: " + FechaAviso.ToString() + "\r\n " + 
			"EmpleadoId: " + EmpleadoId.ToString() + "\r\n " + 
			"ClienteId: " + ClienteId.ToString() + "\r\n " ;
		}
        public AvisosClientesPorFecha()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "ApellidoNombre": return true;
				case "RazonSocial": return true;
				case "Comentario": return false;
				case "FechaAviso": return true;
				case "EmpleadoId": return false;
				case "ClienteId": return false;
				default: return false;
			}
		}
    }
}

