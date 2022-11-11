﻿using DomainAmbientHouse.Entidades;
using DomainAmbientHouse.Servicios;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.SessionState;

namespace AmbientHouse.Presupuestos
{
    /// <summary>
    /// Summary description for Presupuesto
    /// </summary>
    public class Presupuesto : IHttpHandler, IRequiresSessionState
    {

        private PresupuestoPDF Presupuestos
        {
            get { return (PresupuestoPDF)HttpContext.Current.Session["PresupuestoCliente"]; }
            set { HttpContext.Current.Session["PresupuestoCliente"] = value; }
        }

        private int SegmentosId
        {
            get
            {
                return Int32.Parse(HttpContext.Current.Session["SegmentosId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["SegmentosId"] = value;
            }
        }

        private int CaracteristicasId
        {
            get
            {
                return Int32.Parse(HttpContext.Current.Session["CaracteristicasId"].ToString());
            }
            set
            {
                HttpContext.Current.Session["CaracteristicasId"] = value;
            }
        }

        private PresupuestosServicios servicio = new PresupuestosServicios();
        private Comun cmd = new Comun();
        private AdministrativasServicios serviciosAdministrativas = new AdministrativasServicios();

        public void ProcessRequest(HttpContext context)
        {

            int RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());

            int RubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
            int RubroAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());

            int aprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());

            int caracteristicaId = Int32.Parse(ConfigurationManager.AppSettings["Informal"].ToString());
            int segmentoId = Int32.Parse(ConfigurationManager.AppSettings["Corporativo"].ToString());

            try
            {

                decimal TotalDescuento = 0;

                int Lahusen = Int32.Parse(ConfigurationManager.AppSettings["Lahusen"].ToString());
                int TOM = Int32.Parse(ConfigurationManager.AppSettings["TOM"].ToString());
                int NH = Int32.Parse(ConfigurationManager.AppSettings["NH"].ToString());
                int GM = Int32.Parse(ConfigurationManager.AppSettings["GALPONMILAGROS"].ToString());
                int OTRA = Int32.Parse(ConfigurationManager.AppSettings["OTRA"].ToString());


                string pdfTemplate;

                if (Presupuestos.LocacionId == Lahusen)
                {
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantilla Edificio Lahusen Cliente.pdf";
                }
                else if (Presupuestos.LocacionId == TOM)
                {
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantilla Terrazas Cliente.pdf";
                }
                else if (Presupuestos.LocacionId == NH)
                {
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantilla NH.pdf";
                }
                else if (Presupuestos.LocacionId == GM)
                {
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantilla Galpon Milagros.pdf";
                }
                else
                {
                    pdfTemplate = System.Web.HttpContext.Current.Server.MapPath("~/AppShared") + "\\Plantilla Ambient House Cliente.pdf";
                }

                string newFile = "Presupuesto.pdf";
                MemoryStream _MemoryStream = new MemoryStream();
                PdfReader reader = new PdfReader(pdfTemplate);
                PdfStamper pdfStamper = new PdfStamper(reader, _MemoryStream);
                Dictionary<string, string> infoOriginal = reader.Info;
                Dictionary<string, string> info = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> s in infoOriginal)
                {
                    info[s.Key] = string.Empty;  //con esto elimino la metadata del pdf
                }

                info["Application"] = string.Empty;
                info["Producer"] = string.Empty;
                info["ModDate "] = string.Empty;
                pdfStamper.MoreInfo = info;
                AcroFields pdfFormFields = pdfStamper.AcroFields;
                pdfFormFields.SetField("Cliente", Convert.ToString(Presupuestos.ApellidoNombre));
                pdfFormFields.SetField("RazonSocial", Convert.ToString(Presupuestos.RazonSocial));

