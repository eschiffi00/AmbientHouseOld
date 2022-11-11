using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class MomentosDiasNegocios
    {

        MomentosDiaDatos Datos;

        public MomentosDiasNegocios()
        {
            Datos = new MomentosDiaDatos();
        }

        public virtual List<MomentosDias> ObtenerMomentosDia()
        {

            return Datos.ObtenerMomentosDia();

        }


        public MomentosDias BuscarMomentosDias(int id)
        {
            return Datos.BuscarMomentosDias(id);
        }

        public void NuevoMomentoDia(MomentosDias item)
        {
            Datos.NuevoMomentoDia(item);
        }
    }
}
