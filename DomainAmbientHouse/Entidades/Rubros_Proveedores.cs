//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainAmbientHouse.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rubros_Proveedores
    {
        public int Id { get; set; }
        public int RubroId { get; set; }
        public int ProveedorId { get; set; }
    
        public virtual Proveedores Proveedores { get; set; }
        public virtual Rubros Rubros { get; set; }
    }
}
