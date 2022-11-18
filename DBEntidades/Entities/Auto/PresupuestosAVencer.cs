using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class PresupuestosAVencer
    {
		public string ApellidoNombre { get; set; }
		public string CARACTERISTICA { get; set; }
		public string LOCACION { get; set; }
		public string SECTOR { get; set; }
		public string JORNADA { get; set; }
		public string HorarioEvento { get; set; }
		public int? CantidadInicialInvitados { get; set; }
		public DateTime? FechaEvento { get; set; }
		public int Id { get; set; }
		public string Estado { get; set; }
		public string Ejecutivo { get; set; }
		public int EventoId { get; set; }
		public int ClienteId { get; set; }
		public int EmpleadoId { get; set; }
		public int EstadoId { get; set; }
		public string RazonSocial { get; set; }
		public DateTime Fecha { get; set; }
		public int PresupuestoId { get; set; }
		public int PresupuestoEstadoId { get; set; }
		public string EstadoPresupuesto { get; set; }
		public string Vencimiento { get; set; }
		public DateTime FechaPresupuesto { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"CARACTERISTICA: " + CARACTERISTICA.ToString() + "\r\n " + 
			"LOCACION: " + LOCACION.ToString() + "\r\n " + 
			"SECTOR: " + SECTOR.ToString() + "\r\n " + 
			"JORNADA: " + JORNADA.ToString() + "\r\n " + 
			"HorarioEvento: " + HorarioEvento.ToString() + "\r\n " + 
			"CantidadInicialInvitados: " + CantidadInicialInvitados.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"Estado: " + Estado.ToString() + "\r\n " + 
			"Ejecutivo: " + Ejecutivo.ToString() + "\r\n " + 
			"EventoId: " + EventoId.ToString() + "\r\n " + 
			"ClienteId: " + ClienteId.ToString() + "\r\n " + 
			"EmpleadoId: " + EmpleadoId.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"Fecha: " + Fecha.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"PresupuestoEstadoId: " + PresupuestoEstadoId.ToString() + "\r\n " + 
			"EstadoPresupuesto: " + EstadoPresupuesto.ToString() + "\r\n " + 
			"Vencimiento: " + Vencimiento.ToString() + "\r\n " + 
			"FechaPresupuesto: " + FechaPresupuesto.ToString() + "\r\n " ;
		}
        public PresupuestosAVencer()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "ApellidoNombre": return true;
				case "CARACTERISTICA": return false;
				case "LOCACION": return false;
				case "SECTOR": return true;
				case "JORNADA": return false;
				case "HorarioEvento": return true;
				case "CantidadInicialInvitados": return true;
				case "FechaEvento": return true;
				case "Id": return false;
				case "Estado": return false;
				case "Ejecutivo": return true;
				case "EventoId": return false;
				case "ClienteId": return false;
				case "EmpleadoId": return false;
				case "EstadoId": return false;
				case "RazonSocial": return true;
				case "Fecha": return false;
				case "PresupuestoId": return false;
				case "PresupuestoEstadoId": return false;
				case "EstadoPresupuesto": return false;
				case "Vencimiento": return false;
				case "FechaPresupuesto": return false;
				default: return false;
			}
		}
    }
}

