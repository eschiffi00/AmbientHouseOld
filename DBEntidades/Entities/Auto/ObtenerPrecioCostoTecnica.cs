using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerPrecioCostoTecnica
    {
		public int Id { get; set; }
		public string Servicio { get; set; }
		public string Segmento { get; set; }
		public string RazonSocial { get; set; }
		public int Anio { get; set; }
		public int Mes { get; set; }
		public string Dia { get; set; }
		public decimal Precio { get; set; }
		public decimal Costo { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Servicio: " + Servicio.ToString() + "\r\n " + 
			"Segmento: " + Segmento.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"Anio: " + Anio.ToString() + "\r\n " + 
			"Mes: " + Mes.ToString() + "\r\n " + 
			"Dia: " + Dia.ToString() + "\r\n " + 
			"Precio: " + Precio.ToString() + "\r\n " + 
			"Costo: " + Costo.ToString() + "\r\n " ;
		}
        public ObtenerPrecioCostoTecnica()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "Servicio": return false;
				case "Segmento": return false;
				case "RazonSocial": return false;
				case "Anio": return false;
				case "Mes": return false;
				case "Dia": return false;
				case "Precio": return false;
				case "Costo": return true;
				default: return false;
			}
		}
    }
}

