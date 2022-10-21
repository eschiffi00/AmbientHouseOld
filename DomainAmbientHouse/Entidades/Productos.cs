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
    
    public partial class Productos
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public Nullable<double> Margen { get; set; }
        public double Costo { get; set; }
        public int UnidadNegocioId { get; set; }
        public int Estado { get; set; }
        public Nullable<System.DateTime> FechaVendimiento { get; set; }
        public Nullable<int> PerfilId { get; set; }
        public Nullable<int> TipoCateringId { get; set; }
        public Nullable<int> AdicionalId { get; set; }
        public Nullable<int> TipoBarraId { get; set; }
        public Nullable<int> TipoServicioId { get; set; }
        public Nullable<int> CantidadInvitados { get; set; }
        public Nullable<int> LocacionId { get; set; }
        public Nullable<int> ProveedorId { get; set; }
        public Nullable<int> SegmentoId { get; set; }
        public Nullable<int> JornadaId { get; set; }
        public Nullable<int> SectorId { get; set; }
        public Nullable<int> CategoriaId { get; set; }
        public Nullable<int> Anio { get; set; }
        public Nullable<int> Mes { get; set; }
        public string Dia { get; set; }
        public Nullable<int> CaracteristicaId { get; set; }
        public Nullable<int> OrganizacionItemId { get; set; }
        public Nullable<int> Semestre { get; set; }
        public Nullable<double> MargenAjuste { get; set; }
        public double Royalty { get; set; }
        public Nullable<double> Margen2 { get; set; }
    
        public virtual Perfiles Perfiles { get; set; }
        public virtual UnidadesNegocios UnidadesNegocios { get; set; }
    }
}
