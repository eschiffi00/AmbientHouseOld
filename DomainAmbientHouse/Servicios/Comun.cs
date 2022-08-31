using DomainAmbientHouse.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using DomainAmbientHouse.Negocios;
using System.Configuration;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;


namespace DomainAmbientHouse.Servicios
{
    public class Comun
    {
        AdicionalesNegocios adicionales = new AdicionalesNegocios();
        EventosNegocios eventos = new EventosNegocios();
        ParametrosNegocios parametros = new ParametrosNegocios();
        OrganizacionNegocios organizacion = new OrganizacionNegocios();
        PresupuestosNegocios presupuestos = new PresupuestosNegocios();
        PresupuestoDetalleNegocios detallePresupuesto = new PresupuestoDetalleNegocios();

        public bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public string QuitarAcentos(string texto)
        {
            string consignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ";
            string sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";
            for (int v = 0; v < sinsignos.Length; v++)
            {
                string i = consignos.Substring(v, 1);
                string j = sinsignos.Substring(v, 1);
                texto = texto.Replace(i, j);
            }
            return texto;
        }

        public string ConvertirIdioma(string valor)
        {
            switch (valor)
            {
                case "Monday":
                    return "Lunes";
                case "Tuesday":
                    return "Martes";
                case "Wednesday":
                    return "Miercoles";
                case "Thursday":
                    return "Jueves";
                case "Friday":
                    return "Viernes";
                case "Saturday":
                    return "Sabado";
                case "Sunday":
                    return "Domingo";
                default:
                    return valor;
            }
        }

        public void CargarAnios(DropDownList anios)
        {
            int AnioActual = DateTime.Now.Year;
            int AnioRango = AnioActual + 5;


            for (int i = AnioActual; i < AnioRango; i++)
            {

                ListItem anio = new ListItem();

                anio.Text = i.ToString();
                anio.Value = i.ToString();

                anios.Items.Add(anio);

            }

        }

        public int ObtenerTrimetreActual()
        {
            int mesActual = System.DateTime.Today.Month;


            if (mesActual >= 1 || mesActual <= 3)
            {
                return 1;
            }
            else if (mesActual >= 4 || mesActual <= 6)
            {
                return 2;
            }
            else if (mesActual >= 7 || mesActual <= 9)
            {
                return 3;
            }
            else
            {
                return 4;
            }


        }

        public bool IsDate(object inValue)
        {
            bool bValid;
            try
            {
                DateTime myDT = DateTime.Parse(inValue.ToString());
                bValid = true;
            }
            catch (Exception e)
            {
                bValid = false;
            }
            return bValid;
        }

        public bool ValidarCuilCuit(string Cuit)
        {
            Regex rg = new Regex("[A-Z_a-z]");
            Cuit = Cuit.Replace("-", "");
            if (rg.IsMatch(Cuit))
                return false;
            if (Cuit.Length != 11)
                return false;
            char[] cuitArray = Cuit.ToCharArray();
            double sum = 0;
            int bint = 0;
            int j = 7;
            for (int i = 5, c = 0; c != 10; i--, c++)
            {
                if (i >= 2)
                    sum += (Char.GetNumericValue(cuitArray[c]) * i);
                else
                    bint = 1;
                if (bint == 1 && j >= 2)
                {
                    sum += (Char.GetNumericValue(cuitArray[c]) * j);
                    j--;
                }
            }
            if ((cuitArray.Length - (sum % 11)) == Char.GetNumericValue(cuitArray[cuitArray.Length - 1]))
                return true;
            return false;
        }

        public void CargarMeses(DropDownList Meses)
        {
            for (int i = 1; i <= 12; i++)
            {

                ListItem mes = new ListItem();

                mes.Text = i.ToString().PadLeft(2, '0');
                mes.Value = i.ToString().PadLeft(2, '0');

                Meses.Items.Add(mes);
            }
        }
        

