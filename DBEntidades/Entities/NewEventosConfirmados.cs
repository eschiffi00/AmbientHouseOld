﻿using System;

namespace DBEntidades.Entities
{
    public partial class NewEventosConfirmados
    {
        public string ApellidoNombre { get; set; }
        public string CARACTERISTICA { get; set; }
        public string LOCACION { get; set; }
        public string SECTOR { get; set; }
        public string JORNADA { get; set; }
        public string HorarioEvento { get; set; }
        public Nullable<int> CantidadInicialInvitados { get; set; }
        public Nullable<System.DateTime> FechaEvento { get; set; }
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Ejecutivo { get; set; }
        public int EventoId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int EstadoId { get; set; }
        public string RazonSocial { get; set; }
        public System.DateTime Fecha { get; set; }
        public int PresupuestoId { get; set; }
        public int PresupuestoEstadoId { get; set; }
        public string EstadoPresupuesto { get; set; }
        public Nullable<int> PresupuestoIdAnterior { get; set; }
        public int LocacionId { get; set; }
        public int EmpleadoCliente { get; set; }
        public string TipoEvento { get; set; }
        public Nullable<int> ClienteBisId { get; set; }
        public string Cliente { get; set; }
        public Nullable<System.DateTime> FechaSena { get; set; }
        public int TipoEventoId { get; set; }
        public string TipoExperiencia { get; set; }
        public string TipoBarra { get; set; }
    }
}
