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
    
    public partial class Sectores
    {
        public Sectores()
        {
            this.CostoSalones = new HashSet<CostoSalones>();
        }
    
        public int Id { get; set; }
        public int LocacionId { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<CostoSalones> CostoSalones { get; set; }
        public virtual Locaciones Locaciones { get; set; }
    }
}
