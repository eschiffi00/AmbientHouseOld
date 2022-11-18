using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerAdiciones
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public decimal Precio { get; set; }
		public int RubroId { get; set; }
		public string Rubro { get; set; }
		public int EstadoId { get; set; }
		public string EstadoDescripcion { get; set; }
		public string RequiereCantidad { get; set; }
		public int? ProveedorId { get; set; }
		public decimal Costo { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"Precio: " + Precio.ToString() + "\r\n " + 
			"RubroId: " + RubroId.ToString() + "\r\n " + 
			"Rubro: " + Rubro.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " + 
			"EstadoDescripcion: " + EstadoDescripcion.ToString() + "\r\n " + 
			"RequiereCantidad: " + RequiereCantidad.ToString() + "\r\n " + 
			"ProveedorId: " + ProveedorId.ToString() + "\r\n " + 
			"Costo: " + Costo.ToString() + "\r\n " ;
		}
        public ObtenerAdiciones()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "Descripcion": return false;
				case "Precio": return true;
				case "RubroId": return false;
				case "Rubro": return false;
				case "EstadoId": return false;
				case "EstadoDescripcion": return false;
				case "RequiereCantidad": return true;
				case "ProveedorId": return true;
				case "Costo": return true;
				default: return false;
			}
		}
    }
}

