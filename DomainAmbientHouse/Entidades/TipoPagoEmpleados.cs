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
    
    public partial class TipoPagoEmpleados
    {
        public TipoPagoEmpleados()
        {
            this.LiquidacionHorasPersonal_Detalle = new HashSet<LiquidacionHorasPersonal_Detalle>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<LiquidacionHorasPersonal_Detalle> LiquidacionHorasPersonal_Detalle { get; set; }
    }
}
