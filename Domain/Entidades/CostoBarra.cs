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
    
    public partial class CostoBarra
    {
        public int Id { get; set; }
        public int TipoBarraId { get; set; }
        public double Precios { get; set; }
        public int CantidadPersonas { get; set; }
        public double ValorMas5PorCiento { get; set; }
        public double ValorMenos5PorCiento { get; set; }
        public double ValorMenos10PorCiento { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<int> ProveedorId { get; set; }
    
        public virtual TiposBarras TiposBarras { get; set; }
    }
}