                pdfFormFields.SetField("NroPresupuesto", Convert.ToString(Presupuestos.PresupuestoId));
                pdfFormFields.SetField("Mail", Convert.ToString(Presupuestos.Mail));
                pdfFormFields.SetField("Telefono", Convert.ToString(Presupuestos.Celular));
                pdfFormFields.SetField("TipoEvento", Convert.ToString(Presupuestos.TipoEvento));
                pdfFormFields.SetField("Caracteristica", Convert.ToString(Presupuestos.Caracteristica));
                //pdfFormFields.SetField("Locacion", Convert.ToString(Presupuestos.Locacion));

                pdfFormFields.SetField("NROEvento", Convert.ToString(Presupuestos.EventoId));

                if (Presupuestos.LocacionId == OTRA)
                { pdfFormFields.SetField("Locacion", Convert.ToString(Presupuestos.LocacionOtra)); }
                else { pdfFormFields.SetField("Locacion", Convert.ToString(Presupuestos.Locacion)); }


                pdfFormFields.SetField("Canal", Convert.ToString(Presupuestos.Segmento));
                pdfFormFields.SetField("Sector", Convert.ToString(Presupuestos.Sector));
                pdfFormFields.SetField("Jornada", Convert.ToString(Presupuestos.Jornada));
                pdfFormFields.SetField("Ejecutivo", Convert.ToString(Presupuestos.Ejecutivo));
                pdfFormFields.SetField("Fecha", String.Format("{0:dd/MM/yyyy}", Presupuestos.FechaContacto));
                pdfFormFields.SetField("FechaEventos", String.Format("{0:dd/MM/yyyy}", Presupuestos.FechaEvento));
                pdfFormFields.SetField("FechaPresupuesto", String.Format("{0:dd/MM/yyyy}", Presupuestos.FechaPresupuesto));

                int CantidadInvitadosTotal = Int32.Parse(Presupuestos.CantidadInicialInvitados.ToString())
                            + (Presupuestos.CantidadInvitadosAdolecentes != null ? Int32.Parse(Presupuestos.CantidadInvitadosAdolecentes.ToString()) : 0)
                            + (Presupuestos.CantidadInvitadosMenores3 != null ? Int32.Parse(Presupuestos.CantidadInvitadosMenores3.ToString()) : 0)
                            + (Presupuestos.CantidadInvitadosMenores3y8 != null ? Int32.Parse(Presupuestos.CantidadInvitadosMenores3y8.ToString()) : 0)
                            + (Presupuestos.CantidadAdultosFinal != null ? Int32.Parse(Presupuestos.CantidadAdultosFinal.ToString()) : 0)
                            + (Presupuestos.CantidadInvitadosAdolecentesFinal != null ? Int32.Parse(Presupuestos.CantidadInvitadosAdolecentesFinal.ToString()) : 0)
                            + (Presupuestos.CantidadInvitadosMenores3Final != null ? Int32.Parse(Presupuestos.CantidadInvitadosMenores3Final.ToString()) : 0)
                            + (Presupuestos.CantidadInvitadosMenores3y8Final != null ? Int32.Parse(Presupuestos.CantidadInvitadosMenores3y8Final.ToString()) : 0);


                pdfFormFields.SetField("CantInvi", Convert.ToString(CantidadInvitadosTotal));
                pdfFormFields.SetField("CantEventos", Convert.ToString(CantidadInvitadosTotal));

                pdfFormFields.SetField("CantInviAdo", Convert.ToString(Presupuestos.CantidadInvitadosAdolecentes));
                pdfFormFields.SetField("CantInvi3", Convert.ToString(Presupuestos.CantidadInvitadosMenores3));
                pdfFormFields.SetField("CantInvi3y8", Convert.ToString(Presupuestos.CantidadInvitadosMenores3y8));

                pdfFormFields.SetField("Comentario", Convert.ToString(Presupuestos.ComentarioPresupuesto));



                double PrecioTotal = servicio.CalcularValorTotalPresupuestoPorPresupuestoId((int)Presupuestos.PresupuestoId);
                double PrecioPAX = PrecioTotal / CantidadInvitadosTotal;

                //pdfFormFields.SetField("TotalPresupuesto", Convert.ToString(Math.Ceiling(PrecioTotal)));

