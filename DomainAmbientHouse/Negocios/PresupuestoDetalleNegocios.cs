using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class PresupuestoDetalleNegocios
    {
        PresupuestoDetalleDatos Datos;

        public PresupuestoDetalleNegocios()
        {
            Datos = new PresupuestoDetalleDatos();
        }

        public PresupuestoDetalle AddItem(PresupuestoDetalle detalle, Productos producto, int locacionId, int invitadosAdultos, int invitadosAdolescentes, int invitadosTotal, List<PresupuestoDetalle> list)
        {
            return Datos.AddItem(detalle, producto, locacionId, invitadosAdultos, invitadosAdolescentes, invitadosTotal, list);

        }

        public PresupuestoDetalle AprobarItemPresupuesto(int detalleId)
        {
            return Datos.AprobarItemPresupuesto(detalleId);
        }

        public PresupuestoDetalle BuscarPresupuestoDetalle(int id)
        {
            return Datos.BuscarPresupuestoDetalle(id);
        }

        internal bool ActualizarCobroItem(int Id)
        {
            return Datos.ActualizarCobroItem(Id);
        }

        public List<PresupuestoDetalle> BuscarDetallePresupuestoNoPagados(int PresupuestoId, string fechaEvento, string cliente)
        {
            return Datos.BuscarDetallePresupuestoNoPagados(PresupuestoId, fechaEvento, cliente);
        }

        public void GrabarDetallePresupuesto(PresupuestoDetalle detalle)
        {
            Datos.GrabarPresupuestoDetalle(detalle);
        }

        internal bool GrabarPresupuestoDetalleRevisado(PresupuestoDetalle detalle)
        {
            return Datos.GrabarPresupuestoDetalleRevisado(detalle);
        }
    }
}
