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
    
    public partial class CostoLogistica
    {
        public int Id { get; set; }
        public int ConceptoId { get; set; }
        public int Localidad { get; set; }
        public int CantidadInvitados { get; set; }
        public Nullable<int> TipoEventoId { get; set; }
        public double Costo { get; set; }
        public double Margen { get; set; }
        public double Valor { get; set; }
    
        public virtual Localidades Localidades { get; set; }
        public virtual TipoLogistica TipoLogistica { get; set; }
    }
}