                pdfFormFields.SetField("TotalPresupuesto", formatoNumero(PrecioTotal));
                //pdfFormFields.SetField("Pax", Convert.ToString(Math.Ceiling(PrecioPAX)));
                pdfFormFields.SetField("Pax", formatoNumero(PrecioPAX));

                //pdfFormFields.SetField("TotalPresupuesto", Convert.ToString(Math.Ceiling((double)Presupuestos.PrecioTotal)));
                //pdfFormFields.SetField("Pax", Convert.ToString(Math.Ceiling((double)Presupuestos.PrecioPorPersona)));

                List<ListarAdicionalesPorPresupuesto> adicionales = servicio.ObtenerAdicionales((int)Presupuestos.PresupuestoId, aprobado);

                double precioConsolidado = 0;
                decimal valorTotalAdicional = 0;

                if (adicionales.Count > 0)
                {
                    foreach (var item in adicionales)
                    {
                        valorTotalAdicional = valorTotalAdicional + decimal.Parse(item.ValorAdicional.ToString());
                    }

                    pdfFormFields.SetField("TotalAdicionales", Convert.ToString(Math.Ceiling((double)valorTotalAdicional)));

                    ArmarAdicionales(adicionales, pdfFormFields);
                    //ArmarTablaExcelPDF(adicionales, Int32.Parse(Presupuestos.PresupuestoId.ToString()));
                }
                else
                { pdfFormFields.SetField("SINADIONALES", Convert.ToString("SIN ADICIONALES")); }


                //var presupuestoSalon = servicio.ObtenerPresupuestosSalon((int)Presupuestos.PresupuestoId);

                List<PresupuestoDetalle> presupuestoSalon = servicio.ObtenerPresupuestoDetalle((int)Presupuestos.PresupuestoId, RubroSalon, aprobado);

