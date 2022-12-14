//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class CostoCanon
    {
        public int Id { get; set; }
        public int SegmentoId { get; set; }
        public int CaracteristicaId { get; set; }
        public int TipoCateringId { get; set; }
        public Nullable<double> CanonInterno { get; set; }
        public Nullable<double> CanonExterno { get; set; }
        public Nullable<double> UsoCocina { get; set; }
    
        public virtual Caracteristicas Caracteristicas { get; set; }
        public virtual Segmentos Segmentos { get; set; }
        public virtual TipoCatering TipoCatering { get; set; }
    }
}
