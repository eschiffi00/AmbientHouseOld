using System;
using System.Collections.Generic;

namespace DomainAmbientHouse.Entidades
{
    public partial class Adicionales
    {


        public double Comision { get; set; }




    }

    public partial class ReporteAdicionales
    {
        public int NroEvento { get; set; }
        public int NroPresupuesto { get; set; }
        public DateTime? FechaEvento { get; set; }

        public int AdicionalCant { get; set; }
        public double AdicionalValor { get; set; }

        public string Rubro { get; set; }
        public string AdicionalDesc { get; set; }

    }

    public partial class Categorias
    {

        public string LocacionDescripcion { get; set; }
        public string SegmentoDescripcion { get; set; }
        public string CaracteristicaDescripcion { get; set; }
        public string SectorDescripcion { get; set; }

    }

    public partial class Rubros
    {

        public string DepartamentoDescripcion { get; set; }

    }

    public partial class UnidadesNegocios
    {

        public string DepartamentoDescripcion { get; set; }

    }

    public partial class Proveedores
    {

        public int RubroId { get; set; }
        public int UnidadNegocioId { get; set; }

        public string RubroDescripcion { get; set; }
        public string UnidadNegocioDescripcion { get; set; }

        public string Identificador { get; set; }


    }

    public partial class ProveedorAdicional
    {
        public int Id { get; set; }
        public int LocacionId { get; set; }
        public int ProveedorId { get; set; }
        public string DescripcionProveedor { get; set; }
        public string TipoProveedor { get; set; }

    }

    public partial class LocacionesValorAnio
    {

        public string LocacionDescripcion { get; set; }

    }

    public partial class Locaciones
    {

        public string TecnicaDescripcion { get; set; }

        public string LocalidadDescripcion { get; set; }
    }

    public partial class CostoCatering
    {
        public string ProveedorDescripcion { get; set; }
        public string TipoCateringDescripcion { get; set; }

        public double PrecioMas5 { get; set; }
        public double PrecioMenos5 { get; set; }
        public double PrecioMenos10 { get; set; }

    }

    public partial class CostoBarra
    {
        public string ProveedorDescripcion { get; set; }
        public string TipoBarraDescripcion { get; set; }

        public double PrecioMas5 { get; set; }
        public double PrecioMenos5 { get; set; }
        public double PrecioMenos10 { get; set; }

    }

    public partial class CostoSalones
    {
        public string SectorDescripcion { get; set; }
        public string JornadaDescripcion { get; set; }
        public string LocacionDescripcion { get; set; }
    }

    public partial class CostoTecnica
    {
        public string ProveedorDescripcion { get; set; }
        public string TipoServicioDescripcion { get; set; }
        public string SegmentoDescripcion { get; set; }

        public double PrecioMas5 { get; set; }
        public double PrecioMenos5 { get; set; }
        public double PrecioMenos10 { get; set; }

    }

    public partial class CostoAmbientacion
    {
        public string ProveedorDescripcion { get; set; }
        public string CategoriaDescripcion { get; set; }


        public double PrecioMas5 { get; set; }
        public double PrecioMenos5 { get; set; }
        public double PrecioMenos10 { get; set; }

    }

    public partial class CostoAdicionales
    {
        public string ProveedorDescripcion { get; set; }
        public string AdicionalDescripcion { get; set; }
        public string LocacionDescripcion { get; set; }

        public double PrecioMas5 { get; set; }
        public double PrecioMenos5 { get; set; }
        public double PrecioMenos10 { get; set; }

    }

    public partial class CostoLogistica
    {
        public string ConceptoDescripcion { get; set; }
        public string LocalidadDescripcion { get; set; }

    }

    public partial class CostoCanon
    {

        public string SegmentoDescripcion { get; set; }
        public string CaracteristicaDescripcion { get; set; }
        public string TipoCateringDescripcion { get; set; }


    }

    public partial class ErroresCotizador
    {
        public string Mensaje { get; set; }


    }

    public partial class ObtenerEventosPresupuestos
    {

        public string ApellidoNombre { get; set; }
        public string CARACTERISTICA { get; set; }
        public string LOCACION { get; set; }
        public string SECTOR { get; set; }
        public string JORNADA { get; set; }
        public string HorarioEvento { get; set; }

        public string Duracion { get; set; }
        public string Momento { get; set; }
        public string TipoEvento { get; set; }