        public void CargarDias(DropDownList Dias)
        {

            ListItem itemLunes = new ListItem();
            itemLunes.Text = "Lunes";
            itemLunes.Value = "Lunes";

            Dias.Items.Add(itemLunes);

            ListItem itemMartes = new ListItem();
            itemMartes.Text = "Martes";
            itemMartes.Value = "Martes";
            Dias.Items.Add(itemMartes);

            ListItem itemMiercoles = new ListItem();
            itemMiercoles.Text = "Miercoles";
            itemMiercoles.Value = "Miercoles";
            Dias.Items.Add(itemMiercoles);

            ListItem itemJueves = new ListItem();
            itemJueves.Text = "Jueves";
            itemJueves.Value = "Jueves";
            Dias.Items.Add(itemJueves);

            ListItem itemViernes = new ListItem();
            itemViernes.Text = "Viernes";
            itemViernes.Value = "Viernes";
            Dias.Items.Add(itemViernes);

            ListItem itemSabado = new ListItem();
            itemSabado.Text = "Sabado";
            itemSabado.Value = "Sabado";
            Dias.Items.Add(itemSabado);

            ListItem itemDomingo = new ListItem();
            itemDomingo.Text = "Domingo";
            itemDomingo.Value = "Domingo";
            Dias.Items.Add(itemDomingo);


        }
        public void CargarDiasMultiselect(ListBox Dias)
        {

            ListItem itemLunes = new ListItem();
            itemLunes.Text = "Lunes";
            itemLunes.Value = "Lunes";

            Dias.Items.Add(itemLunes);

            ListItem itemMartes = new ListItem();
            itemMartes.Text = "Martes";
            itemMartes.Value = "Martes";
            Dias.Items.Add(itemMartes);

            ListItem itemMiercoles = new ListItem();
            itemMiercoles.Text = "Miercoles";
            itemMiercoles.Value = "Miercoles";
            Dias.Items.Add(itemMiercoles);

            ListItem itemJueves = new ListItem();
            itemJueves.Text = "Jueves";
            itemJueves.Value = "Jueves";
            Dias.Items.Add(itemJueves);

            ListItem itemViernes = new ListItem();
            itemViernes.Text = "Viernes";
            itemViernes.Value = "Viernes";
            Dias.Items.Add(itemViernes);

            ListItem itemSabado = new ListItem();
            itemSabado.Text = "Sabado";
            itemSabado.Value = "Sabado";
            Dias.Items.Add(itemSabado);

            ListItem itemDomingo = new ListItem();
            itemDomingo.Text = "Domingo";
            itemDomingo.Value = "Domingo";
            Dias.Items.Add(itemDomingo);


        }
        public void CargarMesesMultiselect(ListBox Meses)
        {
            for (int i = 1; i <= 12; i++)
            {

                ListItem mes = new ListItem();

                mes.Text = i.ToString().PadLeft(2, '0');
                mes.Value = i.ToString().PadLeft(2, '0');

                Meses.Items.Add(mes);
            }
        }
        public void CargarAniosMultiselect(ListBox anios)
        {
            int AnioActual = DateTime.Now.Year;
            int AnioRango = AnioActual + 5;


            for (int i = AnioActual; i < AnioRango; i++)
            {

                ListItem anio = new ListItem();

                anio.Text = i.ToString();
                anio.Value = i.ToString();

                anios.Items.Add(anio);

            }

        }

        public bool ValidarExtensionImagenes(string extension)
        {
            if (extension == ".jpg"
                || extension == ".jpeg"
                || extension == ".png"
                || extension == ".gif"
                || extension == ".bmp")
                return true;


            return false;

        }

        public bool ValidarExtensionTexto(string extension)
        {
            if (extension == ".docx"
                || extension == ".pdf")
                return true;


            return false;

        }

        public string ArmarCodigoAdicional(int adicionalId, int cantidadTotalInvitados)
        {
            string Categoria = "AD";

            string tipoAmbientacion = adicionalId.ToString();

            Adicionales adi = adicionales.BuscarAdicional(adicionalId);

            string Proveedor = "P";

            string proveedorId = (adi.ProveedorId == null ? "0" : adi.ProveedorId.ToString());

            string Locacion = "L";

            string locacionId = (adi.LocacionId == null ? "0" : adi.LocacionId.ToString());

            string CantidadInvitados = "I";


            Adicionales adicional = adicionales.BuscarAdicional(adicionalId);



            List<ObtenerCantidadInvitadosCatering> Cantidades = eventos.TraerCantidadPersonasCatering();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, cantidadTotalInvitados);


            string cantidadInvitadosId = cantInvitadosCosto.ToString();


            if (adicional.RequiereCantidad == "S")
            {
                return Categoria + tipoAmbientacion + Proveedor + proveedorId + Locacion + locacionId + CantidadInvitados + 1;
            }
            else
            {
                return Categoria + tipoAmbientacion + Proveedor + proveedorId + Locacion + locacionId + CantidadInvitados + cantidadInvitadosId;
            }


        }

