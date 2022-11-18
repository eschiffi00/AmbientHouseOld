using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class EMPLEADODEPARTAMENTO
    {
		public int EmpleadoId { get; set; }
		public int DepartamentoId { get; set; }
		public string ApellidoNombre { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"EmpleadoId: " + EmpleadoId.ToString() + "\r\n " + 
			"DepartamentoId: " + DepartamentoId.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " ;
		}
        public EMPLEADODEPARTAMENTO()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "EmpleadoId": return false;
				case "DepartamentoId": return false;
				case "ApellidoNombre": return true;
				default: return false;
			}
		}
    }
}

