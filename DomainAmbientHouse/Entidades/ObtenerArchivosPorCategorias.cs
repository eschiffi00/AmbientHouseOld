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
    
    public partial class ObtenerArchivosPorCategorias
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public byte[] Archivo { get; set; }
        public string ExtencionArchivo { get; set; }
        public Nullable<int> CategoriaArchivoId { get; set; }
        public Nullable<int> CarpetaId { get; set; }
        public string Carpeta { get; set; }
    }
}
