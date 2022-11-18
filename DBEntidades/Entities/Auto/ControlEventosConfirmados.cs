using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ControlEventosConfirmados
    {
		public int PresupuestoId { get; set; }
		public int EventoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"EventoId: " + EventoId.ToString() + "\r\n " ;
		}
        public ControlEventosConfirmados()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "PresupuestoId": return false;
				case "EventoId": return false;
				default: return false;
			}
		}
    }
}

