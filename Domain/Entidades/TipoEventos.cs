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
    
    public partial class TipoEventos
    {
        public TipoEventos()
        {
            this.DegustacionDetalle = new HashSet<DegustacionDetalle>();
            this.Presupuestos = new HashSet<Presupuestos>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<DegustacionDetalle> DegustacionDetalle { get; set; }
        public virtual ICollection<Presupuestos> Presupuestos { get; set; }
    }
}
