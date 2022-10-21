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
    
    public partial class PresupuestoDetalle
    {
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public int UnidadNegocioId { get; set; }
        public Nullable<int> ProveedorId { get; set; }
        public Nullable<int> ServicioId { get; set; }
        public Nullable<int> LocacionId { get; set; }
        public int ProductoId { get; set; }
        public double PrecioItem { get; set; }
        public double PrecioLista { get; set; }
        public double PrecioMas5 { get; set; }
        public double PrecioMenos5 { get; set; }
        public double PrecioMenos10 { get; set; }
        public string CodigoItem { get; set; }
        public Nullable<double> Descuentos { get; set; }
        public Nullable<double> Incremento { get; set; }
        public string PrecioSeleccionado { get; set; }
        public double PorcentajeComision { get; set; }
        public double ValorSeleccionado { get; set; }
        public double Comision { get; set; }
        public Nullable<int> CantidadAdicional { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<double> Cannon { get; set; }
        public Nullable<int> TipoLogisticaId { get; set; }
        public Nullable<int> LocalidadId { get; set; }
        public Nullable<int> CantInvitadosLogistica { get; set; }
        public Nullable<double> Logistica { get; set; }
        public Nullable<double> UsoCocina { get; set; }
        public Nullable<double> ValorIntermediario { get; set; }
        public Nullable<double> CostoSillas { get; set; }
        public Nullable<double> CostoMesas { get; set; }
        public Nullable<double> PrecioSillas { get; set; }
        public Nullable<double> PrecioMesas { get; set; }
        public Nullable<int> version { get; set; }
        public Nullable<int> EstadoId { get; set; }
        public Nullable<System.DateTime> FechaAprobacion { get; set; }
        public string Comentario { get; set; }
        public string ComentarioProveedor { get; set; }
        public Nullable<System.DateTime> FechaCobroItem { get; set; }
        public Nullable<bool> EstadoProveedor { get; set; }
        public bool AnuloCanon { get; set; }
        public Nullable<System.DateTime> FechaCreate { get; set; }
        public Nullable<System.DateTime> FechaUpdate { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<System.DateTime> FechaDelete { get; set; }
        public double Royalty { get; set; }
    
        public virtual Presupuestos Presupuestos { get; set; }
    }
}
