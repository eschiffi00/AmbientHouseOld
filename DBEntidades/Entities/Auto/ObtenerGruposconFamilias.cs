using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerGruposconFamilias
    {
		public string Codigo { get; set; }
		public int GrupoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Codigo: " + Codigo.ToString() + "\r\n " + 
			"GrupoId: " + GrupoId.ToString() + "\r\n " ;
		}
        public ObtenerGruposconFamilias()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Codigo": return false;
				case "GrupoId": return false;
				default: return false;
			}
		}
    }
}

