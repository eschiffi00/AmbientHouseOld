using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using LibDB2;
using DbEntidades.Operators;

namespace DbEntidades.Entities
{
    public partial class ResponsablesEventos
    {
		public int PresupuestoId { get; set; }
		public DateTime? FechaEvento { get; set; }
		public string HorarioEvento { get; set; }
		public string HoraFinalizado { get; set; }
		public string Caracteristica { get; set; }
		public string Segmento { get; set; }
		public string RazonSocial { get; set; }
		public string ApellidoNombre { get; set; }
		public string LOCACION { get; set; }
		public int? Total Invitados { get; set; }
		public string Resp. Cocina { get; set; }
		public string Resp. Barra { get; set; }
		public string Resp. Logistica { get; set; }
		public string Resp. Operaciones { get; set; }
		public string Resp. Salon { get; set; }
		public string Coordinador 1 { get; set; }
		public string Coordinador 2 { get; set; }
		public string Organizador { get; set; }
		public string Resp. Logistica Armado { get; set; }
		public string Resp. Logistica Desarmado { get; set; }
		public int? OrganizadorId { get; set; }
		public int? Coordinador1Id { get; set; }
		public int? Coordinador2Id { get; set; }
		public string HoraIngresoCoordinador1 { get; set; }
		public string HoraIngresoCoordinador2 { get; set; }

		public override string ToString() 
		{
			return "\r\n " + 
			"PresupuestoId: " + PresupuestoId.ToString() + "\r\n " + 
			"FechaEvento: " + FechaEvento.ToString() + "\r\n " + 
			"HorarioEvento: " + HorarioEvento.ToString() + "\r\n " + 
			"HoraFinalizado: " + HoraFinalizado.ToString() + "\r\n " + 
			"Caracteristica: " + Caracteristica.ToString() + "\r\n " + 
			"Segmento: " + Segmento.ToString() + "\r\n " + 
			"RazonSocial: " + RazonSocial.ToString() + "\r\n " + 
			"ApellidoNombre: " + ApellidoNombre.ToString() + "\r\n " + 
			"LOCACION: " + LOCACION.ToString() + "\r\n " + 
			"Total Invitados: " + Total Invitados.ToString() + "\r\n " + 
			"Resp. Cocina: " + Resp. Cocina.ToString() + "\r\n " + 
			"Resp. Barra: " + Resp. Barra.ToString() + "\r\n " + 
			"Resp. Logistica: " + Resp. Logistica.ToString() + "\r\n " + 
			"Resp. Operaciones: " + Resp. Operaciones.ToString() + "\r\n " + 
			"Resp. Salon: " + Resp. Salon.ToString() + "\r\n " + 
			"Coordinador 1: " + Coordinador 1.ToString() + "\r\n " + 
			"Coordinador 2: " + Coordinador 2.ToString() + "\r\n " + 
			"Organizador: " + Organizador.ToString() + "\r\n " + 
			"Resp. Logistica Armado: " + Resp. Logistica Armado.ToString() + "\r\n " + 
			"Resp. Logistica Desarmado: " + Resp. Logistica Desarmado.ToString() + "\r\n " + 
			"OrganizadorId: " + OrganizadorId.ToString() + "\r\n " + 
			"Coordinador1Id: " + Coordinador1Id.ToString() + "\r\n " + 
			"Coordinador2Id: " + Coordinador2Id.ToString() + "\r\n " + 
			"HoraIngresoCoordinador1: " + HoraIngresoCoordinador1.ToString() + "\r\n " + 
			"HoraIngresoCoordinador2: " + HoraIngresoCoordinador2.ToString() + "\r\n " ;
		}
        public ResponsablesEventos()
        {
             = -1;

        }





		public static bool CanBeNull(string colName)
		{
			switch (colName) 
			{
				case "PresupuestoId": return false;
				case "FechaEvento": return true;
				case "HorarioEvento": return true;
				case "HoraFinalizado": return true;
				case "Caracteristica": return true;
				case "Segmento": return true;
				case "RazonSocial": return true;
				case "ApellidoNombre": return true;
				case "LOCACION": return true;
				case "Total Invitados": return true;
				case "Resp. Cocina": return true;
				case "Resp. Barra": return true;
				case "Resp. Logistica": return true;
				case "Resp. Operaciones": return true;
				case "Resp. Salon": return true;
				case "Coordinador 1": return true;
				case "Coordinador 2": return true;
				case "Organizador": return true;
				case "Resp. Logistica Armado": return true;
				case "Resp. Logistica Desarmado": return true;
				case "OrganizadorId": return true;
				case "Coordinador1Id": return true;
				case "Coordinador2Id": return true;
				case "HoraIngresoCoordinador1": return true;
				case "HoraIngresoCoordinador2": return true;
				default: return false;
			}
		}
    }
}

