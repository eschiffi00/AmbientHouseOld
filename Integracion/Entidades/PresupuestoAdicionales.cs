//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Integracion.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class PresupuestoAdicionales
    {
        public int Id { get; set; }
        public int AdicionalId { get; set; }
        public int PresupuestoId { get; set; }
        public double ValorAdicional { get; set; }
        public int Cantidad { get; set; }
    
        public virtual Adicionales Adicionales { get; set; }
        public virtual Presupuestos Presupuestos { get; set; }
    }
}
