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
    
    public partial class CostoTecnica
    {
        public int Id { get; set; }
        public int SegmentoId { get; set; }
        public int TipoServicioId { get; set; }
        public double Precio { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public string Dia { get; set; }
        public int ProveedorId { get; set; }
        public double ValorMas5PorCiento { get; set; }
        public double ValorMenos5PorCiento { get; set; }
        public double ValorMenos10PorCiento { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<int> SectorId { get; set; }
    
        public virtual Segmentos Segmentos { get; set; }
        public virtual TipoServicios TipoServicios { get; set; }
    }
}
