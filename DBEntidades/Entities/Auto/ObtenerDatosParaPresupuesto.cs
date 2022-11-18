using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ObtenerDatosParaPresupuesto
    {
		public int ClienteId { get; set; }
		public string ApellidoNombre { get; set; }
		public string Mail { get; set; }
		public string Celular { get; set; }
		public int SegmentoId { get; set; }
		public string Segmento { get; set; }
		public int CaracteristicaId { get; set; }
		public string Caracteristica { get; set; }
		public int? SectorId { get; set; }
		public string Sector { get; set; }
		public int TipoEventoId { get; set; }
		public string TipoEvento { get; set; }
		public int LocacionId { get; set; }
		public string Locacion { get; set; }
		public string TipoLocacion { get; set; }
		public int JornadaId { get; set; }
		public string Jornada { get; set; }
		public int? CantidadInicialInvitados { get; set; }
		public int? CantidadInvitadosMenores3 { get; set; }
		public int? CantidadInvitadosMenores3y8 { get; set; }
		public int? CantidadInvitadosAdolecentes { get; set; }
		public DateTime? FechaEvento { get; set; }
		public string HorarioEvento { get; set; }
		public string HorarioArmado { get; set; }
		public string HoraFinalizado { get; set; }
		public string Comentario { get; set; }
		public int EventoId { get; set; }
		public int EmpleadoId { get; set; }
		public string Ejecutivo { get; set; }
		public DateTime FechaContacto { get; set; }
		public int? PresupuestoId { get; set; }
		public string RazonSocial { get; set; }
		public decimal PrecioTotal { get; set; }
		public decimal PrecioPorPersona { get; set; }
		public string ComentarioPresupuesto { get; set; }
		public DateTime? FechaPresupuesto { get; set; }
		public string LocacionOtra { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"ClienteId: " + ClienteId.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"Mail: " + Mail.ToString() + "\r\n " + 
			"Celular: " + Celular.ToString() + "\r\n " + 
			"SegmentoId: " + SegmentoId.ToString() + "\r\n " + 
			"Segmento: " + Segmento.ToString() + "\r\n " + 
			"CaracteristicaId: " + CaracteristicaId.ToString() + "\r\n " + 
			"Caracteristica: " + Caracteristica.ToString() + "\r\n " + 
			"SectorId: " + SectorId.ToString() + "\r\n " + 
			"Sector: " + Sector.ToString() + "\r\n " + 
			"TipoEventoId: " + TipoEventoId.ToString() + "\r\n " + 
			"TipoEvento: " + TipoEvento.ToString() + "\r\n " + 
			"LocacionId: " + LocacionId.ToString() + "\r\n " + 
			"Locacion: " + Locacion.ToString() + "\r\n " + 
			"TipoLocacion: " + TipoLocacion.ToString() + "\r\n " + 
			"JornadaId: " + JornadaId.ToString() + "\r\n " + 
			"Jornada: " + Jornada.ToString() + "\r\n " + 
			"CantidadInicialInvitados: " + CantidadInicialInvitados.ToString() + "\r\n " + 
			"CantidadInvitadosMenores3: " + CantidadInvitadosMenores3.ToString() + "\r\n " + 
			"CantidadInvitadosMenores3y8: " + CantidadInvitadosMenores3y8.ToString() + "\r\n " + 
			"CantidadInvitadosAdolecentes: " + CantidadInvitadosAdolecentes.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " + 
			"HorarioEvento: " + HorarioEvento.ToString() + "\r\n " + 
			"HorarioArmado: " + HorarioArmado.ToString() + "\r\n " + 
			"HoraFinalizado: " + HoraFinalizado.ToString() + "\r\n " + 
			"Comentario: " + Comentario.ToString() + "\r\n " + 
			"EventoId: " + EventoId.ToString() + "\r\n " + 
			"EmpleadoId: " + EmpleadoId.ToString() + "\r\n " + 
			"Ejecutivo: " + Ejecutivo.ToString() + "\r\n " + 
			"FechaContacto: " + FechaContacto.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"PrecioTotal: " + PrecioTotal.ToString() + "\r\n " + 
			"PrecioPorPersona: " + PrecioPorPersona.ToString() + "\r\n " + 
			"ComentarioPresupuesto: " + ComentarioPresupuesto.ToString() + "\r\n " + 
			"FechaPresupuesto: " + FechaPresupuesto.ToString() + "\r\n " + 
			"LocacionOtra: " + LocacionOtra.ToString() + "\r\n " ;
		}
        public ObtenerDatosParaPresupuesto()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "ClienteId": return false;
				case "ApellidoNombre": return true;
				case "Mail": return true;
				case "Celular": return true;
				case "SegmentoId": return false;
				case "Segmento": return false;
				case "CaracteristicaId": return false;
				case "Caracteristica": return false;
				case "SectorId": return true;
				case "Sector": return true;
				case "TipoEventoId": return false;
				case "TipoEvento": return false;
				case "LocacionId": return false;
				case "Locacion": return false;
				case "TipoLocacion": return false;
				case "JornadaId": return false;
				case "Jornada": return false;
				case "CantidadInicialInvitados": return true;
				case "CantidadInvitadosMenores3": return true;
				case "CantidadInvitadosMenores3y8": return true;
				case "CantidadInvitadosAdolecentes": return true;
				case "FechaEvento": return true;
				case "HorarioEvento": return true;
				case "HorarioArmado": return true;
				case "HoraFinalizado": return true;
				case "Comentario": return true;
				case "EventoId": return false;
				case "EmpleadoId": return false;
				case "Ejecutivo": return true;
				case "FechaContacto": return false;
				case "PresupuestoId": return true;
				case "RazonSocial": return true;
				case "PrecioTotal": return true;
				case "PrecioPorPersona": return true;
				case "ComentarioPresupuesto": return true;
				case "FechaPresupuesto": return true;
				case "LocacionOtra": return true;
				default: return false;
			}
		}
    }
}

