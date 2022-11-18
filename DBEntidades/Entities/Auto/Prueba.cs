using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class Prueba
    {
		public string presupuestoId { get; set; }
		public string fecha { get; set; }
		public string importe { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"presupuestoId: " + presupuestoId.ToString() + "\r\n " + 
			"fecha: " + fecha.ToString() + "\r\n " + 
			"importe: " + importe.ToString() + "\r\n " ;
		}
        public Prueba()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "presupuestoId": return true;
				case "fecha": return true;
				case "importe": return true;
				default: return false;
			}
		}
    }
}

