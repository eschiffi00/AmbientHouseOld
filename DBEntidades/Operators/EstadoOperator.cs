using System.Data;
using System.Linq;

namespace DbEntidades.Operators
{
    public partial class EstadosOperator
    {
        public static int GetHablitadoID(string entidad)
        {
            int u = GetAll().Where(x => x.Descripcion == "Activo" && x.Entidad == entidad).FirstOrDefault().Id;
            return u;
        }
        public static int GetDeshabilitadoID(string entidad)
        {
            int u = GetAll().Where(x => x.Descripcion == "Inactivo" && x.Entidad == entidad).FirstOrDefault().Id;
            return u;
        }
        public static int GetApertura(string entidad)
        {
            int u = GetAll().Where(x => x.Descripcion == "Abierto" && x.Entidad == entidad).FirstOrDefault().Id;
            return u;
        }
        public static int GetCierre(string entidad)
        {
            int u = GetAll().Where(x => x.Descripcion == "Cerrado" && x.Entidad == entidad).FirstOrDefault().Id;
            return u;
        }

    }
}
