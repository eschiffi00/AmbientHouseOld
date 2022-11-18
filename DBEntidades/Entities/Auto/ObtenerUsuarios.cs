using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerUsuarios
    {
		public string ApellidoNombre { get; set; }
		public string UserName { get; set; }
		public string Mail { get; set; }
		public string Nombre { get; set; }
		public int EstadoId { get; set; }
		public string Descripcion { get; set; }
		public int EmpleadoId { get; set; }
		public int Id { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"UserName: " + UserName.ToString() + "\r\n " + 
			"Mail: " + Mail.ToString() + "\r\n " + 
			"Nombre: " + Nombre.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"EmpleadoId: " + EmpleadoId.ToString() + "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " ;
		}
        public ObtenerUsuarios()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "ApellidoNombre": return true;
				case "UserName": return false;
				case "Mail": return true;
				case "Nombre": return false;
				case "EstadoId": return false;
				case "Descripcion": return false;
				case "EmpleadoId": return false;
				case "Id": return false;
				default: return false;
			}
		}
    }
}

