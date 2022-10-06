using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Datos;
using System.Transactions;

namespace DomainAmbientHouse.Negocios
{
    public class CostoNegocios
    {

        CostosDatos Datos;

        public CostoNegocios()
        {
            Datos = new CostosDatos();
        }

        public virtual CostoCatering BuscarCostoCatering(int tipoCateringId, int cantidadInvitados, int proveedorId)
        {

            return Datos.BuscarCostoCatering(tipoCateringId, cantidadInvitados, proveedorId);

        }

        public virtual CostoTecnica BuscarCostoTecnica(int tipoServicioId, int segmentoId, int anio, int mes, string dia, int proveedorId)
        {

            return Datos.BuscarCostoTecnica(tipoServicioId, segmentoId, anio, mes, dia, proveedorId);

        }

        public virtual CostoBarra BuscarCostoBarra(int tipoBarra, int cantidadInvitados, int proveedorId)
        {
            return Datos.BuscarCostoBarra(tipoBarra, cantidadInvitados, proveedorId);
        }


        public virtual CostoSalones BuscarCostoSalon(int locacionId, int sectorId, int jornadaId, int anio, int mes, string dia)
        {
            return Datos.BuscarCostoSalon(locacionId, sectorId, jornadaId, anio, mes, dia);

        }

        public CostoAdicionales BuscarCostoAdicionalCatering(int AdicionalId, int cantidadInvitados)
        {
            return Datos.BuscarCostoAdicionalCatering(AdicionalId, cantidadInvitados);
        }

        public virtual List<ObtenerPrecioCostoBarra> ObtenerPrecioCostoBarra()
        {
            return Datos.ObtenerPrecioCostoBarra();
        }

        public virtual List<ObtenerPrecioCostoCatering> ObtenerPrecioCostoCatering()
        {
            return Datos.ObtenerPrecioCostoCatering();
        }

        public virtual List<ObtenerPrecioCostoTecnica> ObtenerPrecioCostoTecnica()
        {
            return Datos.ObtenerPrecioCostoTecnica();
        }

        public virtual CostoLogistica BuscarCostoLogistica(int tipoLogisticaId, int localidadId, int cantInvitados)
        {
            return Datos.BuscarCostoLogistica(tipoLogisticaId, localidadId, cantInvitados);
        }

        public CostoAmbientacion BuscarCostoAmbientacion(int categoriaId, int cantInvitadosCosto, int proveedorId)
        {
            return Datos.BuscarCostoAmbientacion(categoriaId, cantInvitadosCosto, proveedorId);
        }



        public List<CostoCatering> ObtenerCostosCatering()
        {
            return Datos.ObtenerCostoCatering();
        }

