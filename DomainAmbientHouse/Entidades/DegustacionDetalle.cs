//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainAmbientHouse.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class DegustacionDetalle
    {
        public int Id { get; set; }
        public int DegustacionId { get; set; }
        public int SegmentoId { get; set; }
        public int CaracteristicaId { get; set; }
        public Nullable<int> TipoEventoId { get; set; }
        public int CantidadInvitados { get; set; }
        public System.DateTime FechaEvento { get; set; }
        public string Empresa { get; set; }
        public string Comensal { get; set; }
        public Nullable<int> NroMesa { get; set; }
        public Nullable<int> NroComensal { get; set; }
        public string EstadoEvento { get; set; }
        public Nullable<int> LocacionId { get; set; }
        public string Comentarios { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public int EmpleadoId { get; set; }
        public int EstadoId { get; set; }
    
        public virtual Caracteristicas Caracteristicas { get; set; }
        public virtual Degustacion Degustacion { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual Locaciones Locaciones { get; set; }
        public virtual Segmentos Segmentos { get; set; }
        public virtual TipoEventos TipoEventos { get; set; }
    }
}
