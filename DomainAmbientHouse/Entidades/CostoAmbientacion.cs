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
    
    public partial class CostoAmbientacion
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public double Precio { get; set; }
        public double ValorMas5PorCiento { get; set; }
        public double ValorMenos5PorCiento { get; set; }
        public double ValorMenos10PorCiento { get; set; }
        public int CantidadInvitados { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<int> SectorId { get; set; }
    
        public virtual Categorias Categorias { get; set; }
    }
}
