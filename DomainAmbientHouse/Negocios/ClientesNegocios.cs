using DomainAmbientHouse.Datos;
using DomainAmbientHouse.Entidades;
using System.Collections.Generic;

namespace DomainAmbientHouse.Negocios
{
    public class ClientesNegocios
    {

        ClientesDatos Datos;
        EventosDatos DatosEventos;

        public ClientesNegocios()
        {
            Datos = new ClientesDatos();
        }
        public virtual List<ObtenerClientes> ObtenerClientes()
        {
            return Datos.ObtenerClientes();
        }


        public ClientesBis BuscarCliente(long id)
        {
            return Datos.BuscarCliente(id);
        }

        public List<ObtenerClientes> BuscarClientesporApellido(string cliente, int nroCliente, string razonSocial)
        {
            return Datos.BuscarClientesporApellido(cliente, nroCliente, razonSocial);
        }

        public List<SeguimientosEventosClientesEstados> BuscarClientesSeguimientos(long ClienteId)
        {
            return Datos.BuscarClientesSeguimientos(ClienteId);
        }

        public List<SeguimientosEventosClientesEstados> BuscarClientesSeguimientosBuscador(int nroCliente, int nroEvento, int nroPresupuesto, int empleadoId)
        {
            return Datos.BuscarClientesSeguimientosBuscador(nroCliente, nroEvento, nroPresupuesto, empleadoId);
        }




        public List<ObtenerContactosClientes> ObtenerContactosPorCliente(int clienteId)
        {
            return Datos.ObtenerContactosPorCliente(clienteId);
        }

        public List<AvisosClientesPorFecha> ObtenerAvisosClientes(int empleadoId)
        {
            return Datos.ObtenerAvisosClientes(empleadoId);
        }

        public List<Entidades.ObtenerClientes> ObtenerClientesAsignados(int EmpleadoId)
        {
            return Datos.ObtenerClientesAsignados(EmpleadoId);
        }


        public ClientesBis BuscarClientePorCuitCuil(string CuitCuil)
        {
            return Datos.BuscarClientesPorCuitCuil(CuitCuil);
        }

        public void GrabarClienteBisSenaEvento(ClientesBis cliente, Eventos evento)
        {
            DatosEventos = new EventosDatos();


            //Datos.GrabarClienteBis(cliente);

            //evento.ClienteBisId = cliente.Id;

            DatosEventos.GrabarSenaEvento(evento);

        }

        public List<ClientesBis> BuscarClientesPorApellidoRazonSocial(ClientesSearcher searcher)
        {
            return Datos.BuscarClientesPorApellidoRazonSocial(searcher);
        }

        internal void GrabarCliente(ClientesBis cliente)
        {
            Datos.GrabarClienteBis(cliente);
        }
    }
}
