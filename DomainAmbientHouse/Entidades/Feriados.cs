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
    
    public partial class Feriados
    {
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Anio { get; set; }
        public Nullable<System.DateTime> SePasaA { get; set; }
    }
}