        private int? cantidadIncial;

        public int? CantidadInicialInvitados { get; set; }

        public int? CantidadInvitadosAdolecentes { get; set; }
        public int? CantidadInvitadosMenores3y8 { get; set; }
        public int? CantidadInvitadosMenores3 { get; set; }
        public DateTime? FechaEvento { get; set; }
        public int? LocacionId { get; set; }

        public string EstadoEvento { get; set; }
        public int EstadoEventoId { get; set; }
        public int PresupuestoEstadoId { get; set; }
        public string EstadoPresupuesto { get; set; }

        public string Ejecutivo { get; set; }
        public int EventoId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int PresupuestoId { get; set; }
        public int? PresupuestoIdAnterior { get; set; }

        public string RazonSocial { get; set; }
        public DateTime Fecha { get; set; }

        public double PrecioTotalPresupuesto { get; set; }
        public double CostoTotalPresupuesto { get; set; }
        public double RentaTotalPresupuesto { get; set; }
        public double RentaTotalNominal { get; set; }

        public DateTime? FechaCaducidad { get; set; }


        public double? ImporteOrganizador { get; set; }
        public double? PorcentajeOrganizador { get; set; }
        public double? TotalOrganizador { get; set; }


        public string Cuit { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }


        public int? CantidadTotalInvitados
        {

            get
            {
                return (CantidadInicialInvitados == null ? 0 : CantidadInicialInvitados) +
                        (CantidadInvitadosAdolecentes == null ? 0 : CantidadInvitadosAdolecentes) +
                        (CantidadInvitadosMenores3y8 == null ? 0 : CantidadInvitadosMenores3y8) +
                        (CantidadInvitadosMenores3 == null ? 0 : CantidadInvitadosMenores3);
            }

        }

    }

    public partial class ObtenerAdicionales
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public int RubroId { get; set; }
        public string Rubro { get; set; }

        public int EstadoId { get; set; }
        public string EstadoDescripcion { get; set; }
        public string RequiereCantidad { get; set; }
        public int ProveedorId { get; set; }
        public string Proveedor { get; set; }
        public double? Costo { get; set; }
        public int? LocacionId { get; set; }
        public string Locacion { get; set; }

