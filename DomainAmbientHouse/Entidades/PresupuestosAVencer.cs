//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainAmbientHouse.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class PresupuestosAVencer
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
        public string Vencimiento { get; set; }
        public System.DateTime FechaPresupuesto { get; set; }
    }
}
