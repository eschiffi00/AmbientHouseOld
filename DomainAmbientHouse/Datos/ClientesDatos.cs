using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class ClientesDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ClientesDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<ObtenerClientes> ObtenerClientes()
        {

            return SqlContext.ObtenerClientes.ToList();

        }

        public ClientesBis BuscarCliente(long id)
        {
            return SqlContext.ClientesBis.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<ObtenerClientes> BuscarClientesporApellido(string cliente, int nroCliente, string razonSocial)
        {

            var query = from c in SqlContext.ObtenerClientes
                        select c;

            if (!string.IsNullOrEmpty(cliente))
                query = query.Where(t => t.ApellidoNombre.Contains(cliente));


            if (!string.IsNullOrEmpty(razonSocial))
                query = query.Where(t => t.RazonSocial.Contains(razonSocial));

            if (nroCliente > 0)
                query = query.Where(t => t.Id == nroCliente);
          

            return query.OrderByDescending(o=> o.FechaContacto).ToList();
        }

        public List<SeguimientosEventosClientesEstados> BuscarClientesSeguimientos(long ClienteId)
        {
            int estadoEnviado = Int32.Parse(ConfigurationManager.AppSettings["EstadoEnviado"].ToString());

            return SqlContext.SeguimientosEventosClientesEstados.Where(o => o.ClienteId == ClienteId && o.EstadoId == estadoEnviado).ToList();
        }

        public virtual List<SeguimientosEventosClientesEstados> BuscarClientesSeguimientosBuscador(int nroCliente, int nroEvento, int nroPresupuesto, int empleadoId)
        {
            var query = from S in SqlContext.SeguimientosEventosClientesEstados
                        where S.EmpleadoId == empleadoId
                        select S;

            if (nroCliente > 0)
                query = query.Where(s => s.ClienteId == nroCliente);

            if (nroEvento > 0)
                query = query.Where(s => s.EventoId == nroEvento);

            if (nroPresupuesto > 0)
                query = query.Where(s => s.PresupuestoId == nroPresupuesto);

            return query.ToList();

        }

        public List<ObtenerContactosClientes> ObtenerContactosPorCliente(int clienteId)
        {
            return SqlContext.ObtenerContactosClientes.Where(o => o.ClienteId == clienteId).ToList();
        }

        public List<AvisosClientesPorFecha> ObtenerAvisosClientes(int empleadoId)
        {
            return SqlContext.AvisosClientesPorFecha.Where(o=> o.EmpleadoId == empleadoId).ToList();
                                
                                                                
        }

        public List<Entidades.ObtenerClientes> ObtenerClientesAsignados(int EmpleadoId)
        {
            return SqlContext.ObtenerClientes.Where(o => o.EmpleadoAsignadoId == EmpleadoId).ToList();
        }

        public ClientesBis BuscarClientesPorCuitCuil(string cuitcuil)
        {
            return SqlContext.ClientesBis.Where(o => o.CUILCUIT.Equals(cuitcuil)).FirstOrDefault();
        
        }

        public void GrabarClienteBis(ClientesBis cliente)
        {
            if (cliente.Id > 0)
            {

                ClientesBis clieEdit = SqlContext.ClientesBis.Where(o => o.Id == cliente.Id).First();

                clieEdit.ApellidoNombre = cliente.ApellidoNombre;
                clieEdit.RazonSocial = cliente.RazonSocial;
                clieEdit.PersonaFisicaJuridica = cliente.PersonaFisicaJuridica;
                clieEdit.CUILCUIT = cliente.CUILCUIT;
                clieEdit.CondicionIva = cliente.CondicionIva;
                clieEdit.Direccion = cliente.Direccion;
                clieEdit.TipoCliente = cliente.TipoCliente;
                clieEdit.MailContactoAdministracion = cliente.MailContactoAdministracion;
                clieEdit.MailContactoContratacion = cliente.MailContactoContratacion;
                clieEdit.MailContactoTesoreia = cliente.MailContactoTesoreia;
                clieEdit.MailContactoOrganizacion = cliente.MailContactoOrganizacion;
                clieEdit.TelContactoAdministracion = cliente.TelContactoAdministracion;
                clieEdit.TelContactoContratacion = cliente.TelContactoContratacion;
                clieEdit.TelContactoTesoreria = cliente.TelContactoTesoreria;
                clieEdit.TelContactoOrganizacion = cliente.TelContactoOrganizacion;

                SqlContext.SaveChanges();

            }
            else
            {
                SqlContext.ClientesBis.Add(cliente);
                SqlContext.SaveChanges();

            }
        }

        public List<ClientesBis> BuscarClientesPorApellidoRazonSocial(ClientesSearcher searcher)
        {

            var query = from c in SqlContext.ClientesBis
                        select c;

            if (!string.IsNullOrEmpty(searcher.RazonSocial))
                query = query.Where(o => o.ApellidoNombre.Contains(searcher.RazonSocial)
                                                    || o.RazonSocial.Contains(searcher.RazonSocial));

            if (!string.IsNullOrEmpty(searcher.CUIT))
                query = query.Where(o => o.CUILCUIT == searcher.CUIT);

            return query.ToList();
            
        }

        public string ValidarCliente(int? clienteId)
        {

            if (clienteId != null)
            {
                ClientesBis cliente = SqlContext.ClientesBis.Where(o => o.Id == clienteId).SingleOrDefault();

                if (cliente.ApellidoNombre != "")
                {
                    return cliente.ApellidoNombre.ToUpper();
                }
                else if (cliente.RazonSocial != "")
                {
                    return cliente.RazonSocial.ToUpper();
                }
                else
                    return "";
            }
            return "";
        }

    }
}


namespace DomainAmbientHouse.Entidades
{
    public partial class ClientesSearcher
    {
        public string CUIT { get; set; }
        public string RazonSocial { get; set; }

    }

    public partial class ClientesBis
    {
        public string Identificador
        {
            get
            {
                if (RazonSocial.Length > 0)
                    return RazonSocial;
                else
                    return ApellidoNombre;
            }

        }
    }
}