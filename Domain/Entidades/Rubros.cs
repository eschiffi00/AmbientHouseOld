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
    
    public partial class Rubros
    {
        public Rubros()
        {
            this.CodigoPorRubro = new HashSet<CodigoPorRubro>();
            this.INVENTARIO_Producto = new HashSet<INVENTARIO_Producto>();
            this.Rubros_Proveedores = new HashSet<Rubros_Proveedores>();
        }
    
        public int RubroId { get; set; }
        public string Descripcion { get; set; }
        public string LetraCodigo { get; set; }
    
        public virtual ICollection<CodigoPorRubro> CodigoPorRubro { get; set; }
        public virtual ICollection<INVENTARIO_Producto> INVENTARIO_Producto { get; set; }
        public virtual ICollection<Rubros_Proveedores> Rubros_Proveedores { get; set; }
    }
}
