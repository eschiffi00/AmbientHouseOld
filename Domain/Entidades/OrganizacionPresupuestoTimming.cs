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
    
    public partial class OrganizacionPresupuestoTimming
    {
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public string HoraInicio { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
    
        public virtual Presupuestos Presupuestos { get; set; }
    }
}
