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
    
    public partial class ConversionMonedas
    {
        public int Id { get; set; }
        public int MonedaOrigenId { get; set; }
        public int MonedaDestinoId { get; set; }
        public string Conversion { get; set; }
    
        public virtual Monedas Monedas { get; set; }
        public virtual Monedas Monedas1 { get; set; }
    }
}
