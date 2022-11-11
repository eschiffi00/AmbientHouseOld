using DbEntidades.Operators;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DbEntidades.Entities
{
    public partial class CategoriasArchivos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return "\r\n " +
            "Id: " + Id.ToString() + "\r\n " +
            "Descripcion: " + Descripcion.ToString() + "\r\n ";
        }
        public CategoriasArchivos()
        {
            Id = -1;

        }



        public List<Herramientas> GetRelatedHerramientases()
        {
            return HerramientasOperator.GetAll().Where(x => x.CategoriaArchivoId == Id).ToList();
        }


        public static bool CanBeNull(string colName)
        {
            switch (colName)
            {
                case "Id": return false;
                case "Descripcion": return false;
                default: return false;
            }
        }
    }
}

