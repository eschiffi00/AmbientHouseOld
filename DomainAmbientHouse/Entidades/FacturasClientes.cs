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
    
    public partial class FacturasClientes
    {
        public int Id { get; set; }
        public string NroFactura { get; set; }
        public System.DateTime Fecha { get; set; }
        public double Importe { get; set; }
        public System.DateTime FechaCreate { get; set; }
        public Nullable<System.DateTime> FechaUpdate { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<System.DateTime> FechaDelete { get; set; }
    }
}
