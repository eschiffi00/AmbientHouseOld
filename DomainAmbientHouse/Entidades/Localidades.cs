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
    
    public partial class Localidades
    {
        public Localidades()
        {
            this.CostoLogistica = new HashSet<CostoLogistica>();
            this.Locaciones = new HashSet<Locaciones>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<CostoLogistica> CostoLogistica { get; set; }
        public virtual ICollection<Locaciones> Locaciones { get; set; }
    }
}
