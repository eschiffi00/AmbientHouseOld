using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class Ratios
    {
		public int Id { get; set; }
		public int ItemId { get; set; }
		public string ExperienciaBarra { get; set; }
		public string TipoRatio { get; set; }
		public double BaseRatio { get; set; }
		public double ValorRatio { get; set; }
		public double TopeRatio { get; set; }
		public bool? Isla { get; set; }
		public bool Adultos { get; set; }
		public bool Menores3 { get; set; }
		public bool Menores3y8 { get; set; }
		public bool Adolescentes { get; set; }
		public bool FijoRatio { get; set; }
		public int EstadoId { get; set; }
        public int? ItemRatioId { get; set; }
        public int? ProductoRatioId { get; set; }
        public int? CategoriaRatioId { get; set; }

        public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ItemId: " + ItemId.ToString() + "\r\n " + 
			"ExperienciaBarra: " + ExperienciaBarra.ToString() + "\r\n " + 
			"TipoRatio: " + TipoRatio.ToString() + "\r\n " + 
			"DetalleTipo: " + BaseRatio.ToString() + "\r\n " + 
			"ValorRatio: " + ValorRatio.ToString() + "\r\n " + 
			"TopeRatio: " + TopeRatio.ToString() + "\r\n " + 
			"Isla: " + Isla.ToString() + "\r\n " + 
			"Adultos: " + Menores3.ToString() + "\r\n " + 
			"Menores3: " + Menores3.ToString() + "\r\n " + 
			"Menores3y8: " + Menores3y8.ToString() + "\r\n " + 
			"Adolescentes: " + Adolescentes.ToString() + "\r\n " + 
			"FijoRatio: " + FijoRatio.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " ;
		}
        public Ratios()
        {
            Id = -1;
			ItemId = 0;
			ExperienciaBarra = "";
			TipoRatio = "";
			BaseRatio = 0.0;
			ValorRatio = 0.0;
			TopeRatio = 0.0;
			Isla = false;
			Adultos = false;
            Menores3 = false;
            Menores3y8 = false;
            Adolescentes = false;
            FijoRatio = false;
			ItemRatioId = 0;
			ProductoRatioId = 0;
            CategoriaRatioId = 0;
            EstadoId = 0;
		}





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "ItemId": return false;
				case "ExperienciaBarra": return false;
				case "TipoRatio": return false;
				case "DetalleTipo": return false;
				case "ValorRatio": return true;
				case "TopeRatio": return true;
				case "IslaId": return true;
				case "Adultos": return false;
				case "Menores3": return false;
				case "Menores3y8": return false;
				case "Adolescentes": return false;
				case "FijoRatio": return false;
				case "EstadoId": return false;
				default: return false;
			}
		}
    }
}

