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
    
    public partial class Bloqueo
    {
        public int BloqueoId { get; set; }
        public int RolId { get; set; }
        public int FormId { get; set; }
        public string Control { get; set; }
        public int EstadoId { get; set; }
    
        public virtual Form Form { get; set; }
        public virtual Rol Rol { get; set; }
    }
}