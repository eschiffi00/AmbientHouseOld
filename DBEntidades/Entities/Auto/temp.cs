using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class temp
    {
		public string campo1 { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"campo1: " + campo1.ToString() + "\r\n " ;
		}
        public temp()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "campo1": return true;
				default: return false;
			}
		}
    }
}

