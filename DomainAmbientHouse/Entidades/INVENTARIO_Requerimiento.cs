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
    
    public partial class INVENTARIO_Requerimiento
    {
        public INVENTARIO_Requerimiento()
        {
            this.INVENTARIO_Requerimiento_Detalle = new HashSet<INVENTARIO_Requerimiento_Detalle>();
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public System.DateTime Fecha { get; set; }
        public int EstadoId { get; set; }
        public System.DateTime CreateFecha { get; set; }
        public Nullable<System.DateTime> UpdateFecha { get; set; }
        public Nullable<System.DateTime> DeleteFecha { get; set; }
        public Nullable<bool> Delete { get; set; }
    
        public virtual ICollection<INVENTARIO_Requerimiento_Detalle> INVENTARIO_Requerimiento_Detalle { get; set; }
    }
}
