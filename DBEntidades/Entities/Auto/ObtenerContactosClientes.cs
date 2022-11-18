using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerContactosClientes
    {
		public int Id { get; set; }
		public int ClienteId { get; set; }
		public string ApellidoNombre { get; set; }
		public string RazonSocial { get; set; }
		public string ApellidoyNombre { get; set; }
		public string Celular { get; set; }
		public string Mail { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ClienteId: " + ClienteId.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"ApellidoyNombre: " + ApellidoyNombre.ToString() + "\r\n " + 
			"Celular: " + Celular.ToString() + "\r\n " + 
			"Mail: " + Mail.ToString() + "\r\n " ;
		}
        public ObtenerContactosClientes()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "ClienteId": return false;
				case "ApellidoNombre": return true;
				case "RazonSocial": return true;
				case "ApellidoyNombre": return false;
				case "Celular": return true;
				case "Mail": return true;
				default: return false;
			}
		}
    }
}

