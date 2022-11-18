using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class EventosConfirmadosReservadosTODOS
    {
		public int Id { get; set; }
		public string ApellidoNombre { get; set; }
		public string RazonSocial { get; set; }
		public string CARACTERISTICA { get; set; }
		public string LOCACION { get; set; }
		public string SECTOR { get; set; }
		public string JORNADA { get; set; }
		public string TipoEvento { get; set; }
		public int PresupuestoId { get; set; }
		public int EventoId { get; set; }
		public DateTime? FechaEvento { get; set; }
		public int? CantidadInicialInvitados { get; set; }
		public int EstadoId { get; set; }
		public int PresupuestoEstadoId { get; set; }
		public string Ejecutivo { get; set; }
		public int? Coordinador1 { get; set; }
		public int? Coordinador2 { get; set; }
		public int TipoEventoId { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"CARACTERISTICA: " + CARACTERISTICA.ToString() + "\r\n " + 
			"LOCACION: " + LOCACION.ToString() + "\r\n " + 
			"SECTOR: " + SECTOR.ToString() + "\r\n " + 
			"JORNADA: " + JORNADA.ToString() + "\r\n " + 
			"TipoEvento: " + TipoEvento.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"EventoId: " + EventoId.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " + 
			"CantidadInicialInvitados: " + CantidadInicialInvitados.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " + 
			"PresupuestoEstadoId: " + PresupuestoEstadoId.ToString() + "\r\n " + 
			"Ejecutivo: " + Ejecutivo.ToString() + "\r\n " + 
			"Coordinador1: " + Coordinador1.ToString() + "\r\n " + 
			"Coordinador2: " + Coordinador2.ToString() + "\r\n " + 
			"TipoEventoId: " + TipoEventoId.ToString() + "\r\n " ;
		}
        public EventosConfirmadosReservadosTODOS()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "Id": return false;
				case "ApellidoNombre": return true;
				case "RazonSocial": return true;
				case "CARACTERISTICA": return false;
				case "LOCACION": return false;
				case "SECTOR": return true;
				case "JORNADA": return false;
				case "TipoEvento": return false;
				case "PresupuestoId": return false;
				case "EventoId": return false;
				case "FechaEvento": return true;
				case "CantidadInicialInvitados": return true;
				case "EstadoId": return false;
				case "PresupuestoEstadoId": return false;
				case "Ejecutivo": return true;
				case "Coordinador1": return true;
				case "Coordinador2": return true;
				case "TipoEventoId": return false;
				default: return false;
			}
		}
    }
}

