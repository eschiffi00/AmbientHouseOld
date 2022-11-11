using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Negocios;
using System.Collections.Generic;

namespace DomainAmbientHouse.Servicios
{
    public class ClientesServicios
    {

        ClientesNegocios Negocios;

        EventosNegocios NegociosEventos;

        public ClientesServicios()
        {
            Negocios = new ClientesNegocios();

            NegociosEventos = new EventosNegocios();
        }


        public List<ObtenerClientes> ObtenerClientes()
        {

            return Negocios.ObtenerClientes();
        }

        public ClientesBis BuscarCliente(long id)
        {
            return Negocios.BuscarCliente(id);
        }

        public List<ObtenerClientes> BuscarClientesporApellido(string cliente, int nroCliente, string razonSocial)
        {
            return Negocios.BuscarClientesporApellido(cliente, nroCliente, razonSocial);
        }

        public List<SeguimientosEventosClientesEstados> BuscarClientesSeguimientos(long ClienteId)
        {
            return Negocios.BuscarClientesSeguimientos(ClienteId);
        }

        public List<ObtenerEventos> BuscarEventosPorClientes(int clienteId)
        {
            return NegociosEventos.BuscarEventosPorCliente(clienteId);
        }

        public List<SeguimientosEventosClientesEstados> BuscarClientesSeguimientosBuscador(int nroCliente, int nroEvento, int nroPresupuesto, int empleadoId)
        {
            return Negocios.BuscarClientesSeguimientosBuscador(nroCliente, nroEvento, nroPresupuesto, empleadoId);
        }


        public List<ObtenerContactosClientes> ObtenerContactosPorCliente(int clienteId)
        {
            return Negocios.ObtenerContactosPorCliente(clienteId);
        }


        public List<AvisosClientesPorFecha> ObtenerAvisosClientes(int empleadoId)
        {
            return Negocios.ObtenerAvisosClientes(empleadoId);
        }

        public List<Entidades.ObtenerClientes> ObtenerClientesAsignados(int EmpleadoId)
        {
            return Negocios.ObtenerClientesAsignados(EmpleadoId);
        }

        public ClientesBis BuscarClientePorCuitCuil(string CuitCuil)
        {
            return Negocios.BuscarClientePorCuitCuil(CuitCuil);
        }

        public void GrabarClienteBisSenaEvento(ClientesBis cliente, Eventos evento, Presupuestos presupuesto)
        {
            Negocios.GrabarClienteBisSenaEvento(cliente, evento);
        }

        public List<ClientesBis> BuscarClientesPorApellidoRazonSocial(ClientesSearcher searcher)
        {
            return Negocios.BuscarClientesPorApellidoRazonSocial(searcher);
        }

        public void GrabarCliente(ClientesBis cliente)
        {
            Negocios.GrabarCliente(cliente);
        }
    }
}
