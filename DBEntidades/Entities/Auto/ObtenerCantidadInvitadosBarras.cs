using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerCantidadInvitadosBarras
    {
		public int CantidadPersonas { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"CantidadPersonas: " + CantidadPersonas.ToString() + "\r\n " ;
		}
        public ObtenerCantidadInvitadosBarras()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "CantidadPersonas": return false;
				default: return false;
			}
		}
    }
}