        public string SoloMayoresDescripcion { get; set; }


    }

    public partial class PresupuestoAdicionales
    {
        public string Descripcion { get; set; }
        public double PrecioPresupuesto { get; set; }

    }

    public partial class ListarAdicionalesPorPresupuesto
    {

        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double ValorAdicional { get; set; }
        public int PresupuestoId { get; set; }
        public int AdicionalId { get; set; }
        public string RubroDescripcion { get; set; }
        public int Id { get; set; }
        public double ValorIntermediario { get; set; }

    }

    public partial class Clientes
    {

        public string Ejecutivo { get; set; }

    }

    public partial class ConfiguracionCateringTecnica
    {
        public string SegmentoDescripcion { get; set; }
        public string CaracteristicaDescripcion { get; set; }
        public string MomentodelDiaDescripcion { get; set; }
        public string DuracionDescripcion { get; set; }
        public string TipoCateringDescripcion { get; set; }
        public string TipoServicioDescripcion { get; set; }
    }

    public partial class PresupuestoDetalle
    {
        public string ProductoDescripcion { get; set; }
        public string UnidadNegocioDescripcion { get; set; }
        public string ProveedorRazonSocial { get; set; }
        public string TipoLogisticaDescripcion { get; set; }
        public string LocalidadDescripcion { get; set; }
        public double RentaUnPorcentaje { get; set; }
        public double RentaUnNominal { get; set; }
        public double NuevoValor { get; set; }

        public string PorcentajeDelTotalPresupuestoPorUnidadNegocio { get; set; }

        public double CannonCatering { get; set; }

        public string TipoCanonCatering { get; set; }

        public string TipoCanonBarra { get; set; }

        public double CannonAmbientacion { get; set; }

        public string TipoCanonAmbientacion { get; set; }

        public string EstadoItem { get; set; }

        public DateTime? FechaEvento { get; set; }

        public int? ClienteBisId { get; set; }

        public string ClienteNombre { get; set; }

        public string EstadoProveedorDescripcion
        {
            get
            {
                if (EstadoProveedor == false || EstadoProveedor == null)
                    return "Pendiente ";
                else
                    return "Confirmado";
            }
            set { }
        }
    }

    public partial class ComprobantesProveedores
    {
        public string TipoComprobanteDescripcion { get; set; }
        public string RazonSocial { get; set; }
        public string FormaPagoDescripcion { get; set; }
        public string EstadoDescripcion { get; set; }
        public int EmpleadoId { get; set; }

        public int NroOrdenPago { get; set; }




        public string EmpresaRS { get; set; }


    }

    public partial class TipoMovimientos
    {
        public string Identificador { get; set; }
        public string TipoMovimientoPadreDescripcion { get; set; }

    }

    public partial class TipoMovimientoSearcher
    {
        public string Tipo { get; set; }
        public string Codigo { get; set; }

    }

    public partial class ComprobantesProveedores_Detalles
    {
        public string CentroCostoDescripcion { get; set; }
        public string TipoMovimientoCodigo { get; set; }

    }

    public partial class Productos
    {
        public string UnidadNegocioDescripcion { get; set; }
    }

    public partial class Usuarios
    {
        public string PerfilDescripcion { get; set; }
    }

    public partial class ClientesPipedrive
    {
        public int Id { get; set; }
        public string ApellidoNombre { get; set; }

        public string Identificador { get; set; }
        public string RazonSocial { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public int OrganizacionId { get; set; }

        public string Owner { get; set; }
    }

    public partial class PresupuestoPDF
    {

        public int ClienteId { get; set; }
        public string ApellidoNombre { get; set; }
        public string RazonSocial { get; set; }
        public string Mail { get; set; }
        public string Celular { get; set; }
        public int SegmentoId { get; set; }
        public string Segmento { get; set; }
        public int CaracteristicaId { get; set; }
        public string Caracteristica { get; set; }
        public int SectorId { get; set; }
        public string Sector { get; set; }
        public int TipoEventoId { get; set; }
        public string TipoEvento { get; set; }
        public int LocacionId { get; set; }
        public string Locacion { get; set; }
        public string TipoLocacion { get; set; }
        public int JornadaId { get; set; }
        public string Jornada { get; set; }

        public int? CantidadInicialInvitados { get; set; }
        public int? CantidadInvitadosMenores3 { get; set; }
        public int? CantidadInvitadosMenores3y8 { get; set; }
        public int? CantidadInvitadosAdolecentes { get; set; }
        public DateTime? FechaEvento { get; set; }
        public string HorarioEvento { get; set; }
        public string HorarioArmado { get; set; }
        public string HoraFinalizado { get; set; }
        public int EventoId { get; set; }
        public int EmpleadoId { get; set; }
        public string Ejecutivo { get; set; }
        public DateTime FechaContacto { get; set; }
        public int PresupuestoId { get; set; }
        public double? PrecioTotal { get; set; }
        public double? PrecioPorPersona { get; set; }
        public double? ValorOrganizador { get; set; }
        public double? ValorRoyaltyOrganizador { get; set; }

        public string ComentarioPresupuesto { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaPresupuesto { get; set; }
        public string LocacionOtra { get; set; }


        public object CantidadAdultosFinal { get; set; }

        public object CantidadInvitadosAdolecentesFinal { get; set; }

        public object CantidadInvitadosMenores3Final { get; set; }

        public object CantidadInvitadosMenores3y8Final { get; set; }
    }

    public partial class Bancos
    {
        public string Identificador { get; set; }
    }

    public partial class PagosProveedores
    {
        public int EmpleadoId { get; set; }
        public double Saldo { get; set; }

        public string NroCertificado { get; set; }
        public int TipoMoviemientoId { get; set; }


        public string NroTransferencia { get; set; }

        public int ProveedorId { get; set; }
    }

    public partial class ReporteExcelDiario
    {

        public int NroCliente { get; set; }
        public string ApellidoNombre { get; set; }
        public string RazonSocial { get; set; }

        public int NroEvento { get; set; }
        public string Caracteristica { get; set; }
        public string Segmento { get; set; }

        public string Locacion { get; set; }
        public string Sector { get; set; }
        public string Jornada { get; set; }
        public string HorarioEvento { get; set; }
        public int CantidadInicialInvitados { get; set; }
        public int? CantidadInvitadosAdolecentes { get; set; }
        public int? CantidadInvitadosMenores3y8 { get; set; }
        public int? CantidadInvitadosMenores3 { get; set; }

        public DateTime FechaEvento { get; set; }
        public string Estado { get; set; }
        public string Ejecutivo { get; set; }
        public int NroPresupuesto { get; set; }
        public DateTime FechaEnvioPresupuesto { get; set; }
        public string EstadoPresupuesto { get; set; }

        public double TotalSalon { get; set; }

        public string ValorVendidoSalon { get; set; }
        public double DescuentoSalon { get; set; }


        public double TotalCatering { get; set; }
        public double CostoCanonCatering { get; set; }
        public double CostoLogisticaCatering { get; set; }

        public string ValorVendidoCatering { get; set; }
        public double DescuentoCatering { get; set; }
        public string TipoCatering { get; set; }

        public double TotalTecnica { get; set; }
        public string ValorVendidoTecnica { get; set; }
        public string TipoTecnica { get; set; }
        public double DescuentoTecnica { get; set; }

        public double TotalBarra { get; set; }
        public string ValorVendidoBarra { get; set; }
        public string TipoBarra { get; set; }
        public double CostoCanonBarras { get; set; }
        public double CostoLogisticaBarra { get; set; }
        public double DescuentoBarra { get; set; }


        public double TotalAmbientacion { get; set; }
        public string ValorVendidoAmbientacion { get; set; }
        public double DescuentoAmbientacion { get; set; }

        public double TotalAdicionales { get; set; }
        public DateTime? FechaAprobacion { get; set; }

        public double PrecioTotal { get; set; }
        public double PrecioPorPersona { get; set; }


    }

    public partial class Negocio
    {
        public string titulo { get; set; }
        public string valor { get; set; }
        public string moneda { get; set; }
        public int usuario { get; set; }
        public int persona { get; set; }
        public int nroEvento { get; set; }
        public int nroPresupuesto { get; set; }
        public string fechaEvento { get; set; }
    }

    public partial class UnidadesNegocios_Proveedores
    {
        public string Descripcion { get; set; }
    }

    public partial class ProveedoresFormasdePago
    {
        public string Descripcion { get; set; }
    }

    public partial class Rubros_Proveedores
    {
        public string Descripcion { get; set; }
    }

    public partial class RecibosPDF
    {

        public int ClienteId { get; set; }
        public string ApellidoNombre { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string Celular { get; set; }
        public string CuilCuit { get; set; }

        public int LocacionId { get; set; }
        public string Locacion { get; set; }

        public DateTime FechaEvento { get; set; }
        public DateTime? FechaSenia { get; set; }

        public int EventoId { get; set; }
        public int EmpleadoId { get; set; }

        public int PresupuestoId { get; set; }

        public string CondicionIva { get; set; }

        public double Importe { get; set; }


    }

    public partial class CategoriasItem
    {

        public string CategoriaItemPadreDescripcion { get; set; }
        public string CategoriaItemPadrePadreDescripcion { get; set; }


    }

    public partial class TipoCateringTiempoProductoItem
    {
        public string TiempoDescripcion { get; set; }
        public string TipoCateringDescripcion { get; set; }
        public string ProductoCateringDescripcion { get; set; }
        public string ItemDescripcion { get; set; }
        public string CategoriaItemDescripcion { get; set; }

        public int? Orden { get; set; }

    }

    public partial class TipoBarraCategoriaItem
    {
        public string TipoBarraDescripcion { get; set; }

        public string ItemDescripcion { get; set; }
        public string CategoriaItemDescripcion { get; set; }
    }

    public partial class ReporteConfiguracionesTipoCateringTiempoProductoCategoriaItem
    {
        public int TipoCateringId { get; set; }
        public string TiempoDescripcion { get; set; }
        public string TipoCateringDescripcion { get; set; }

        public string ProductoCateringDescripcion { get; set; }
        public int ProductoCateringItemId { get; set; }
        public string ProductoCateringItemDescripcion { get; set; }


        public string CategoriaItemDescripcion { get; set; }

        public int CategoriaItemItemId { get; set; }
        public string CategoriaItemItemDescripcion { get; set; }

        public int ItemId { get; set; }
        public string ItemDescripcion { get; set; }
        public int? Orden { get; set; }


        public int TiempoId { get; set; }
        public int? ProductoId { get; set; }
        public int? CategoriaItemId { get; set; }



    }

    public partial class Items
    {
        public string Identificador { get; set; }
    }

    public partial class TecnicaSalon
    {

        public string RazonSocial { get; set; }

        public string LocacionDescripcion { get; set; }

        public string SectorDescripcion { get; set; }



    }

    public partial class AmbientacionSalon
    {

        public string RazonSocial { get; set; }

        public string LocacionDescripcion { get; set; }

        public string SectorDescripcion { get; set; }



    }

    public partial class EnvioMails
    {
        public string CuentadeCorreo { get; set; }

    }

    public partial class ObtenerEventosPresupuestosProveedores
    {
        public int PresupuestoId { get; set; }
        public string Ejecutivo { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaEvento { get; set; }
        public string RazonSocialCliente { get; set; }
        public string Locacion { get; set; }
        public int CantidadInvitados { get; set; }

        public int CantidadInvitadosAdolescentes { get; set; }
        public int CantidadInvitadosMenores3 { get; set; }
        public int CantidadInvitadosEntre3y8 { get; set; }

        public int CantidadTotal { get; set; }

        public string TipoCatering { get; set; }
        public string RazonSocialCatering { get; set; }
        public string TipoTecnica { get; set; }
        public string RazonSocialTecnica { get; set; }
        public string TipoBarra { get; set; }
        public string RazonSocialBarra { get; set; }
        public string TipoAmbientacion { get; set; }
        public string RazonSocialAmbientacion { get; set; }

        public int UnidadNegocioId { get; set; }

        public string Comentario { get; set; }

        public string Adicional { get; set; }

        public int? CantidadAdicional { get; set; }

        public string Caracteristica { get; set; }

        public string EstadoDescripcion { get; set; }

        public string HorarioEvento { get; set; }

        public string HoraFinalizado { get; set; }

        public bool? EstadoProveedor { get; set; }

        public string ComentarioProveedor { get; set; }

        public string UnidadNegocioDescripcion { get; set; }

        public string ProductoDescripcion { get; set; }

        public string EstadoProveedorDescripcion
        {
            get
            {
                if (EstadoProveedor == false || EstadoProveedor == null)
                    return "Pendiente";
                else
                    return "Confirmado";
            }
            set { }
        }

        public int? ProveedorId { get; set; }

        public double Costo { get; set; }

        public double Precio { get; set; }
    }

    public partial class Eventos
    {

        public string NroEvento
        {
            get
            {
                return Id.ToString().PadLeft(8, '0');
            }

        }

        public int CuentaId { get; set; }

        public int EmpresaId { get; set; }

        public string Concepto { get; set; }

        public string NroRecibo { get; set; }

        public string TipoPago { get; set; }
    }

    public partial class Presupuestos
    {

        public string NroPresupuesto
        {
            get
            {
                return Id.ToString().PadLeft(8, '0');
            }

        }

        private List<PresupuestoDetalle> _detalle;

        public List<PresupuestoDetalle> Detalles
        {
            get
            {
                return _detalle;
            }
            set
            {
                _detalle = value;
            }
        }


    }

    public partial class PresupuestoDetalle
    {
        public int SegmentoId { get; set; }
        public int CarasteristicaId { get; set; }
        public double CannonBarra { get; set; }

    }

    public partial class PresupuestoDetalleADD
    {
        public string precioSeleccionado { get; set; }
        public int unidadNegocio { get; set; }
        public int productoNinguno { get; set; }
        public int proveedorId { get; set; }
        public int servicioId { get; set; }

        public string cantidadAdultos { get; set; }
        public string cantidadEntre3y8 { get; set; }
        public string cantidadMenores3 { get; set; }
        public string cantidadAdolescentes { get; set; }

        public string FechaEvento { get; set; }

        public int TipoLogisticaId { get; set; }

        public int LocalidadId { get; set; }



        public int LogisticaCosto { get; set; }

        public string cantidadAdicional { get; set; }

        public int PresupuestoId { get; set; }
    }

    public partial class PersonalEventos
    {

        public string EmpleadoApellidoNombre { get; set; }
        public string TipoEmpleadoDescripcion { get; set; }
        public int TipoEmpleadoId { get; set; }


    }


    public partial class EventosPresupuestos
    {
        public int EventoId { get; set; }
        public int PresupuestoId { get; set; }
        public int ClienteId { get; set; }

    }

}
