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
    
    public partial class UnidadesNegocios_Proveedores
    {
        public int Id { get; set; }
        public int UnidadNegocioId { get; set; }
        public int ProveedorId { get; set; }
    
        public virtual Proveedores Proveedores { get; set; }
        public virtual UnidadesNegocios UnidadesNegocios { get; set; }
    }
}
