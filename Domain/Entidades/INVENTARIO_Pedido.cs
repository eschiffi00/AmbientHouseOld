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
    
    public partial class INVENTARIO_Pedido
    {
        public INVENTARIO_Pedido()
        {
            this.INVENTARIO_Requerimiento_Detalle = new HashSet<INVENTARIO_Requerimiento_Detalle>();
        }
    
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public int ProveedorId { get; set; }
        public int EstadoId { get; set; }
        public System.DateTime CreateFecha { get; set; }
        public Nullable<System.DateTime> UpdateFecha { get; set; }
        public Nullable<System.DateTime> DeleteFecha { get; set; }
        public Nullable<bool> Delete { get; set; }
    
        public virtual ICollection<INVENTARIO_Requerimiento_Detalle> INVENTARIO_Requerimiento_Detalle { get; set; }
    }
}
