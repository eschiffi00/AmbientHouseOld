using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class OrganizacionItems
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public string RequiereCantidad { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"RequiereCantidad: " + RequiereCantidad.ToString() + "\r\n " ;
		}
        public OrganizacionItems()
        {
            Id = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "Descripcion": return false;
				case "RequiereCantidad": return false;
				default: return false;
			}
		}
    }
}

