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
    
    public partial class FacturaClienteDetalle
    {
        public int Id { get; set; }
        public int FacturaClienteId { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Importe { get; set; }
        public bool Grabado { get; set; }
        public System.DateTime CreateFecha { get; set; }
        public Nullable<System.DateTime> UpdateFecha { get; set; }
        public bool Delete { get; set; }
        public Nullable<System.DateTime> FechaDelete { get; set; }
    
        public virtual FacturasCliente FacturasCliente { get; set; }
    }
}
