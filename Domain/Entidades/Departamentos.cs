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
    
    public partial class Departamentos
    {
        public Departamentos()
        {
            this.EmpleadoDepartamentos = new HashSet<EmpleadoDepartamentos>();
            this.SectoresEmpresa = new HashSet<SectoresEmpresa>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<EmpleadoDepartamentos> EmpleadoDepartamentos { get; set; }
        public virtual ICollection<SectoresEmpresa> SectoresEmpresa { get; set; }
    }
}
