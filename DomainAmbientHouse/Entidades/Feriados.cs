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
    
    public partial class Feriados
    {
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Anio { get; set; }
        public Nullable<System.DateTime> SePasaA { get; set; }
    }
}