        public void ImportarCostosCatering(List<CostoCatering> CostoCateringSalida, int? proveedorId)
        {

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    Datos.EliminarCostoCateringPorProveedor(proveedorId);

                    foreach (var item in CostoCateringSalida)
                    {

                        CostoCatering costo = new CostoCatering();

                        costo.TipoCateringId = item.TipoCateringId;
                        costo.CantidadPersonas = item.CantidadPersonas;
                        costo.Precio = item.Precio;
                        costo.Costo = item.Costo;
                        costo.ProveedorId = item.ProveedorId;
                        costo.ValorMas5PorCiento = double.Parse("1.05");
                        costo.ValorMenos5PorCiento = double.Parse("0.95");
                        costo.ValorMenos10PorCiento = double.Parse("0.90");

                        Datos.NuevoCostoCatering(costo);


                    }

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<CostoBarra> ObtenerCostoBarras()
        {
            return Datos.ObtenerCostoBarras();
        }

        public void ImportarCostosBarras(List<CostoBarra> CostoBarraSalida, int? proveedorId)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    Datos.EliminarCostoBarraPorProveedor(proveedorId);

                    foreach (var item in CostoBarraSalida)
                    {

                        CostoBarra costo = new CostoBarra();

                        costo.TipoBarraId = item.TipoBarraId;
                        costo.CantidadPersonas = item.CantidadPersonas;
                        costo.Precios = item.Precios;
                        costo.Costo = item.Costo;
                        costo.ProveedorId = item.ProveedorId;
                        costo.ValorMas5PorCiento = double.Parse("1.05");
                        costo.ValorMenos5PorCiento = double.Parse("0.95");
                        costo.ValorMenos10PorCiento = double.Parse("0.90");
                        

                        Datos.NuevoCostoBarra(costo);


                    }

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<CostoTecnica> ObtenerCostoTecnica()
        {
            return Datos.ObtenerCostoTecnica();
        }

        public void ImportarCostosTecnica(List<CostoTecnica> CostoTecnicaSalida, int proveedorId, int anio)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    Datos.EliminarCostoTecnicaPorProveedorYAnio(proveedorId, anio);

                    foreach (var item in CostoTecnicaSalida)
                    {

                        CostoTecnica costo = new CostoTecnica();

                        costo.TipoServicioId = item.TipoServicioId;
                        costo.SegmentoId = item.SegmentoId;
                        costo.Precio = item.Precio;
                        costo.Costo = item.Costo;
                        costo.ProveedorId = item.ProveedorId;
                        costo.ValorMas5PorCiento = double.Parse("1.05");
                        costo.ValorMenos5PorCiento = double.Parse("0.95");
                        costo.ValorMenos10PorCiento = double.Parse("0.90");
                        costo.Dia = item.Dia;
                        costo.Mes = item.Mes;
                        costo.Anio = item.Anio;

                        Datos.NuevoCostoTecnica(costo);


                    }

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<CostoAmbientacion> ObtenerCostosAmbientacion()
        {
            return Datos.ObtenerCostoAmbientacion();
        }

        public void ImportarCostosAmbientacion(List<CostoAmbientacion> CostoAmbientacionSalida, int proveedorId)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    Datos.EliminarCostoAmbientacionPorProveedor(proveedorId);

                    foreach (var item in CostoAmbientacionSalida)
                    {

                        CostoAmbientacion costo = new CostoAmbientacion();

                        costo.CategoriaId = item.CategoriaId;
                        costo.Precio = item.Precio;
                        costo.Costo = item.Costo;
                        costo.ProveedorId = item.ProveedorId;
                        costo.CantidadInvitados = item.CantidadInvitados;
                        costo.ValorMas5PorCiento = double.Parse("1.05");
                        costo.ValorMenos5PorCiento = double.Parse("0.95");
                        costo.ValorMenos10PorCiento = double.Parse("0.90");


                        Datos.NuevoCostoAmbientacion(costo);


                    }

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<CostoAdicionales> ObtenerCostosAdicionales()
        {
            return Datos.ObtenerCostoAdicional();
        }

        public void ImportarCostosAdicionales(List<CostoAdicionales> CostoAdicionalesSalida, int? proveedorId, int? locacionId)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    if (proveedorId != null)
                    {
                        Datos.EliminarCostoAdicionalPorProveedor(proveedorId);

                        foreach (var item in CostoAdicionalesSalida)
                        {

                            CostoAdicionales costo = new CostoAdicionales();

                            costo.AdicionalId = item.AdicionalId;
                            costo.Precio = item.Precio;
                            costo.Costo = item.Costo;
                            costo.ProveedorId = item.ProveedorId;
                            costo.CantidadPersonas = item.CantidadPersonas;
                            costo.ValorMas5PorCiento = double.Parse("1.05");
                            costo.ValorMenos5PorCiento = double.Parse("0.95");
                            costo.ValorMenos10PorCiento = double.Parse("0.90");


                            Datos.NuevoCostoAdicionales(costo);


                        }

                    }
                    else if (locacionId != null)
                    {
                        Datos.EliminarCostoAdicionalPorLocacion(locacionId);

                        foreach (var item in CostoAdicionalesSalida)
                        {

                            CostoAdicionales costo = new CostoAdicionales();

                            costo.AdicionalId = item.AdicionalId;
                            costo.Precio = item.Precio;
                            costo.Costo = item.Costo;
                            costo.Locacion = item.Locacion;
                            costo.CantidadPersonas = item.CantidadPersonas;
                            costo.ValorMas5PorCiento = double.Parse("1.05");
                            costo.ValorMenos5PorCiento = double.Parse("0.95");
                            costo.ValorMenos10PorCiento = double.Parse("0.90");


                            Datos.NuevoCostoAdicionales(costo);


                        }
                    }


                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<CostoLogistica> ObtenerCostosLogisticas(int tipoLogisticaId, int localidadId, string cantidadInvitadoId, int tipoEventoId)
        {
            return Datos.ObtenerCostosLogisticas(tipoLogisticaId, localidadId, cantidadInvitadoId, tipoEventoId);
        }

        public void ImportarCostosLogistica(List<CostoLogistica> CostoLogisticaSalida)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    Datos.EliminarCostoLogistica();

                    foreach (var item in CostoLogisticaSalida)
                    {

                        CostoLogistica costo = new CostoLogistica();

                        costo.ConceptoId = item.ConceptoId;
                        costo.Localidad = item.Localidad;
                        costo.CantidadInvitados = item.CantidadInvitados;
                        costo.Valor = item.Valor;



                        Datos.NuevoCostoLogistica(costo);


                    }

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<int> ObtenerCantidadPersonasLogistica()
        {
            return Datos.ObtenerCantidadPersonasLogistica();
        }

        public List<CostoCanon> ObtenerCostosCanon()
        {
            return Datos.ObtenerCostosCanon();
        }

        public void ImportarCostosCanon(List<CostoCanon> CostoCanonSalida)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    Datos.EliminarCostoCanon();

                    foreach (var item in CostoCanonSalida)
                    {

                        CostoCanon costo = new CostoCanon();

                        costo.SegmentoId = item.SegmentoId;
                        costo.CaracteristicaId = item.CaracteristicaId;
                        costo.TipoCateringId = item.TipoCateringId;
                        costo.CanonInterno = item.CanonInterno;
                        costo.CanonExterno = item.CanonExterno;
                        costo.UsoCocina = item.UsoCocina;


                        Datos.NuevoCostoCanon(costo);


                    }

                    scope.Complete();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public CostoCanon BuscarCostoCanon(int segmentoId, int caracteriticaId, int TipoCateringId)
        {
            return Datos.BuscarCostoCanon(segmentoId, caracteriticaId, TipoCateringId);
        }

        public List<CostoSalones> ObtenerCostoSalones()
        {
            return Datos.ObtenerCostoSalones();
        }

        public void ImportarCostosLocaciones(List<CostoSalones> CostoSalonesSalida, int locacionId, int anio)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {


                    Datos.EliminarCostoSalones(locacionId, anio);

                    foreach (var item in CostoSalonesSalida)
                    {

                        CostoSalones costo = new CostoSalones();

                        costo.LocacionId = locacionId;
                        costo.SectorId = item.SectorId;
                        costo.JornadaId = item.JornadaId;
                        costo.Costo = item.Costo;
                        costo.Precio = item.Precio;
                        costo.Anio = anio;
                        costo.Mes = item.Mes;
                        costo.Dia = item.Dia;
                        costo.CantidadInvitados = item.CantidadInvitados;
                        costo.PorcentajedelTotal = item.PorcentajedelTotal;
                        costo.ValorMas5PorCiento = double.Parse("1.05");
                        costo.ValorMenos5PorCiento = double.Parse("0.95");
                        costo.ValorMenos10PorCiento = double.Parse("0.90");
                       

                        Datos.NuevoCostoSalon(costo);


                    }
                    

                    scope.Complete();
                }
                catch (Exception e)
                {

                    DomainAmbientHouse.Servicios.Log.save(this, e);
                }
            }

        }

        public CostoLogistica BuscarCostoLogistica(int tipoLogisticaId, int localidadId, int cantInvitados, int tipoEventoId)
        {
            return Datos.BuscarCostoLogistica( tipoLogisticaId,  localidadId,  cantInvitados,  tipoEventoId);
        }

        public CostoLogistica BuscarCostoLogistica(int id)
        {
            return Datos.BuscarCostoLogistica(id);
        }

        public void ActualizarCostoLogistica(CostoLogistica costos)
        {
            Datos.ActualizarCostoLogistica(costos);
        }

        public void NuevoCostoLogistica(CostoLogistica costo)
        {
            Datos.NuevoCostoLogistica(costo);
        }



        public CostoCanon BuscarCostoCanon(int id)
        {
            return Datos.BuscarCostoCanon(id);
        }

        public void NuevoCostoCannon(CostoCanon cc)
        {
            Datos.NuevoCostoCanon(cc);
        }
        internal List<CargarCostosTecnica_Result> CargarPrecioCostostecnica(ParametrosCostoTecnica param)
        {
            return Datos.CargarPrecioCostosTecnica(param);
        }
    }
}
