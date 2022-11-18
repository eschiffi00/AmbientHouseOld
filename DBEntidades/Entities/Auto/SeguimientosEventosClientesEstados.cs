using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class SeguimientosEventosClientesEstados
    {
		public int ClienteId { get; set; }
		public int EventoId { get; set; }
		public int Id { get; set; }
		public string RazonSocial { get; set; }
		public string ApellidoNombreCliente { get; set; }
		public string Mail { get; set; }
		public string Celular { get; set; }
		public string ApellidoNombre { get; set; }
		public string Comentario { get; set; }
		public DateTime FechaSeguimiento { get; set; }
		public string Descripcion { get; set; }
		public int EstadoId { get; set; }
		public string Caracteristica { get; set; }
		public string TipoEvento { get; set; }
		public DateTime Fecha { get; set; }
		public int? CantidadInicialInvitados { get; set; }
		public int EmpleadoId { get; set; }
		public int PresupuestoId { get; set; }
		public int PresupuestoEstadoId { get; set; }
		public string EstadoPresupuesto { get; set; }
		public DateTime? FechaEvento { get; set; }
		public int? PresupuestoIdAnterior { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"ClienteId: " + ClienteId.ToString() + "\r\n " + 
			"EventoId: " + EventoId.ToString() + "\r\n " + 
			"Id: " + Id.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"ApellidoNombreCliente: " + ApellidoNombreCliente.ToString() + "\r\n " + 
			"Mail: " + Mail.ToString() + "\r\n " + 
			"Celular: " + Celular.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"Comentario: " + Comentario.ToString() + "\r\n " + 
			"FechaSeguimiento: " + FechaSeguimiento.ToString() + "\r\n " + 
			"Descripcion: " + Descripcion.ToString() + "\r\n " + 
			"EstadoId: " + EstadoId.ToString() + "\r\n " + 
			"Caracteristica: " + Caracteristica.ToString() + "\r\n " + 
			"TipoEvento: " + TipoEvento.ToString() + "\r\n " + 
			"Fecha: " + Fecha.ToString() + "\r\n " + 
			"CantidadInicialInvitados: " + CantidadInicialInvitados.ToString() + "\r\n " + 
			"EmpleadoId: " + EmpleadoId.ToString() + "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"PresupuestoEstadoId: " + PresupuestoEstadoId.ToString() + "\r\n " + 
			"EstadoPresupuesto: " + EstadoPresupuesto.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " + 
			"PresupuestoIdAnterior: " + PresupuestoIdAnterior.ToString() + "\r\n " ;
		}
        public SeguimientosEventosClientesEstados()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "ClienteId": return false;
				case "EventoId": return false;
				case "Id": return false;
				case "RazonSocial": return true;
				case "ApellidoNombreCliente": return true;
				case "Mail": return true;
				case "Celular": return true;
				case "ApellidoNombre": return true;
				case "Comentario": return true;
				case "FechaSeguimiento": return false;
				case "Descripcion": return false;
				case "EstadoId": return false;
				case "Caracteristica": return false;
				case "TipoEvento": return false;
				case "Fecha": return false;
				case "CantidadInicialInvitados": return true;
				case "EmpleadoId": return false;
				case "PresupuestoId": return false;
				case "PresupuestoEstadoId": return false;
				case "EstadoPresupuesto": return false;
				case "FechaEvento": return true;
				case "PresupuestoIdAnterior": return true;
				default: return false;
			}
		}
    }
}

