using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerPresupuestoAmbientacion
    {
		public int Id { get; set; }
		public int PresupuestoId { get; set; }
		public int SectorId { get; set; }
		public int CaracteristicaId { get; set; }
		public int SegmentoId { get; set; }
		public int CategoriaId { get; set; }
		public int ProveedorIr { get; set; }
		public decimal PrecioLista { get; set; }
		public decimal PrecioMas5 { get; set; }
		public decimal PrecioMenos5 { get; set; }
		public decimal PrecioMenos10 { get; set; }
		public DB_TYPE_DESCONOCIDO Adjunto { get; set; }
		public string AdjuntoExtension { get; set; }
		public decimal ValorSeleccionado { get; set; }
		public decimal Descuentos { get; set; }
		public string Segmento { get; set; }
		public string Caracteristicas { get; set; }
		public string Sector { get; set; }
		public string Categoria { get; set; }
		public string RazonSocial { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"SectorId: " + SectorId.ToString() + "\r\n " + 
			"CaracteristicaId: " + CaracteristicaId.ToString() + "\r\n " + 
			"SegmentoId: " + SegmentoId.ToString() + "\r\n " + 
			"CategoriaId: " + CategoriaId.ToString() + "\r\n " + 
			"ProveedorIr: " + ProveedorIr.ToString() + "\r\n " + 
			"PrecioLista: " + PrecioLista.ToString() + "\r\n " + 
			"PrecioMas5: " + PrecioMas5.ToString() + "\r\n " + 
			"PrecioMenos5: " + PrecioMenos5.ToString() + "\r\n " + 
			"PrecioMenos10: " + PrecioMenos10.ToString() + "\r\n " + 
			"Adjunto: " + Adjunto.ToString() + "\r\n " + 
			"AdjuntoExtension: " + AdjuntoExtension.ToString() + "\r\n " + 
			"ValorSeleccionado: " + ValorSeleccionado.ToString() + "\r\n " + 
			"Descuentos: " + Descuentos.ToString() + "\r\n " + 
			"Segmento: " + Segmento.ToString() + "\r\n " + 
			"Caracteristicas: " + Caracteristicas.ToString() + "\r\n " + 
			"Sector: " + Sector.ToString() + "\r\n " + 
			"Categoria: " + Categoria.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " ;
		}
        public ObtenerPresupuestoAmbientacion()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "PresupuestoId": return false;
				case "SectorId": return false;
				case "CaracteristicaId": return false;
				case "SegmentoId": return false;
				case "CategoriaId": return false;
				case "ProveedorIr": return false;
				case "PrecioLista": return false;
				case "PrecioMas5": return false;
				case "PrecioMenos5": return false;
				case "PrecioMenos10": return false;
				case "Adjunto": return true;
				case "AdjuntoExtension": return true;
				case "ValorSeleccionado": return true;
				case "Descuentos": return true;
				case "Segmento": return false;
				case "Caracteristicas": return false;
				case "Sector": return false;
				case "Categoria": return false;
				case "RazonSocial": return false;
				default: return false;
			}
		}
    }
}

