using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ProcesoCierre
    {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public int Orden { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"Orden: " + Orden.ToString() + "\r\n " ;
		}
        public ProcesoCierre()
        {
            Id = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "Descripcion": return true;
				case "Orden": return false;
				default: return false;
			}
		}
    }
}

