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
    
    public partial class AmbientacionSalon
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int LocacionId { get; set; }
        public int SectorId { get; set; }
    
        public virtual Locaciones Locaciones { get; set; }
        public virtual Proveedores Proveedores { get; set; }
    }
}
