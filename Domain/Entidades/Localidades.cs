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
    
    public partial class Localidades
    {
        public Localidades()
        {
            this.CostoLogistica = new HashSet<CostoLogistica>();
            this.Empleados = new HashSet<Empleados>();
            this.Locaciones = new HashSet<Locaciones>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<CostoLogistica> CostoLogistica { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual ICollection<Locaciones> Locaciones { get; set; }
    }
}