                foreach (var item in presupuestoSalon)
                {
                    Locaciones locacion = serviciosAdministrativas.BuscarLocaciones((int)item.LocacionId);

                    pdfFormFields.SetField("Salon", Convert.ToString(locacion.Descripcion));
                    pdfFormFields.SetField("SalonMas5", Convert.ToString(item.PrecioMas5.ToString()));
                    pdfFormFields.SetField("SalonPL", Convert.ToString(item.PrecioLista.ToString()));
                    pdfFormFields.SetField("SalonMenos5", Convert.ToString(item.PrecioMenos5));
                    pdfFormFields.SetField("SalonMenos10", Convert.ToString(item.PrecioMenos10));

                    if (cmd.IsNumeric(item.Descuentos))
                    {
                        TotalDescuento = TotalDescuento + decimal.Parse(item.Descuentos.ToString());
                    }

                    pdfFormFields.SetField("SalonVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado)));

                    if (System.Math.Round(item.ValorSeleccionado, 2) < System.Math.Round(item.PrecioMas5, 2))
                    {
                        pdfFormFields.SetField("SalonB", Convert.ToString("Desc. Especial"));
                    }

                    precioConsolidado = precioConsolidado + item.PrecioMas5;
                }

                List<PresupuestoDetalle> presupuestoTecnica = servicio.ObtenerPresupuestoDetalle((int)Presupuestos.PresupuestoId, RubroTecnica, aprobado);


                foreach (var item in presupuestoTecnica)
                {
                    Proveedores prov = serviciosAdministrativas.BuscarProveedor((int)item.ProveedorId);
                    TipoServicios ts = serviciosAdministrativas.BuscarTipoServicios((int)item.ServicioId);

                    pdfFormFields.SetField("ProveedorTecnica", Convert.ToString(prov.RazonSocial));
                    //pdfFormFields.SetField("CanalTecnica", Convert.ToString(item.Canal));
                    pdfFormFields.SetField("ServicioTecnica", Convert.ToString(ts.Descripcion));
                    pdfFormFields.SetField("TecnicaMas5", Convert.ToString(item.PrecioMas5));
                    pdfFormFields.SetField("TecnicaPL", Convert.ToString(item.PrecioLista.ToString()));
                    pdfFormFields.SetField("TecnicaMenos5", Convert.ToString(item.PrecioMenos5));
                    pdfFormFields.SetField("TecnicaMenos10", Convert.ToString(item.PrecioMenos10));
                    pdfFormFields.SetField("TecnicaVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado)));

                    if (cmd.IsNumeric(item.Descuentos))
                    {
                        TotalDescuento = TotalDescuento + decimal.Parse(item.Descuentos.ToString());
                    }

                    if (System.Math.Round(item.ValorSeleccionado, 2) < System.Math.Round(item.PrecioMas5, 2))
                    {
                        pdfFormFields.SetField("TecnicaB", Convert.ToString("Desc. Especial"));
                    }

                    precioConsolidado = precioConsolidado + item.PrecioMas5;
                }



                List<PresupuestoDetalle> presupuestoCatering = servicio.ObtenerPresupuestoDetalle((int)Presupuestos.PresupuestoId, RubroCatering, aprobado);

                double valorCanonLogistica = 0;

                foreach (var item in presupuestoCatering)
                {
                    Proveedores prov = serviciosAdministrativas.BuscarProveedor((int)item.ProveedorId);
                    TipoCatering ts = serviciosAdministrativas.BuscarTipoCatering((int)item.ServicioId);

                    pdfFormFields.SetField("ProveedorCatering", Convert.ToString(prov.RazonSocial));
                    pdfFormFields.SetField("Experiencia", Convert.ToString(ts.Descripcion));

                    if (cmd.IsNumeric(item.Logistica) && cmd.IsNumeric(item.Cannon))
                    {
                        pdfFormFields.SetField("CateringMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5 + (double)item.Logistica + ((double)item.Cannon) * CantidadInvitadosTotal)));
                        pdfFormFields.SetField("CateringVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado + (double)item.Logistica + ((double)item.Cannon * CantidadInvitadosTotal))));

                        valorCanonLogistica = (double)item.Logistica + ((double)item.Cannon);

                    }
                    else if (cmd.IsNumeric(item.Cannon))
                    {
                        pdfFormFields.SetField("CateringMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5 + ((double)item.Cannon * CantidadInvitadosTotal))));
                        pdfFormFields.SetField("CateringVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado + ((double)item.Cannon * CantidadInvitadosTotal))));

                        valorCanonLogistica = ((double)item.Cannon);
                    }
                    else if (cmd.IsNumeric(item.Logistica))
                    {
                        pdfFormFields.SetField("CateringMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5 + (double)item.Logistica)));
                        pdfFormFields.SetField("CateringVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado + (double)item.Logistica)));

                        valorCanonLogistica = (double)item.Logistica;
                    }

                    else
                    {
                        pdfFormFields.SetField("CateringMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5)));
                        pdfFormFields.SetField("CateringVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado)));
                    }

                    pdfFormFields.SetField("CateringPL", Convert.ToString(item.PrecioLista));
                    pdfFormFields.SetField("CateringMenos5", Convert.ToString(item.PrecioMenos5));
                    pdfFormFields.SetField("CateringMenos10", Convert.ToString(item.PrecioMenos10));

                    if (cmd.IsNumeric(item.Descuentos))
                    {
                        TotalDescuento = TotalDescuento + decimal.Parse(item.Descuentos.ToString());
                    }




                    if (System.Math.Round(item.ValorSeleccionado, 2) < System.Math.Round(item.PrecioMas5, 2))
                    {
                        pdfFormFields.SetField("CateringB", Convert.ToString("Desc. Especial"));
                    }

                    precioConsolidado = precioConsolidado + item.PrecioMas5 + valorCanonLogistica;
                }


                List<PresupuestoDetalle> presupuestoBarra = servicio.ObtenerPresupuestoDetalle((int)Presupuestos.PresupuestoId, RubroBarra, aprobado);

                double valorCanonLogisticaBarras = 0;

                foreach (var item in presupuestoBarra)
                {

                    Proveedores prov = serviciosAdministrativas.BuscarProveedor((int)item.ProveedorId);
                    TiposBarras ts = serviciosAdministrativas.BuscarTipoBarras((int)item.ServicioId);

                    pdfFormFields.SetField("BarraProveedor", Convert.ToString(prov.RazonSocial));
                    pdfFormFields.SetField("BarraTipoBarra", Convert.ToString(ts.Descripcion));
                    //pdfFormFields.SetField("BarraSalonInOut", Convert.ToString(presupuestoBarra.SalonInOut));
                    pdfFormFields.SetField("BarraMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5)));
                    pdfFormFields.SetField("BarraPL", Convert.ToString(item.PrecioLista));
                    pdfFormFields.SetField("BarraMenos5", Convert.ToString(item.PrecioMenos5));
                    pdfFormFields.SetField("BarraMenos10", Convert.ToString(item.PrecioMenos10));
                    pdfFormFields.SetField("BarraVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado)));


                    if (cmd.IsNumeric(item.Logistica) && cmd.IsNumeric(item.Cannon))
                    {
                        pdfFormFields.SetField("BarraMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5 + (double)item.Logistica + ((double)item.Cannon) * CantidadInvitadosTotal)));
                        pdfFormFields.SetField("BarraVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado + (double)item.Logistica + ((double)item.Cannon * CantidadInvitadosTotal))));

                        valorCanonLogisticaBarras = (double)item.Logistica + ((double)item.Cannon);

                    }
                    else if (cmd.IsNumeric(item.Cannon))
                    {
                        pdfFormFields.SetField("BarraMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5 + ((double)item.Cannon * CantidadInvitadosTotal))));
                        pdfFormFields.SetField("BarraVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado + ((double)item.Cannon * CantidadInvitadosTotal))));

                        valorCanonLogisticaBarras = ((double)item.Cannon);
                    }
                    else if (cmd.IsNumeric(item.Logistica))
                    {
                        pdfFormFields.SetField("BarraMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5 + (double)item.Logistica)));
                        pdfFormFields.SetField("BarraVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado + (double)item.Logistica)));

                        valorCanonLogisticaBarras = (double)item.Logistica;
                    }

                    else
                    {
                        pdfFormFields.SetField("BarraMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5)));
                        pdfFormFields.SetField("BarraVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado)));
                    }



                    if (cmd.IsNumeric(item.Descuentos))
                    {
                        TotalDescuento = TotalDescuento + decimal.Parse(item.Descuentos.ToString());
                    }

                    if (System.Math.Round(item.ValorSeleccionado, 2) < System.Math.Round(item.PrecioMas5, 2))
                    {
                        pdfFormFields.SetField("BarraB", Convert.ToString("Desc. Especial"));
                    }

                    precioConsolidado = precioConsolidado + item.PrecioMas5 + valorCanonLogisticaBarras;

                }


                List<PresupuestoDetalle> presupuestoAmbientacion = servicio.ObtenerPresupuestoDetalle((int)Presupuestos.PresupuestoId, RubroAmbientacion, aprobado);



                foreach (var item in presupuestoAmbientacion)
                {

                    Proveedores prov = serviciosAdministrativas.BuscarProveedor((int)item.ProveedorId);
                    Categorias ts = serviciosAdministrativas.BuscarCategorias((int)item.ServicioId);


                    AmbientacionCI ambCorporativoInformal = new AmbientacionCI();
                    if (CaracteristicasId == caracteristicaId && SegmentosId == segmentoId)
                    {
                        ambCorporativoInformal = serviciosAdministrativas.BuscarAmbientacionCI((int)item.ServicioId);

                        pdfFormFields.SetField("AmbientacionCaracteristicas", Convert.ToString(ambCorporativoInformal.Descripcion));
                    }
                    else
                    {
                        pdfFormFields.SetField("AmbientacionCaracteristicas", Convert.ToString(ts.Descripcion));
                    }


                    pdfFormFields.SetField("AmbientacionProveedor", Convert.ToString(prov.RazonSocial));
                    //pdfFormFields.SetField("AmbientacionSegmento", Convert.ToString(presupuestoAmbientacion.Segmento));
                    //pdfFormFields.SetField("AmbientacionSector", Convert.ToString(presupuestoAmbientacion.Sector));
                    //pdfFormFields.SetField("AmbientacionCaracteristicas", Convert.ToString(presupuestoAmbientacion.Caracteristicas));
                    //pdfFormFields.SetField("AmbientacionCategoria", Convert.ToString(presupuestoAmbientacion.Categoria));
                    pdfFormFields.SetField("AmbientacionMas5", Convert.ToString(Math.Ceiling(item.PrecioMas5)));
                    pdfFormFields.SetField("AmbientacionPL", Convert.ToString(item.PrecioLista));
                    pdfFormFields.SetField("AmbientacionMenos5", Convert.ToString(item.PrecioMenos5));
                    pdfFormFields.SetField("AmbientacionMenos10", Convert.ToString(item.PrecioMenos10));
                    pdfFormFields.SetField("AmbientacionVS", Convert.ToString(Math.Ceiling((double)item.ValorSeleccionado)));

                    if (cmd.IsNumeric(item.Descuentos))
                    {
                        TotalDescuento = TotalDescuento + decimal.Parse(item.Descuentos.ToString());
                    }

                    if (System.Math.Round(item.ValorSeleccionado, 2) < System.Math.Round(item.PrecioMas5, 2))
                    {
                        pdfFormFields.SetField("AmbientacionB", Convert.ToString("Desc. Especial"));
                    }

                    precioConsolidado = precioConsolidado + item.PrecioMas5;
                }



                if (TotalDescuento > 0)
                {
                    pdfFormFields.SetField("TotalDescuento", Convert.ToString(Math.Ceiling(TotalDescuento)));
                }
                else
                {
                    pdfFormFields.SetField("TotalDescuento", Convert.ToString("-"));
                }
                //pdfFormFields.SetField("TotalConsolidado", Convert.ToString(Math.Ceiling(precioConsolidado));
                pdfFormFields.SetField("TotalConsolidado", formatoNumero(precioConsolidado));

                pdfStamper.FormFlattening = true;
                pdfStamper.Close();

                context.Response.ClearHeaders();
                context.Response.ClearContent();
                context.Response.ContentType = "application/pdf";
                context.Response.AddHeader("content-disposition", "inline; filename=" + newFile);

                context.Response.BinaryWrite(_MemoryStream.ToArray());
                context.Response.End();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void ArmarAdicionales(List<ListarAdicionalesPorPresupuesto> adicionales, AcroFields pdfFormFields)
        {

            pdfFormFields.SetField("NROITEM", Convert.ToString("Nro. Item"));
            pdfFormFields.SetField("DESCRIPCION", Convert.ToString("Descripcion"));
            pdfFormFields.SetField("RUBRO", Convert.ToString("Rubro"));
            pdfFormFields.SetField("CANT", Convert.ToString("Cant."));

            int i = 0;

            foreach (var item in adicionales)
            {
                i = i + 1;

                if (i < 22)
                {

                    pdfFormFields.SetField("NROITEM" + i.ToString(), Convert.ToString(item.AdicionalId));
                    pdfFormFields.SetField("DESCRIPCION" + i.ToString(), Convert.ToString(item.Descripcion));
                    pdfFormFields.SetField("RUBRO" + i.ToString(), Convert.ToString(item.RubroDescripcion));
                    pdfFormFields.SetField("CANT" + i.ToString(), Convert.ToString(item.Cantidad));
                }
            }
        }

        private string formatoNumero(double numero)
        {

            NumberFormatInfo formato = new CultureInfo("es-AR").NumberFormat;

            formato.CurrencyGroupSeparator = ".";
            formato.NumberDecimalSeparator = ",";

            //puedes cambiar el simbolo $ por otro.
            //formato.CurrencySymbol = "$";

            return numero.ToString("C", formato);

        }


    }
}