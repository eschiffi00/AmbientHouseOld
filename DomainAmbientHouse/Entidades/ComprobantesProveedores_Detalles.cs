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
    
    public partial class ComprobantesProveedores_Detalles
    {
        public int Id { get; set; }
        public int ComprobanteProveedorId { get; set; }
        public int TipoMoviemientoId { get; set; }
        public int CentroCostoId { get; set; }
        public double Importe { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public Nullable<int> TipoImpuestoId { get; set; }
        public Nullable<double> ValorImpuesto { get; set; }
        public Nullable<double> ValorImpuestoInterno { get; set; }
        public Nullable<int> PresupuestoId { get; set; }
        public Nullable<int> UnidadNegocioId { get; set; }
        public Nullable<int> DegustacionId { get; set; }
    
        public virtual CentroCostos CentroCostos { get; set; }
        public virtual ComprobantesProveedores ComprobantesProveedores { get; set; }
        public virtual Impuestos Impuestos { get; set; }
        public virtual Presupuestos Presupuestos { get; set; }
        public virtual TipoMovimientos TipoMovimientos { get; set; }
        public virtual UnidadesNegocios UnidadesNegocios { get; set; }
    }
}