        public string ArmarCodigoCatering(int tipoCateringId, int proveedorId, int cantidadTotalInvitados)
        {
            string Categoria = "C";

            string tipoCatering = tipoCateringId.ToString();

            string Proveedor = "P";

            string proveedor = proveedorId.ToString();

            string CantidadInvitados = "I";


            List<ObtenerCantidadInvitadosCatering> Cantidades = eventos.TraerCantidadPersonasCatering();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, cantidadTotalInvitados);


            string cantidadInvitadosId = cantInvitadosCosto.ToString();

            return Categoria + tipoCatering + Proveedor + proveedor + CantidadInvitados + cantidadInvitadosId;
        }

        public string ArmarCodigoTecnica(string fechaEvento, int tipoTecnicaId, int proveedorId, int segmentoId,int sectorId)
        {

            DateTime fechaSeleccionada = DateTime.ParseExact(fechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string Categoria = "T";

            string tipoServicio = tipoTecnicaId.ToString();

            string Proveedor = "P";

            string proveedor = proveedorId.ToString();

            string Segmento = "S";

            string segmento = segmentoId.ToString();

            int mes = DateTime.Parse(fechaSeleccionada.ToString()).Month;

            int anio = DateTime.Parse(fechaSeleccionada.ToString()).Year;

            string dia = ConvertirIdioma(DateTime.Parse(fechaSeleccionada.ToString()).DayOfWeek.ToString());

            string Sector = "S";

            string SectorId = sectorId.ToString();


            return Categoria + tipoServicio + Proveedor + proveedor + Segmento + segmento + anio + mes + dia + Sector + SectorId;

        }

        public string ArmarCodigoSalon(string fechaEvento, int locacionId, int sectorId, int jornadaId, int cantidadTotalInvitados)
        {
            DateTime fechaSeleccionada = DateTime.ParseExact(fechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string Categoria = "L";

            string locacion = locacionId.ToString();

            string Sector = "S";

            string sector = sectorId.ToString();

            string Jornadas = "J";

            string jornada = jornadaId.ToString();

            int mes = DateTime.Parse(fechaSeleccionada.ToString()).Month;

            int anio = DateTime.Parse(fechaSeleccionada.ToString()).Year;

            string dia = ConvertirIdioma(DateTime.Parse(fechaSeleccionada.ToString()).DayOfWeek.ToString());


            string CantidadInvitados = "I";

            List<ObtenerCantidadInvitadosCatering> Cantidades = eventos.TraerCantidadPersonasCatering();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, cantidadTotalInvitados);


            string cantidadInvitadosId = cantInvitadosCosto.ToString();


            return Categoria + locacion + Sector + sector + Jornadas + jornada + anio + mes + dia + CantidadInvitados + cantidadInvitadosId;

        }

        public string ArmarCodigoBarra(int tipoBarraId, int proveedorId, int cantidadTotalInvitados)
        {
            string Categoria = "B";

            string tipoBarra = tipoBarraId.ToString();

            string Proveedor = "P";

            string proveedor = proveedorId.ToString();

            string CantidadInvitados = "I";


            List<ObtenerCantidadInvitadosCatering> Cantidades = eventos.TraerCantidadPersonasCatering();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, cantidadTotalInvitados);


            string cantidadInvitadosId = cantInvitadosCosto.ToString();

            return Categoria + tipoBarra + Proveedor + proveedor + CantidadInvitados + cantidadInvitadosId;

        }

        public string ArmarCodigoAmbientacion(int tipoAmbientacionId, int proveedorId, int cantidadTotalInvitados, int sectorId, string fechaEvento)
        {

            DateTime fechaSeleccionada = DateTime.ParseExact(fechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string Categoria = "A";

            string tipoAmbientacion = tipoAmbientacionId.ToString();

            string Proveedor = "P";

            string proveedor = proveedorId.ToString();

            string CantidadInvitados = "I";

            string Sector = "S";

            string SectorId = sectorId.ToString();

            string Semestre = "SE";

            string SemenstreId = ObtenerSemestre(fechaEvento);

            int anio = DateTime.Parse(fechaSeleccionada.ToString()).Year;

            List<ObtenerCantidadInvitadosCatering> Cantidades = eventos.TraerCantidadPersonasCatering();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, cantidadTotalInvitados);


            string cantidadInvitadosId = cantInvitadosCosto.ToString();

            return Categoria + tipoAmbientacion + Proveedor + proveedor + CantidadInvitados + cantidadInvitadosId + Sector + SectorId + Semestre + SemenstreId + anio;

        }

        public string ArmarCodigoAmbientacionCorporativoInformal(int tipoAmbientacionId, int proveedorId, int cantidadTotalInvitados, int sectorId, string fechaEvento)
        {
            DateTime fechaSeleccionada = DateTime.ParseExact(fechaEvento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string Categoria = "ABCI";

            string tipoAmbientacion = tipoAmbientacionId.ToString();

            string Proveedor = "P";

            string proveedor = proveedorId.ToString();

            string CantidadInvitados = "I";

            string Sector = "S";

            string SectorId = sectorId.ToString();

            string Semestre = "SE";

            string SemenstreId = ObtenerSemestre(fechaEvento);

            int anio = DateTime.Parse(fechaSeleccionada.ToString()).Year;

            //List<ObtenerCantidadInvitadosCatering> Cantidades = eventos.TraerCantidadPersonasCatering();

            //int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, cantidadTotalInvitados);


            string cantidadInvitadosId = cantidadTotalInvitados.ToString();

            return Categoria + tipoAmbientacion + Proveedor + proveedor + CantidadInvitados + cantidadInvitadosId + Sector + SectorId + Semestre + SemenstreId + anio;
        }

        public string ObtenerSemestre(string fechaEvento)
        {
            int mes = DateTime.Parse(fechaEvento).Month;

            if (mes < 7)
                return "1";
            else
                return "2";

        }

        public string ArmarCodigoOrganizacion(int tipoOrganizacionId, int proveedorId, int cantidadTotalInvitados)
        {
            string Categoria = "O";

            string tipoOrganizacion = tipoOrganizacionId.ToString();

            string Proveedor = "P";

            string proveedor = proveedorId.ToString();

            string CantidadInvitados = "I";

            List<ObtenerCantidadInvitadosCatering> Cantidades = eventos.TraerCantidadPersonasCatering();

            int cantInvitadosCosto = ObtenerCantidadInvitadosCosto(Cantidades, cantidadTotalInvitados);


            OrganizacionItems org = organizacion.BuscarItemsOrganizacion(tipoOrganizacionId);

            if (org.RequiereCantidad == "S")
                return Categoria + tipoOrganizacion + Proveedor + proveedor + CantidadInvitados + 1;
            else
                return Categoria + tipoOrganizacion + Proveedor + proveedor + CantidadInvitados + cantInvitadosCosto;
        }

        private int ObtenerCantidadInvitadosCosto(List<ObtenerCantidadInvitadosCatering> Cantidades, int CantidadInvitados)
        {

            foreach (var item in Cantidades)
            {
                if (CantidadInvitados <= (item.CantidadPersonas + 25))
                {
                    return item.CantidadPersonas;
                }
            }
            return Cantidades.Max(o => o.CantidadPersonas);

        }

        public double CalcularTotalPresupuestoPendiente(int PresupuestoId,List<PresupuestoDetalle> ListPresupuestoDetalle, double porcentajeOrganizador, double importeOrganizador)
        {
            int PresupuestoDetallePendiente = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetallePendiente"].ToString());

            var query = (from L in ListPresupuestoDetalle
                         where L.EstadoId == PresupuestoDetallePendiente
                         select L.ValorSeleccionado + (L.Cannon == null ? 0 : L.Cannon) 
                                                    + (L.Logistica == null ? 0 : L.Logistica) 
                                                    + (L.UsoCocina == null ? 0 : L.UsoCocina)
                                                    + (L.ValorIntermediario == null ? 0 : L.ValorIntermediario)
                                                    + (L.PrecioSillas == null ? 0 : L.PrecioSillas)
                                                    + (L.PrecioMesas == null ? 0 : L.PrecioMesas) 
                                                    + (L.Incremento == null ? 0 : L.Incremento) - (L.Descuentos == null ? 0 : L.Descuentos)).Sum();

            double TotalOrganizador = 0;

            Presupuestos presu = presupuestos.BuscarPresupuesto(PresupuestoId);

            if (presu.ValorOrganizador != null)
            {
                TotalOrganizador = TotalOrganizador + double.Parse(presu.ValorOrganizador.ToString() ) + double.Parse(presu.ValorRoyaltyOrganizador.ToString());
            }

            //if (IsNumeric(porcentajeOrganizador))
            //{
            //    TotalOrganizador = double.Parse(query.ToString()) * (porcentajeOrganizador / 100);
            //}
            //if(IsNumeric(importeOrganizador))
            //{
            //    TotalOrganizador = importeOrganizador;
            //}


            double TotalPresupuesto1 = double.Parse(query.ToString()) + TotalOrganizador;

            return TotalPresupuesto1;


        }

        public double CalcularTotalPresupuestoAprobado(int PresupuestoId,List<PresupuestoDetalle> ListPresupuestoDetalle, double porcentajeOrganizador, double importeOrganizador)
        {
            int PresupuestoDetalleAprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());

            var query = (from L in ListPresupuestoDetalle
                         where L.EstadoId == PresupuestoDetalleAprobado
                         select L.ValorSeleccionado + (L.Cannon == null ? 0 : L.Cannon) 
                                                    + (L.Logistica == null ? 0 : L.Logistica) 
                                                    + (L.UsoCocina == null ? 0 : L.UsoCocina)
                                                    + (L.ValorIntermediario == null ? 0 : L.ValorIntermediario)
                                                    + (L.PrecioSillas == null ? 0 : L.PrecioSillas)
                                                    + (L.PrecioMesas == null ? 0 : L.PrecioMesas) 
                                                    + (L.Incremento == null ? 0 : L.Incremento) - (L.Descuentos == null ? 0 : L.Descuentos)).Sum();

            double TotalOrganizador = 0;


            Presupuestos presu = presupuestos.BuscarPresupuesto(PresupuestoId);


            if (presu.ValorOrganizador != null)
            {
                TotalOrganizador = TotalOrganizador + double.Parse(presu.ValorOrganizador.ToString()) + double.Parse(presu.ValorRoyaltyOrganizador.ToString());
            }


            //if (IsNumeric(porcentajeOrganizador))
            //{
            //    TotalOrganizador = double.Parse(query.ToString()) * (porcentajeOrganizador / 100);
            //}
            //if (IsNumeric(importeOrganizador))
            //{
            //    TotalOrganizador = importeOrganizador;
            //}


            double TotalPresupuesto1 = double.Parse(query.ToString()) + TotalOrganizador;

            return TotalPresupuesto1;


        }

        public double CalcularTotalPresupuesto(List<PresupuestoDetalle> ListPresupuestoDetalle, double porcentajeOrganizador, double importeOrganizador)
        {
            int PresupuestoDetalleAprobado = Int32.Parse(ConfigurationManager.AppSettings["PresupuestoDetalleAprobado"].ToString());

            var query = (from L in ListPresupuestoDetalle
                         select L.ValorSeleccionado + (L.Cannon == null ? 0 : L.Cannon) 
                                                    + (L.Logistica == null ? 0 : L.Logistica) 
                                                    + (L.UsoCocina == null ? 0 : L.UsoCocina)
                                                    + (L.ValorIntermediario == null ? 0 : L.ValorIntermediario)
                                                    + (L.PrecioSillas == null ? 0 : L.PrecioSillas)
                                                    + (L.PrecioMesas == null ? 0 : L.PrecioMesas) 
                                                    + (L.Incremento == null ? 0 : L.Incremento) - (L.Descuentos == null ? 0 : L.Descuentos)).Sum();
            double TotalOrganizador = 0;

            if (IsNumeric(porcentajeOrganizador))
            {
                TotalOrganizador = double.Parse(query.ToString()) * (porcentajeOrganizador / 100);
            }
            if (IsNumeric(importeOrganizador))
            {
                TotalOrganizador = importeOrganizador;
            }

            double TotalPresupuesto1 = double.Parse(query.ToString()) + TotalOrganizador;

            return TotalPresupuesto1;


        }

        public double CalcularRentaValor(List<PresupuestoDetalle> ListPresupuestoDetalle)
        {
            var queryCosto = (from l in ListPresupuestoDetalle
                              select (l.Costo + l.Comision + (l.CostoSillas == null ? 0 : l.CostoSillas)
                                                           + (l.CostoMesas == null ? 0 : l.CostoMesas))).Sum();

            var queryPrecio = (from l in ListPresupuestoDetalle
                               select l.ValorSeleccionado + (l.PrecioMesas == null ? 0 : l.PrecioMesas)
                                                          + (l.PrecioSillas == null ? 0 : l.PrecioSillas)
                                                          + (l.Incremento == null ? 0 : l.Incremento) - (l.Descuentos== null ? 0 : l.Descuentos)).Sum();


            double rentabilidad = double.Parse(queryPrecio.ToString()) - double.Parse(queryCosto.ToString());

            return System.Math.Round(rentabilidad, 2);

        }

        public double CalcularRentaPorcentaje(List<PresupuestoDetalle> ListPresupuestoDetalle)
        {
            var queryCosto = (from l in ListPresupuestoDetalle
                              select (l.Costo + l.Comision + (l.CostoSillas == null ? 0 : l.CostoSillas)
                                                        + (l.CostoMesas == null ? 0 : l.CostoMesas))).Sum();

            var queryPrecio = (from l in ListPresupuestoDetalle
                               select l.ValorSeleccionado + (l.PrecioMesas == null ? 0 : l.PrecioMesas)
                                                         + (l.PrecioSillas == null ? 0 : l.PrecioSillas)
                                                         + (l.Incremento == null ? 0 : l.Incremento) - (l.Descuentos == null ? 0 : l.Descuentos)).Sum();

            double rentabilidad = (((double.Parse(queryPrecio.ToString()) - double.Parse(queryCosto.ToString())) / double.Parse(queryPrecio.ToString())) * 100);

            return System.Math.Round(rentabilidad, 0);

        }

        public double CalcularCostoTotalPresupuestoPorPresupuestoId(List<PresupuestoDetalle> ListPresupuestoDetalle, double porcentajeOrganizador, double importeOrganizador)
        {
            double ValorTotal = 0;

         

            List<PresupuestoDetalle> query = (from L in ListPresupuestoDetalle
                                              select L).ToList();



            ValorTotal = query.Select(o => (o.Costo == null ? 0 : (double)o.Costo) +
                          (o.Cannon == null ? 0 : (double)o.Cannon) +
                          (o.Logistica == null ? 0 : (double)o.Logistica) +
                          (o.UsoCocina == null ? 0 : (double)o.UsoCocina) +
                          (o.CostoSillas == null ? 0 : (double)o.CostoSillas) +
                          (o.CostoMesas == null ? 0 : (double)o.CostoMesas) +
                          (o.ValorIntermediario == null ? 0 : (double)o.ValorIntermediario)).Sum();

            return System.Math.Round(ValorTotal, 2);
        }

        public bool ValidarHora(string hora)
        {
            string cadenaHoraInicio;
            string cadenaMinutosInicio;

           

            cadenaHoraInicio = hora.Substring(0, 2);
            cadenaMinutosInicio = hora.Substring(3, 2);

        


            if (Int32.Parse(cadenaHoraInicio) > 24)
            { return false; }

            if (Int32.Parse(cadenaMinutosInicio) > 60)
            { return false; }

            return true;
        }

        public double CalcularCantidadInvitados(string pCantidadAdultos, string pCantidadInvitadosEntre3y8, string pCantidadInvitadosMenores3, string pCantidadInvitadosAdolecentes)
        {
            Parametros parametroCateringEntre3y8 = parametros.BuscarParametros("PorcentajeCateringEntre3y8");

            double porcentajeCateringEntre3y8 = double.Parse(parametroCateringEntre3y8.Valor);

            Parametros parametroCateringMenores3 = parametros.BuscarParametros("PorcentajeCateringMenores3");

            double porcentajeCateringMenores3 = double.Parse(parametroCateringMenores3.Valor);

            Parametros parametroCateringAdolescentes = parametros.BuscarParametros("PorcentajeCateringAdolescentes");

            double porcentajeCateringAdolescentes = double.Parse(parametroCateringAdolescentes.Valor);


            double CantidadAdultos = 0;
            if (IsNumeric(pCantidadAdultos))
            {
                CantidadAdultos = (double.Parse(pCantidadAdultos));
            }

            double CantidadInvitadosEntre3y8 = 0;
            if (IsNumeric(pCantidadInvitadosEntre3y8))
            {
                CantidadInvitadosEntre3y8 = double.Parse((double.Parse(pCantidadInvitadosEntre3y8) * porcentajeCateringEntre3y8).ToString());
            }

            double CantidadInvitadosMenores3 = 0;
            if (IsNumeric(pCantidadInvitadosMenores3))
            {
                CantidadInvitadosMenores3 = double.Parse((double.Parse(pCantidadInvitadosMenores3) * porcentajeCateringMenores3).ToString());
            }

            double CantidadInvitadosAdolecentes = 0;
            if (IsNumeric(pCantidadInvitadosAdolecentes))
            {
                CantidadInvitadosAdolecentes = double.Parse((double.Parse(pCantidadInvitadosAdolecentes) * porcentajeCateringAdolescentes).ToString());
            }

            return ((CantidadAdultos + (int)CantidadInvitadosEntre3y8 + (int) CantidadInvitadosMenores3 +  (int)CantidadInvitadosAdolecentes));

        }


        public double ValidarImportes(string valor)
        {
            return (double.Parse(valor.Replace(".", ",")));
        }

        public double CalcularSaldoIndexadoEvento(int presupuestoId, double saldoEvento)
        {
            return 0;
        
        }

        public void PanelDescuentos(GridViewRowEventArgs e)
        {
            TextBox Comentario = (TextBox)e.Row.FindControl("TextBoxComentario");
            Button button = (Button)e.Row.FindControl("ButtonAnularCanon");

            TextBox textoPrecio = (TextBox)e.Row.FindControl("TextBoxPrecio");
            TextBox textoPrecioAjustado = (TextBox)e.Row.FindControl("TextBoxPrecioAjustado");
            TextBox textoCosto = (TextBox)e.Row.FindControl("TextBoxCosto");
            TextBox textoUsoCocina = (TextBox)e.Row.FindControl("TextBoxUsoCocina");
            TextBox textoFee = (TextBox)e.Row.FindControl("TextBoxIntermediario");
            TextBox textoLogistica = (TextBox)e.Row.FindControl("TextBoxLogistica");
            TextBox textoCanon = (TextBox)e.Row.FindControl("TextBoxCanon");


            Label labelPrecio = (Label)e.Row.FindControl("LabelPrecio");
            Label labelCosto = (Label)e.Row.FindControl("LabelCosto");
            Label labelUsoCocina = (Label)e.Row.FindControl("LabelUsoCocina");
            Label labelFee = (Label)e.Row.FindControl("LabelIntermediario");
            Label labelLogistica = (Label)e.Row.FindControl("LabelLogistica");
            Label labelCanon = (Label)e.Row.FindControl("LabelCanon");
            Label labelAjuste = (Label)e.Row.FindControl("LabelAjuste");

            Panel panelDescuento = (Panel)e.Row.FindControl("PanelValores");
            

            button.Visible = false;

            int detalleId = Int32.Parse(e.Row.Cells[0].Text);

            PresupuestoDetalle detalle = detallePresupuesto.BuscarPresupuestoDetalle(detalleId);

            Comentario.Text = detalle.Comentario;

            double? canon = detalle.Cannon;

            if ((canon > 0) && (canon != null))
            {
                button.Visible = true;
            }

            //double? logisticaVerif = detalle.Logistica;

            //if (logisticaVerif > 0) textoLogistica.ReadOnly = false;

            panelDescuento.GroupingText = detalle.UnidadNegocioDescripcion.ToUpper();

            textoPrecio.Text = System.Math.Round(detalle.ValorSeleccionado, 2).ToString("C");
            textoPrecio.ReadOnly = true;

            if (detalle.NuevoValor > 0)
            {
                if (detalle.NuevoValor > detalle.ValorSeleccionado)
                {
                    double valorIncremento = (detalle.Incremento != null ?
                                                double.Parse(detalle.Incremento.ToString()) :
                                                0) - (detalle.Descuentos != null ?
                                                        double.Parse(detalle.Descuentos.ToString()) :
                                                        0);

                    textoPrecioAjustado.Text = System.Math.Round(detalle.NuevoValor, 2).ToString("C");
                    textoPrecioAjustado.ForeColor = System.Drawing.Color.Black;
                    textoPrecioAjustado.BackColor = System.Drawing.Color.Gray;
                    labelAjuste.Visible = true;
                    labelAjuste.Text = "Incremento: (" + System.Math.Round(valorIncremento, 2).ToString("C") + ")";
                    labelAjuste.ForeColor = System.Drawing.Color.Green;
                }
                else if (detalle.NuevoValor < detalle.ValorSeleccionado)
                {
                    double valorDescuento = (detalle.Descuentos != null ?
                                               double.Parse(detalle.Descuentos.ToString()) :
                                               0) - (detalle.Incremento != null ?
                                                       double.Parse(detalle.Incremento.ToString()) :
                                                       0);

                    textoPrecioAjustado.Text = System.Math.Round(detalle.NuevoValor, 2).ToString("C");
                    textoPrecioAjustado.ForeColor = System.Drawing.Color.Black;
                    textoPrecioAjustado.BackColor = System.Drawing.Color.Gray;
                    labelAjuste.Visible = true;
                    labelAjuste.Text = "Descuento: (" + System.Math.Round(valorDescuento, 2).ToString("C") + ")";
                    labelAjuste.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    textoPrecioAjustado.Text = System.Math.Round(detalle.NuevoValor, 2).ToString("C");
                    textoPrecioAjustado.ForeColor = System.Drawing.Color.Black;
                    textoPrecioAjustado.BackColor = System.Drawing.Color.Gray;
                }
            }
            else
            {
                textoPrecioAjustado.Text = System.Math.Round(detalle.ValorSeleccionado, 2).ToString("C");
                labelAjuste.Visible = false;
            }

            textoCosto.Visible = false;
            textoUsoCocina.Visible = false;
            textoFee.Visible = false;
            textoLogistica.Visible = false;
            textoCanon.Visible = false;

            labelCosto.Visible = false;
            labelUsoCocina.Visible = false;
            labelFee.Visible = false;
            labelLogistica.Visible = false;
            labelCanon.Visible = false;


            if (detalle.Logistica > 0)
            {
                double logistica = double.Parse(detalle.Logistica.ToString());
                textoLogistica.Text = System.Math.Round(logistica, 2).ToString("C");
                textoLogistica.Visible = true;
                labelLogistica.Visible = true;
                textoLogistica.ReadOnly = true;
            }

            bool isAnulo = bool.Parse(detalle.AnuloCanon.ToString());
            if (isAnulo)
            {
                textoCanon.Text = "ANULO CANON";
                textoCanon.Visible = true;
                labelCanon.Visible = true;
                textoCanon.ReadOnly = true;
            }
            else
            {
                if (detalle.Cannon > 0)
                {
                    double canonV = double.Parse(detalle.Cannon.ToString());
                    textoCanon.Text = System.Math.Round(canonV, 2).ToString("C");
                    textoCanon.Visible = true;
                    labelCanon.Visible = true;
                    textoCanon.ReadOnly = true;
                }
            }

            if (detalle.Costo > 0)
            {
                double costo = double.Parse(detalle.Costo.ToString());
                textoCosto.Text = System.Math.Round(costo, 2).ToString();
                textoCosto.Visible = true;
                labelCosto.Visible = true;
               
            }

            if (detalle.UsoCocina > 0)
            {
                double usoCocina = double.Parse(detalle.UsoCocina.ToString());
                textoUsoCocina.Text = System.Math.Round(usoCocina, 2).ToString("C");
                textoUsoCocina.Visible = true;
                labelUsoCocina.Visible = true;
                textoUsoCocina.ReadOnly = true;
            }

            if (detalle.ValorIntermediario > 0)
            {
                double fee = double.Parse(detalle.ValorIntermediario.ToString());
                textoFee.Text = System.Math.Round(fee, 2).ToString("C");
                textoFee.Visible = true;
                labelFee.Visible = true;
                textoFee.ReadOnly = true;
            }
        }

        public bool Logeado(int EmpleadoId)
        {

            int UsuarioAlejandro = Int32.Parse(ConfigurationManager.AppSettings["UsuarioAlejandro"].ToString());
            int UsuarioFabiana = Int32.Parse(ConfigurationManager.AppSettings["UsuarioFabiana"].ToString());
            int UsuarioNahuel = Int32.Parse(ConfigurationManager.AppSettings["UsuarioNahuel"].ToString());
            int UsuarioHernan = Int32.Parse(ConfigurationManager.AppSettings["UsuarioHernan"].ToString());
            int UsuarioLucas = Int32.Parse(ConfigurationManager.AppSettings["UsuarioLucas"].ToString());


            return EmpleadoId == UsuarioAlejandro
                                || EmpleadoId == UsuarioFabiana
                                || EmpleadoId == UsuarioNahuel
                                || EmpleadoId == UsuarioHernan
                                || EmpleadoId == UsuarioLucas;
        }
       
    }
}
