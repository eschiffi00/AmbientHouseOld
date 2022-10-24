using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class RatiosListado
    {
		public int Id { get; set; }
		public int ItemId { get; set; }
		public string ItemDetalle { get; set; }
		public int CategoriaId { get; set; }
		public string CategoriaDetalle { get; set; }
		public string TipoRatio { get; set; }
        public string DetalleTipo { get; set; }
        public double? ValorRatio { get; set; }
        public double? TopeRatio { get; set; }
		public int Menores { get; set; }
		public int AdicionalRatio { get; set; }
		public int EstadoId { get; set; }
		public string Estado { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"ID: " + Id.ToString() + "\r\n " +
            "ItemId: " + ItemId.ToString() + "\r\n " +
            "ItemDetalle: " + ItemDetalle.ToString() + "\r\n " +
            "CategoriaId: " + CategoriaId.ToString() + "\r\n " +
            "CategoriaDetalle: " + CategoriaDetalle.ToString() + "\r\n " +
            "TipoRatio: " + TipoRatio.ToString() + "\r\n " +
            "DetalleTipo: " + DetalleTipo.ToString() + "\r\n " +
            "TopeRatio: " + TopeRatio.ToString() + "\r\n " +
            "Menores: " + Menores.ToString() + "\r\n " +
			"EstadoID: " + EstadoId.ToString() + "\r\n " +
			"Estado: " + Estado.ToString() + "\r\n " ;
		}
		public RatiosListado()
		{
			Id = -1;

		}
	}
	
}

