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
    
    public partial class ReciboEventoPresupuesto
    {
        public int Id { get; set; }
        public int ReciboId { get; set; }
        public int EventoId { get; set; }
        public Nullable<int> PresupuestoId { get; set; }
    
        public virtual Eventos Eventos { get; set; }
        public virtual Presupuestos Presupuestos { get; set; }
        public virtual Recibos Recibos { get; set; }
    }
}
