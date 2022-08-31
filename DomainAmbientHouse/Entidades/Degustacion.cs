//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainAmbientHouse.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Degustacion
    {
        public Degustacion()
        {
            this.DegustacionDetalle = new HashSet<DegustacionDetalle>();
        }
    
        public int Id { get; set; }
        public System.DateTime FechaDegustacion { get; set; }
        public Nullable<int> CantidadMesas { get; set; }
        public int Locacion { get; set; }
        public string HoraCorporativo { get; set; }
        public string HoraSocial { get; set; }
        public int EstadoId { get; set; }
        public bool ConfirmoTecnica { get; set; }
        public bool ConfirmoAmbientacion { get; set; }
    
        public virtual Estados Estados { get; set; }
        public virtual ICollection<DegustacionDetalle> DegustacionDetalle { get; set; }
    }
}
