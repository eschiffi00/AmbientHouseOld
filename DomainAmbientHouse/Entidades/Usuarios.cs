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
    
    public partial class Usuarios
    {
        public int EmpleadoId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> PerfilId { get; set; }
        public int EstadoId { get; set; }
        public string CodigoSeguridad { get; set; }
        public string RutaCodigoSeguridad { get; set; }
        public bool HabilitarCambioPassword { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual Perfiles Perfiles { get; set; }
    }
}
