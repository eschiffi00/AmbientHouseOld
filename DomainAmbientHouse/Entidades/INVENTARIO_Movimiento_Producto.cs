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
    
    public partial class INVENTARIO_Movimiento_Producto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public System.DateTime Fecha { get; set; }
        public double CantidadAnterior { get; set; }
        public double CantidadNueva { get; set; }
        public int DepositoId { get; set; }
        public int EmpleadoId { get; set; }
    
        public virtual INVENTARIO_Producto INVENTARIO_Producto { get; set; }
    }
}
