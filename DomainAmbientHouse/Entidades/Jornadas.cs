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
    
    public partial class Jornadas
    {
        public Jornadas()
        {
            this.CostoSalones = new HashSet<CostoSalones>();
            this.Presupuestos = new HashSet<Presupuestos>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<CostoSalones> CostoSalones { get; set; }
        public virtual ICollection<Presupuestos> Presupuestos { get; set; }
    }
}
