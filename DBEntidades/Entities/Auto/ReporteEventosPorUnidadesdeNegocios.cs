using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ReporteEventosPorUnidadesdeNegocios
    {
		public int NroCliente { get; set; }
		public string ApellidoNombre { get; set; }
		public string RazonSocial { get; set; }
		public string Mail { get; set; }
		public string Celular { get; set; }
		public string ComoLlego { get; set; }
		public int NroEvento { get; set; }
		public string CARACTERISTICA { get; set; }
		public string Segmento { get; set; }
		public string LOCACION { get; set; }
		public string SECTOR { get; set; }
		public string JORNADA { get; set; }
		public string HorarioEvento { get; set; }
		public int? CantidadInicialInvitados { get; set; }
		public int CantidadInvitadosAdolecentes { get; set; }
		public int CantidadInvitadosMenores3y8 { get; set; }
		public int CantidadInvitadosMenores3 { get; set; }
		public DateTime? FechaEvento { get; set; }
		public string Estado { get; set; }
		public string Ejecutivo { get; set; }
		public int NroPresupuesto { get; set; }
		public DateTime FechaEnvioPresupuesto { get; set; }
		public string EstadoPresupuesto { get; set; }
		public decimal TotalSalon { get; set; }
		public string ValorVendidoSalon { get; set; }
		public decimal DescuentoSalon { get; set; }
		public decimal TotalCatering { get; set; }
		public decimal CostoCanon { get; set; }
		public decimal CostoLogistica { get; set; }
		public string ValorVendidoCatering { get; set; }
		public string TipoCatering { get; set; }
		public decimal DescuentoCatering { get; set; }
		public decimal TotalTecnica { get; set; }
		public string ValorVendidoTecnica { get; set; }
		public string TipoTecnica { get; set; }
		public decimal DescuentoTecnica { get; set; }
		public decimal TotalBarra { get; set; }
		public decimal CostoCanonBarras { get; set; }
		public decimal CostoLogisticaBarra { get; set; }
		public string ValorVendidoBarra { get; set; }
		public string TipoBarra { get; set; }
		public decimal DescuentoBarra { get; set; }
		public decimal TotalAmbientacion { get; set; }
		public string ValorVendidoAmbientacion { get; set; }
		public decimal DescuentoAmbientacion { get; set; }
		public decimal TotalAudiovisual { get; set; }
		public string ValorVendidoAudiovisual { get; set; }
		public decimal DescuentoAudiovisual { get; set; }
		public decimal TotalArtistica { get; set; }
		public string ValorVendidoArtistica { get; set; }
		public decimal DescuentoArtistica { get; set; }
		public decimal TotalAdicionales { get; set; }
		public decimal PrecioTotal { get; set; }
		public decimal PrecioPorPersona { get; set; }
		public DateTime? FechaAprobacion { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"NroCliente: " + NroCliente.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"Mail: " + Mail.ToString() + "\r\n " + 
			"Celular: " + Celular.ToString() + "\r\n " + 
			"ComoLlego: " + ComoLlego.ToString() + "\r\n " + 
			"NroEvento: " + NroEvento.ToString() + "\r\n " + 
			"CARACTERISTICA: " + CARACTERISTICA.ToString() + "\r\n " + 
			"Segmento: " + Segmento.ToString() + "\r\n " + 
			"LOCACION: " + LOCACION.ToString() + "\r\n " + 
			"SECTOR: " + SECTOR.ToString() + "\r\n " + 
			"JORNADA: " + JORNADA.ToString() + "\r\n " + 
			"HorarioEvento: " + HorarioEvento.ToString() + "\r\n " + 
			"CantidadInicialInvitados: " + CantidadInicialInvitados.ToString() + "\r\n " + 
			"CantidadInvitadosAdolecentes: " + CantidadInvitadosAdolecentes.ToString() + "\r\n " + 
			"CantidadInvitadosMenores3y8: " + CantidadInvitadosMenores3y8.ToString() + "\r\n " + 
			"CantidadInvitadosMenores3: " + CantidadInvitadosMenores3.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " + 
			"Estado: " + Estado.ToString() + "\r\n " + 
			"Ejecutivo: " + Ejecutivo.ToString() + "\r\n " + 
			"NroPresupuesto: " + NroPresupuesto.ToString() + "\r\n " + 
			"FechaEnvioPresupuesto: " + FechaEnvioPresupuesto.ToString() + "\r\n " + 
			"EstadoPresupuesto: " + EstadoPresupuesto.ToString() + "\r\n " + 
			"TotalSalon: " + TotalSalon.ToString() + "\r\n " + 
			"ValorVendidoSalon: " + ValorVendidoSalon.ToString() + "\r\n " + 
			"DescuentoSalon: " + DescuentoSalon.ToString() + "\r\n " + 
			"TotalCatering: " + TotalCatering.ToString() + "\r\n " + 
			"CostoCanon: " + CostoCanon.ToString() + "\r\n " + 
			"CostoLogistica: " + CostoLogistica.ToString() + "\r\n " + 
			"ValorVendidoCatering: " + ValorVendidoCatering.ToString() + "\r\n " + 
			"TipoCatering: " + TipoCatering.ToString() + "\r\n " + 
			"DescuentoCatering: " + DescuentoCatering.ToString() + "\r\n " + 
			"TotalTecnica: " + TotalTecnica.ToString() + "\r\n " + 
			"ValorVendidoTecnica: " + ValorVendidoTecnica.ToString() + "\r\n " + 
			"TipoTecnica: " + TipoTecnica.ToString() + "\r\n " + 
			"DescuentoTecnica: " + DescuentoTecnica.ToString() + "\r\n " + 
			"TotalBarra: " + TotalBarra.ToString() + "\r\n " + 
			"CostoCanonBarras: " + CostoCanonBarras.ToString() + "\r\n " + 
			"CostoLogisticaBarra: " + CostoLogisticaBarra.ToString() + "\r\n " + 
			"ValorVendidoBarra: " + ValorVendidoBarra.ToString() + "\r\n " + 
			"TipoBarra: " + TipoBarra.ToString() + "\r\n " + 
			"DescuentoBarra: " + DescuentoBarra.ToString() + "\r\n " + 
			"TotalAmbientacion: " + TotalAmbientacion.ToString() + "\r\n " + 
			"ValorVendidoAmbientacion: " + ValorVendidoAmbientacion.ToString() + "\r\n " + 
			"DescuentoAmbientacion: " + DescuentoAmbientacion.ToString() + "\r\n " + 
			"TotalAudiovisual: " + TotalAudiovisual.ToString() + "\r\n " + 
			"ValorVendidoAudiovisual: " + ValorVendidoAudiovisual.ToString() + "\r\n " + 
			"DescuentoAudiovisual: " + DescuentoAudiovisual.ToString() + "\r\n " + 
			"TotalArtistica: " + TotalArtistica.ToString() + "\r\n " + 
			"ValorVendidoArtistica: " + ValorVendidoArtistica.ToString() + "\r\n " + 
			"DescuentoArtistica: " + DescuentoArtistica.ToString() + "\r\n " + 
			"TotalAdicionales: " + TotalAdicionales.ToString() + "\r\n " + 
			"PrecioTotal: " + PrecioTotal.ToString() + "\r\n " + 
			"PrecioPorPersona: " + PrecioPorPersona.ToString() + "\r\n " + 
			"FechaAprobacion: " + FechaAprobacion.ToString() + "\r\n " ;
		}
        public ReporteEventosPorUnidadesdeNegocios()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "NroCliente": return false;
				case "ApellidoNombre": return true;
				case "RazonSocial": return true;
				case "Mail": return true;
				case "Celular": return true;
				case "ComoLlego": return false;
				case "NroEvento": return false;
				case "CARACTERISTICA": return false;
				case "Segmento": return false;
				case "LOCACION": return false;
				case "SECTOR": return true;
				case "JORNADA": return false;
				case "HorarioEvento": return true;
				case "CantidadInicialInvitados": return true;
				case "CantidadInvitadosAdolecentes": return false;
				case "CantidadInvitadosMenores3y8": return false;
				case "CantidadInvitadosMenores3": return false;
				case "FechaEvento": return true;
				case "Estado": return false;
				case "Ejecutivo": return true;
				case "NroPresupuesto": return false;
				case "FechaEnvioPresupuesto": return false;
				case "EstadoPresupuesto": return false;
				case "TotalSalon": return true;
				case "ValorVendidoSalon": return true;
				case "DescuentoSalon": return true;
				case "TotalCatering": return true;
				case "CostoCanon": return true;
				case "CostoLogistica": return true;
				case "ValorVendidoCatering": return true;
				case "TipoCatering": return true;
				case "DescuentoCatering": return true;
				case "TotalTecnica": return true;
				case "ValorVendidoTecnica": return true;
				case "TipoTecnica": return true;
				case "DescuentoTecnica": return true;
				case "TotalBarra": return true;
				case "CostoCanonBarras": return true;
				case "CostoLogisticaBarra": return true;
				case "ValorVendidoBarra": return true;
				case "TipoBarra": return true;
				case "DescuentoBarra": return true;
				case "TotalAmbientacion": return true;
				case "ValorVendidoAmbientacion": return true;
				case "DescuentoAmbientacion": return true;
				case "TotalAudiovisual": return true;
				case "ValorVendidoAudiovisual": return true;
				case "DescuentoAudiovisual": return true;
				case "TotalArtistica": return true;
				case "ValorVendidoArtistica": return true;
				case "DescuentoArtistica": return true;
				case "TotalAdicionales": return true;
				case "PrecioTotal": return true;
				case "PrecioPorPersona": return true;
				case "FechaAprobacion": return true;
				default: return false;
			}
		}
    }
}

