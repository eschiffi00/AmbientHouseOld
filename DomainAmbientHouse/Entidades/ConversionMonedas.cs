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
