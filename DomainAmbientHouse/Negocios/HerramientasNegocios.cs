using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;

namespace DomainAmbientHouse.Negocios
{
    public class HerramientasNegocios
    {

        HerramientasDatos Datos;

        public HerramientasNegocios()
        {
            Datos = new HerramientasDatos();
        }

        public virtual List<ObtenerArchivosPorCategorias> ObtenerHerramientas()
        {

            return Datos.ObtenerHerramientas();

        }


        public void GrabarHerramientas(Herramientas herramienta)
        {
            Datos.GrabarHerramientas(herramienta);
        }

       
        public Herramientas TraerArchivo(int herramientaId)
        {
            return Datos.TraerArchivo(herramientaId);
        }

        public void EliminarArchivo(Herramientas herramienta)
        {
            Datos.EliminarArchivo(herramienta);
        }
    }
}
