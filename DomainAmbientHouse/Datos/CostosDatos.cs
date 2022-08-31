using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Globalization;
using System.IO;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Collections;
using LinqToExcel;

namespace DomainAmbientHouse.Datos
{
    public class CostosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }



        public CostosDatos()
        {
            SqlContext = new AmbientHouseEntities();


        }

        public virtual CostoCatering BuscarCostoCatering(int tipoCateringId, int cantidadInvitados, int proveedorId)
        {

            return SqlContext.CostoCatering.Where(o => o.TipoCateringId == tipoCateringId && o.CantidadPersonas == cantidadInvitados && o.ProveedorId == proveedorId).FirstOrDefault();

        }

        public CostoAdicionales BuscarCostoAdicionalCatering(int AdicionalId, int cantidadInvitados)
        {
            return SqlContext.CostoAdicionales.Where(o => o.AdicionalId == AdicionalId && o.CantidadPersonas == cantidadInvitados).FirstOrDefault();

        }

        public virtual CostoTecnica BuscarCostoTecnica(int tipoServicioId, int segmentoId, int anio, int mes, string dia, int proveedorId)
        {
            string diaEspanol = ConvertirIdioma(dia);

            return SqlContext.CostoTecnica.Where(o => o.TipoServicioId == tipoServicioId &&
                                                        o.SegmentoId == segmentoId &&
                                                        o.Anio == anio &&
                                                        o.Mes == mes &&
                                                        o.Dia.Contains(diaEspanol) &&
                                                        o.ProveedorId == proveedorId).FirstOrDefault();
        }

        public virtual CostoSalones BuscarCostoSalon(int locacionId, int sectorId, int jornadaId, int anio, int mes, string dia)
        {

            string diaEspanol = ConvertirIdioma(dia);

            return SqlContext.CostoSalones.Where(o => o.LocacionId == locacionId &&
                                                        o.SectorId == sectorId &&
                                                        o.JornadaId == jornadaId &&
                                                        o.Anio == anio &&
                                                        o.Mes == mes &&
                                                        o.Dia.StartsWith(diaEspanol)).FirstOrDefault();
        }

        public virtual CostoBarra BuscarCostoBarra(int tipoBarraId, int cantidadPersonas, int anio, int mes, string dia)
        {
            return SqlContext.CostoBarra.Where(o => o.TipoBarraId == tipoBarraId &&
                                                        o.CantidadPersonas == cantidadPersonas).FirstOrDefault();
        }

        public virtual CostoBarra BuscarCostoBarra(int tipoBarra, int cantidadInvitados, int proveedorId)
        {
            return SqlContext.CostoBarra.Where(o => o.TipoBarraId == tipoBarra &&
                                                        o.CantidadPersonas == cantidadInvitados &&
                                                        o.ProveedorId == proveedorId).FirstOrDefault();
        }



        public virtual List<ObtenerPrecioCostoBarra> ObtenerPrecioCostoBarra()
        {
            return SqlContext.ObtenerPrecioCostoBarra.ToList();
        }

        public virtual List<ObtenerPrecioCostoCatering> ObtenerPrecioCostoCatering()
        {
            return SqlContext.ObtenerPrecioCostoCatering.ToList();
        }

        public virtual List<ObtenerPrecioCostoTecnica> ObtenerPrecioCostoTecnica()
        {
            return SqlContext.ObtenerPrecioCostoTecnica.ToList();
        }

        private string ConvertirIdioma(string valor)
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



        public CostoLogistica BuscarCostoLogistica(int tipoLogisticaId, int localidadId, int cantInvitados)
        {
            return SqlContext.CostoLogistica.Where(o => o.ConceptoId == tipoLogisticaId && o.Localidad == localidadId && o.CantidadInvitados == cantInvitados ).FirstOrDefault();
        }

        public CostoLogistica BuscarCostoLogistica(int tipoLogisticaId, int localidadId, int cantInvitados, int tipoEventoId)
        {
            return SqlContext.CostoLogistica.Where(o => o.ConceptoId == tipoLogisticaId && o.Localidad == localidadId && o.CantidadInvitados == cantInvitados && o.TipoEventoId == tipoEventoId).FirstOrDefault();
        }

        public CostoAmbientacion BuscarCostoAmbientacion(int categoriaId, int cantInvitadosCosto, int proveedorId)
        {
            return SqlContext.CostoAmbientacion.Where(o => o.CategoriaId == categoriaId && o.ProveedorId == proveedorId && o.CantidadInvitados == cantInvitadosCosto).FirstOrDefault();
        }

        //public void ImportarCostosCatering(string archivo)
        //{
        //    //Create COM Objects. Create a COM object for everything that is referenced
        //    Excel.Application xlApp = new Excel.Application();
        //    //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\diego\Desktop\BASE PRECIOS AMBIENTACION 280817 Modificado.xlsx");
        //    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"" + archivo + "");
        //    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        //    Excel.Range xlRange = xlWorksheet.UsedRange;

        //    int rowCount = xlRange.Rows.Count;
        //    int colCount = xlRange.Columns.Count;

        //    //iterate over the rows and columns and print to the console as it appears in the file
        //    //excel is not zero based!!
        //    for (int i = 1; i <= rowCount; i++)
        //    {
        //        for (int j = 1; j <= colCount; j++)
        //        {
        //            //new line
        //            if (j == 1)
        //                Console.Write("\r\n");

        //            //write the value to the console
        //            if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
        //                Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
        //        }
        //    }

        //    string pepe = xlRange.Cells[1, 1].Value2;

        //    //cleanup
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();

        //    //rule of thumb for releasing com objects:
        //    //  never use two dots, all COM objects must be referenced and released individually
        //    //  ex: [somthing].[something].[something] is bad

        //    //release com objects to fully kill excel process from running in the background
        //    Marshal.ReleaseComObject(xlRange);
        //    Marshal.ReleaseComObject(xlWorksheet);

        //    //close and release
        //    xlWorkbook.Close();
        //    Marshal.ReleaseComObject(xlWorkbook);

        //    //quit and release
        //    xlApp.Quit();
        //    Marshal.ReleaseComObject(xlApp);
        //}





        //public void GenerarPrecioCatering()
        //{

        //    // archivo de entrada
        //    string file = "libro.xls";
        //    string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    string xlsFilePath = Path.Combine(dir, file);

        //    read_file(xlsFilePath);

        //    Console.ReadKey();


        //}

        //private void read_file(string xlsFilePath)
        //{
        //    ApplicationClass Excel;

        //    if (!File.Exists(xlsFilePath))
        //        return;

        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    Excel.Range range;
        //    var misValue = Type.Missing;//System.Reflection.Missing.Value;

        //    // abrir el documento
        //    xlApp =  Excel.ApplicationClass;
        //    xlWorkBook = xlApp.Workbooks.Open(xlsFilePath, misValue, misValue,
        //        misValue, misValue, misValue, misValue, misValue, misValue,
        //        misValue, misValue, misValue, misValue, misValue, misValue);

        //    // seleccion de la hoja de calculo
        //    // get_item() devuelve object y numera las hojas a partir de 1
        //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //    // seleccion rango activo
        //    range = xlWorkSheet.UsedRange;


        //    // leer las celdas
        //    int rows = range.Rows.Count;
        //    int cols = range.Columns.Count;


        //    for (int row = 1; row <= rows; row++)
        //    {
        //        for (int col = 1; col <= cols; col++)
        //        {

        //            // lectura como cadena
        //            string str_value = (range.Cells[row, col] as Excel.Range).Value2.ToString();

        //            // conversion
        //            int int_value = Convert.ToInt32(str_value, 10);

        //            Console.WriteLine("string:{0}", str_value);
        //            Console.WriteLine("int:{0}", int_value);
        //        }


        //    }


        //    // cerrar
        //    xlWorkBook.Close(false, misValue, misValue);
        //    xlApp.Quit();

        //    // liberar
        //    releaseObject(xlWorkSheet);
        //    releaseObject(xlWorkBook);
        //    releaseObject(xlApp);


        //}


        //public static void releaseObject(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Unable to release the object(object:{0})", obj.ToString());
        //    }
        //    finally
        //    {
        //        obj = null;
        //        GC.Collect();
        //    }
        //}

        public List<CostoCatering> ObtenerCostoCatering()
        {

            var query = from Cc in SqlContext.CostoCatering
                        join Tc in SqlContext.TipoCatering on Cc.TipoCateringId equals Tc.Id
                        join Pc in SqlContext.Proveedores on Cc.ProveedorId equals Pc.Id into Pcs
                        from Pc in Pcs.DefaultIfEmpty()
                        select new
                        {
                            Id = Cc.Id,
                            Precio = Cc.Precio,
                            Costo = Cc.Costo,
                            TipoCateringId = Cc.TipoCateringId,
                            ProveedorId = (Cc.ProveedorId == null ? null : Cc.ProveedorId),
                            CantidadPersonas = Cc.CantidadPersonas,
                            ValorMas5PorCiento = Cc.ValorMas5PorCiento,
                            ValorMenos10PorCiento = Cc.ValorMenos10PorCiento,
                            ValorMenos5PorCiento = Cc.ValorMenos5PorCiento,
                            ProveedorDescripcion = Pc.RazonSocial,
                            TipoCateringDescripcion = Tc.Descripcion,
                            PrecioMas5 = (Cc.Precio * Cc.ValorMas5PorCiento),
                            PrecioMenos5 = (Cc.Precio * Cc.ValorMenos5PorCiento),
                            PrecioMenos10 = (Cc.Precio * Cc.ValorMenos10PorCiento)

                        };

            List<CostoCatering> Salida = new List<CostoCatering>();
            foreach (var item in query)
            {

                CostoCatering cat = new CostoCatering();

                cat.Id = item.Id;
                cat.Precio = item.Precio;
                cat.Costo = item.Costo;
                cat.TipoCateringId = item.TipoCateringId;
                cat.ProveedorId = item.ProveedorId;
                cat.CantidadPersonas = item.CantidadPersonas;
                cat.ValorMas5PorCiento = item.ValorMas5PorCiento;
                cat.ValorMenos10PorCiento = item.ValorMenos10PorCiento;
                cat.ValorMenos5PorCiento = item.ValorMenos5PorCiento;
                cat.ProveedorDescripcion = item.ProveedorDescripcion;
                cat.TipoCateringDescripcion = item.TipoCateringDescripcion;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                Salida.Add(cat);
            }

            return Salida.ToList();
        }



        public void NuevoCostoCatering(CostoCatering costo)
        {
            SqlContext.CostoCatering.Add(costo);
            SqlContext.SaveChanges();
        }

        public void EliminarCostoCateringPorProveedor(int? proveedorId)
        {
            List<CostoCatering> costoCatering = SqlContext.CostoCatering.Where(o => o.ProveedorId == proveedorId).ToList();

            foreach (var item in costoCatering)
            {
                SqlContext.CostoCatering.Remove(item);
            }
            SqlContext.SaveChanges();


        }

        public List<CostoBarra> ObtenerCostoBarras()
        {
            var query = from Cc in SqlContext.CostoBarra
                        join Tc in SqlContext.TiposBarras on Cc.TipoBarraId equals Tc.Id
                        join Pc in SqlContext.Proveedores on Cc.ProveedorId equals Pc.Id into Pcs
                        from Pc in Pcs.DefaultIfEmpty()
                        select new
                        {
                            Id = Cc.Id,
                            Precio = Cc.Precios,
                            Costo = Cc.Costo,
                            TipoBarraId = Cc.TipoBarraId,
                            ProveedorId = (Cc.ProveedorId == null ? null : Cc.ProveedorId),
                            CantidadPersonas = Cc.CantidadPersonas,
                            ValorMas5PorCiento = Cc.ValorMas5PorCiento,
                            ValorMenos10PorCiento = Cc.ValorMenos10PorCiento,
                            ValorMenos5PorCiento = Cc.ValorMenos5PorCiento,
                            ProveedorDescripcion = Pc.RazonSocial,
                            TipoBarraDescripcion = Tc.Descripcion,
                            PrecioMas5 = (Cc.Precios * Cc.ValorMas5PorCiento),
                            PrecioMenos5 = (Cc.Precios * Cc.ValorMenos5PorCiento),
                            PrecioMenos10 = (Cc.Precios * Cc.ValorMenos10PorCiento)

                        };

            List<CostoBarra> Salida = new List<CostoBarra>();
            foreach (var item in query)
            {

                CostoBarra cat = new CostoBarra();

                cat.Id = item.Id;
                cat.Precios = item.Precio;
                cat.Costo = item.Costo;
                cat.TipoBarraId = item.TipoBarraId;
                cat.ProveedorId = item.ProveedorId;
                cat.CantidadPersonas = item.CantidadPersonas;
                cat.ValorMas5PorCiento = item.ValorMas5PorCiento;
                cat.ValorMenos10PorCiento = item.ValorMenos10PorCiento;
                cat.ValorMenos5PorCiento = item.ValorMenos5PorCiento;
                cat.ProveedorDescripcion = item.ProveedorDescripcion;
                cat.TipoBarraDescripcion = item.TipoBarraDescripcion;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                Salida.Add(cat);
            }

            return Salida.ToList();
        }

        public void NuevoCostoBarra(CostoBarra costo)
        {
            SqlContext.CostoBarra.Add(costo);
            SqlContext.SaveChanges();
        }

        public void EliminarCostoBarraPorProveedor(int? proveedorId)
        {
            List<CostoBarra> costoBarra = SqlContext.CostoBarra.Where(o => o.ProveedorId == proveedorId).ToList();

            foreach (var item in costoBarra)
            {
                SqlContext.CostoBarra.Remove(item);
            }
            SqlContext.SaveChanges();
        }

        public List<CostoTecnica> ObtenerCostoTecnica()
        {
            var query = from Cc in SqlContext.CostoTecnica
                        join Tc in SqlContext.TipoServicios on Cc.TipoServicioId equals Tc.Id
                        join Sc in SqlContext.Segmentos on Cc.SegmentoId equals Sc.Id
                        join Pc in SqlContext.Proveedores on Cc.ProveedorId equals Pc.Id
                        select new
                        {
                            Id = Cc.Id,
                            Precio = Cc.Precio,
                            Costo = Cc.Costo,
                            TipoServicioId = Cc.TipoServicioId,
                            SegmentoId = Cc.SegmentoId,
                            ProveedorId = Cc.ProveedorId,
                            ValorMas5PorCiento = Cc.ValorMas5PorCiento,
                            ValorMenos10PorCiento = Cc.ValorMenos10PorCiento,
                            ValorMenos5PorCiento = Cc.ValorMenos5PorCiento,
                            ProveedorDescripcion = Pc.RazonSocial,
                            TipoServicioDescripcion = Tc.Descripcion,
                            SegmentoDescripcion = Sc.Descripcion,
                            PrecioMas5 = (Cc.Precio * Cc.ValorMas5PorCiento),
                            PrecioMenos5 = (Cc.Precio * Cc.ValorMenos5PorCiento),
                            PrecioMenos10 = (Cc.Precio * Cc.ValorMenos10PorCiento),
                            Dia = Cc.Dia,
                            Mes = Cc.Mes,
                            Anio = Cc.Anio

                        };

            List<CostoTecnica> Salida = new List<CostoTecnica>();
            foreach (var item in query)
            {

                CostoTecnica cat = new CostoTecnica();

                cat.Id = item.Id;
                cat.Precio = item.Precio;
                cat.Costo = item.Costo;
                cat.TipoServicioId = item.TipoServicioId;
                cat.ProveedorId = item.ProveedorId;
                cat.SegmentoId = item.SegmentoId;
                cat.ValorMas5PorCiento = item.ValorMas5PorCiento;
                cat.ValorMenos10PorCiento = item.ValorMenos10PorCiento;
                cat.ValorMenos5PorCiento = item.ValorMenos5PorCiento;
                cat.ProveedorDescripcion = item.ProveedorDescripcion;
                cat.TipoServicioDescripcion = item.TipoServicioDescripcion;
                cat.SegmentoDescripcion = item.SegmentoDescripcion;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                cat.Dia = item.Dia;
                cat.Mes = item.Mes;
                cat.Anio = item.Anio;
                Salida.Add(cat);
            }

            return Salida.ToList();
        }

        public void NuevoCostoTecnica(CostoTecnica costo)
        {
            SqlContext.CostoTecnica.Add(costo);
            SqlContext.SaveChanges();
        }

        public void EliminarCostoTecnicaPorProveedorYAnio(int? proveedorId, int anio)
        {
            List<CostoTecnica> costoTecnica = SqlContext.CostoTecnica.Where(o => o.ProveedorId == proveedorId && o.Anio == anio).ToList();

            foreach (var item in costoTecnica)
            {
                SqlContext.CostoTecnica.Remove(item);
            }
            SqlContext.SaveChanges();
        }


        public List<CostoAmbientacion> ObtenerCostoAmbientacion()
        {
            var query = from Cc in SqlContext.CostoAmbientacion
                        join Tc in SqlContext.Categorias on Cc.CategoriaId equals Tc.Id
                        join Pc in SqlContext.Proveedores on Cc.ProveedorId equals Pc.Id
                        select new
                        {
                            Id = Cc.Id,
                            Precio = Cc.Precio,
                            Costo = Cc.Costo,
                            CategoriaId = Cc.CategoriaId,
                            ProveedorId = Cc.ProveedorId,
                            CantidadPersonas = Cc.CantidadInvitados,
                            ValorMas5PorCiento = Cc.ValorMas5PorCiento,
                            ValorMenos10PorCiento = Cc.ValorMenos10PorCiento,
                            ValorMenos5PorCiento = Cc.ValorMenos5PorCiento,
                            ProveedorDescripcion = Pc.RazonSocial,
                            CategoriaDescripcion = Tc.Descripcion,
                            PrecioMas5 = (Cc.Precio * Cc.ValorMas5PorCiento),
                            PrecioMenos5 = (Cc.Precio * Cc.ValorMenos5PorCiento),
                            PrecioMenos10 = (Cc.Precio * Cc.ValorMenos10PorCiento)

                        };

            List<CostoAmbientacion> Salida = new List<CostoAmbientacion>();
            foreach (var item in query)
            {

                CostoAmbientacion cat = new CostoAmbientacion();

                cat.Id = item.Id;
                cat.Precio = item.Precio;
                cat.Costo = item.Costo;
                cat.CategoriaId = item.CategoriaId;
                cat.ProveedorId = item.ProveedorId;
                cat.CantidadInvitados = item.CantidadPersonas;
                cat.ValorMas5PorCiento = item.ValorMas5PorCiento;
                cat.ValorMenos10PorCiento = item.ValorMenos10PorCiento;
                cat.ValorMenos5PorCiento = item.ValorMenos5PorCiento;
                cat.ProveedorDescripcion = item.ProveedorDescripcion;
                cat.CategoriaDescripcion = item.CategoriaDescripcion;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                Salida.Add(cat);
            }

            return Salida.ToList();
        }

        public void NuevoCostoAmbientacion(CostoAmbientacion costo)
        {
            SqlContext.CostoAmbientacion.Add(costo);
            SqlContext.SaveChanges();
        }

        public void EliminarCostoAmbientacionPorProveedor(int? proveedorId)
        {
            List<CostoAmbientacion> costoAmbientacion = SqlContext.CostoAmbientacion.Where(o => o.ProveedorId == proveedorId).ToList();

            foreach (var item in costoAmbientacion)
            {
                SqlContext.CostoAmbientacion.Remove(item);
            }
            SqlContext.SaveChanges();
        }

        public List<CostoAdicionales> ObtenerCostoAdicional()
        {

            var query = from Cc in SqlContext.CostoAdicionales
                        join Tc in SqlContext.Adicionales on Cc.AdicionalId equals Tc.Id
                        join Pc in SqlContext.Proveedores on Cc.ProveedorId equals Pc.Id into Pcs
                        from Pc in Pcs.DefaultIfEmpty()
                        join Lc in SqlContext.Locaciones on Cc.Locacion equals Lc.Id into Lcs
                        from Lc in Lcs.DefaultIfEmpty()
                        select new
                        {
                            Id = Cc.Id,
                            Precio = Cc.Precio,
                            Costo = Cc.Costo,
                            AdicionalId = Cc.AdicionalId,
                            Locacion = (Cc.Locacion == null ? null : Cc.Locacion),
                            ProveedorId = (Cc.ProveedorId == null ? null : Cc.ProveedorId),
                            CantidadPersonas = Cc.CantidadPersonas,
                            ValorMas5PorCiento = Cc.ValorMas5PorCiento,
                            ValorMenos10PorCiento = Cc.ValorMenos10PorCiento,
                            ValorMenos5PorCiento = Cc.ValorMenos5PorCiento,
                            ProveedorDescripcion = Pc.RazonSocial,
                            AdicionalDescripcion = Tc.Descripcion,
                            LocacionDescripcion = Lc.Descripcion,
                            PrecioMas5 = (Cc.Precio * Cc.ValorMas5PorCiento),
                            PrecioMenos5 = (Cc.Precio * Cc.ValorMenos5PorCiento),
                            PrecioMenos10 = (Cc.Precio * Cc.ValorMenos10PorCiento)

                        };

            List<CostoAdicionales> Salida = new List<CostoAdicionales>();
            foreach (var item in query)
            {

                CostoAdicionales cat = new CostoAdicionales();

                cat.Id = item.Id;
                cat.Precio = item.Precio;
                cat.Costo = item.Costo;
                cat.AdicionalId = item.AdicionalId;
                cat.ProveedorId = item.ProveedorId;
                cat.Locacion = item.Locacion;
                cat.CantidadPersonas = item.CantidadPersonas;
                cat.ValorMas5PorCiento = item.ValorMas5PorCiento;
                cat.ValorMenos10PorCiento = item.ValorMenos10PorCiento;
                cat.ValorMenos5PorCiento = item.ValorMenos5PorCiento;
                cat.ProveedorDescripcion = item.ProveedorDescripcion;
                cat.LocacionDescripcion = item.LocacionDescripcion;
                cat.AdicionalDescripcion = item.AdicionalDescripcion;
                cat.PrecioMas5 = item.PrecioMas5;
                cat.PrecioMenos5 = item.PrecioMenos5;
                cat.PrecioMenos10 = item.PrecioMenos10;
                Salida.Add(cat);
            }

            return Salida.ToList();
        }

        public void NuevoCostoAdicionales(CostoAdicionales costo)
        {
            SqlContext.CostoAdicionales.Add(costo);
            SqlContext.SaveChanges();
        }

        public void EliminarCostoAdicionalPorProveedor(int? proveedorId)
        {
            List<CostoAdicionales> costoAdicional = SqlContext.CostoAdicionales.Where(o => o.ProveedorId == proveedorId).ToList();

            foreach (var item in costoAdicional)
            {
                SqlContext.CostoAdicionales.Remove(item);
            }
            SqlContext.SaveChanges();


        }

        public void EliminarCostoAdicionalPorLocacion(int? locacionId)
        {
            List<CostoAdicionales> costoAdicional = SqlContext.CostoAdicionales.Where(o => o.Locacion == locacionId).ToList();

            foreach (var item in costoAdicional)
            {
                SqlContext.CostoAdicionales.Remove(item);
            }
            SqlContext.SaveChanges();

        }

        public List<CostoLogistica> ObtenerCostosLogisticas(int tipoLogisticaId, int localidadId, string cantidadInvitadoId, int tipoEventoId)
        {
            var query = from Cc in SqlContext.CostoLogistica
                        join Tc in SqlContext.TipoLogistica on Cc.ConceptoId equals Tc.Id
                        join Pc in SqlContext.Localidades on Cc.Localidad equals Pc.Id
                        select new
                        {
                            Id = Cc.Id,
                            ConceptoId = Cc.ConceptoId,
                            ConceptoDescripcion = Tc.Concepto,
                            Localidad = Cc.Localidad,
                            LocalidadDescripcion = Pc.Descripcion,
                            CantidadPersonas = Cc.CantidadInvitados,
                            Valor = Cc.Valor,
                            TipoEventoId = Cc.TipoEventoId

                        };

            List<CostoLogistica> Salida = new List<CostoLogistica>();
            foreach (var item in query)
            {

                CostoLogistica cat = new CostoLogistica();

                cat.Id = item.Id;
                cat.ConceptoId = item.ConceptoId;
                cat.ConceptoDescripcion = item.ConceptoDescripcion;
                cat.Localidad = item.Localidad;
                cat.LocalidadDescripcion = item.LocalidadDescripcion; 
                cat.CantidadInvitados = item.CantidadPersonas;
                cat.Valor = item.Valor;
                cat.TipoEventoId = item.TipoEventoId;

                Salida.Add(cat);
            }

            if (tipoLogisticaId > 0)
                Salida = Salida.Where(o => o.ConceptoId == tipoLogisticaId).ToList();

            if (localidadId > 0)
                Salida = Salida.Where(o => o.Localidad == localidadId).ToList();

            if (cantidadInvitadoId != "null")
                Salida = Salida.Where(o => o.CantidadInvitados == Int32.Parse(cantidadInvitadoId)).ToList();

            if (tipoEventoId > 0)
                Salida = Salida.Where(o => o.TipoEventoId == tipoEventoId).ToList();

            return Salida.ToList();
        }

        public void NuevoCostoLogistica(CostoLogistica costo)
        {
            double margen = 0;

            if (costo.Id > 0)
            {
                CostoLogistica edit = SqlContext.CostoLogistica.Where(o => o.Id == costo.Id).SingleOrDefault();

                if (costo.Costo > 0)
                    margen = costo.Valor / costo.Costo;
                else
                    margen = 0;

                edit.ConceptoId = costo.ConceptoId;
                edit.Localidad = costo.Localidad;
                edit.CantidadInvitados = costo.CantidadInvitados;
                edit.TipoEventoId = costo.TipoEventoId;
                edit.Valor = costo.Valor;
                edit.Costo = costo.Costo;
                edit.Margen = margen;

                SqlContext.SaveChanges();
            
            }
            else
            {
                if (costo.Costo > 0)
                    margen = costo.Valor / costo.Costo;
                else
                    margen = 0;

                costo.Margen = margen;


                SqlContext.CostoLogistica.Add(costo);
                SqlContext.SaveChanges();
            }
        }

        public void EliminarCostoLogistica()
        {
            List<CostoLogistica> costoLogistica = SqlContext.CostoLogistica.ToList();

            foreach (var item in costoLogistica)
            {
                SqlContext.CostoLogistica.Remove(item);
            }
            SqlContext.SaveChanges();

        }

        public List<int> ObtenerCantidadPersonasLogistica()
        {
            var query = (from c in SqlContext.CostoLogistica
                         select c.CantidadInvitados).Distinct();

            return query.ToList();
        }


        public List<CostoCanon> ObtenerCostosCanon()
        {
            var query = from Cc in SqlContext.CostoCanon
                        join S in SqlContext.Segmentos on Cc.SegmentoId equals S.Id
                        join C in SqlContext.Caracteristicas on Cc.CaracteristicaId equals C.Id
                        join Tc in SqlContext.TipoCatering on Cc.TipoCateringId equals Tc.Id
                        select new
                        {
                            Id = Cc.Id,
                            SegmentoId = Cc.SegmentoId,
                            CaracteristicaId = Cc.CaracteristicaId,
                            TipoCateringId = Cc.TipoCateringId,
                            SegmentoDescripcion = S.Descripcion,
                            CaracteriticaDescripcion = C.Descripcion,
                            TipoCateringDescripcion = Tc.Descripcion,
                            CanonInterno = Cc.CanonInterno,
                            CanonExterno = (Cc.CanonExterno == null ? null : Cc.CanonExterno),
                            UsoCocina = (Cc.UsoCocina == null ? null : Cc.UsoCocina)

                        };

            List<CostoCanon> Salida = new List<CostoCanon>();
            foreach (var item in query)
            {

                CostoCanon cat = new CostoCanon();

                cat.Id = item.Id;
                cat.SegmentoId = item.SegmentoId;
                cat.CaracteristicaId = item.CaracteristicaId;
                cat.TipoCateringId = item.TipoCateringId;
                cat.SegmentoDescripcion = item.SegmentoDescripcion;
                cat.CaracteristicaDescripcion = item.CaracteriticaDescripcion;
                cat.TipoCateringDescripcion = item.TipoCateringDescripcion;
                cat.CanonInterno = item.CanonInterno;
                cat.CanonExterno = item.CanonExterno;
                cat.UsoCocina = item.UsoCocina;

                Salida.Add(cat);
            }

            return Salida.ToList();
        }

        public void NuevoCostoCanon(CostoCanon costo)
        {
            if (costo.Id > 0)
            {
                CostoCanon edit = SqlContext.CostoCanon.Where(o => o.Id == costo.Id).SingleOrDefault();


                edit.CaracteristicaId = costo.CaracteristicaId;
                edit.SegmentoId = costo.SegmentoId;
                edit.TipoCateringId = costo.TipoCateringId;

                edit.CanonExterno = costo.CanonExterno;
                edit.CanonInterno = costo.CanonInterno;

                SqlContext.SaveChanges();
            
            }
            else
            {

                SqlContext.CostoCanon.Add(costo);
                SqlContext.SaveChanges();
            }
        }

        public void EliminarCostoCanon()
        {
            List<CostoCanon> costoCanon = SqlContext.CostoCanon.ToList();

            foreach (var item in costoCanon)
            {
                SqlContext.CostoCanon.Remove(item);
            }
            SqlContext.SaveChanges();

        }

        public CostoCanon BuscarCostoCanon(int segmentoId, int caracteriticaId, int TipoCateringId)
        {
            return SqlContext.CostoCanon.Where(o => o.SegmentoId == segmentoId && o.CaracteristicaId == caracteriticaId && o.TipoCateringId == TipoCateringId).FirstOrDefault();
        }

        public List<CostoSalones> ObtenerCostoSalones()
        {
            var query = from cs in SqlContext.CostoSalones
                        join l in SqlContext.Locaciones on cs.LocacionId equals l.Id
                        join j in SqlContext.Jornadas on cs.JornadaId equals j.Id
                        join s in SqlContext.Sectores on cs.SectorId equals s.Id
                        select new
                        {
                            Id = cs.Id,
                            LocacionId = cs.LocacionId,
                            SectorId = cs.SectorId,
                            JornadaId = cs.JornadaId,
                            SectorDescripcion = s.Descripcion,
                            JornadaDescripcion = j.Descripcion,
                            LocacionDescripcion = l.Descripcion,
                            Anio = cs.Anio,
                            Mes = cs.Mes,
                            Dia = cs.Dia,
                            CantidadInvitados = cs.CantidadInvitados,
                            PorcentajeTotal = cs.PorcentajedelTotal,
                            Precio = cs.Precio,
                            Costo = cs.Costo,
                            PrecioMas5 = cs.ValorMas5PorCiento,
                            PrecioMenos5 = cs.ValorMenos5PorCiento,
                            PrecioMenos10 = cs.ValorMenos10PorCiento
                        };

            List<CostoSalones> Salida = new List<CostoSalones>();
            foreach (var item in query)
            {

                CostoSalones cat = new CostoSalones();

                cat.Id = item.Id;
                cat.LocacionId = item.LocacionId;
                cat.LocacionDescripcion = item.LocacionDescripcion;
                cat.SectorId = item.SectorId;
                cat.SectorDescripcion = item.SectorDescripcion;
                cat.JornadaId = item.JornadaId;
                cat.JornadaDescripcion = item.JornadaDescripcion;
                cat.Anio = item.Anio;
                cat.Mes = item.Mes;
                cat.Dia = item.Dia;
                cat.CantidadInvitados = item.CantidadInvitados;
                cat.PorcentajedelTotal = item.PorcentajeTotal;
                cat.Precio = item.Precio;
                cat.Costo = item.Costo;
                cat.ValorMas5PorCiento = item.PrecioMas5;
                cat.ValorMenos10PorCiento = item.PrecioMenos10;
                cat.ValorMenos5PorCiento = item.PrecioMenos5;

                Salida.Add(cat);
            }

            return Salida.ToList();

        }


        public void EliminarCostoSalones(int locacionId, int anio)
        {
            CostoSalones costo = SqlContext.CostoSalones.Where(o => o.LocacionId == locacionId && o.Anio == anio).FirstOrDefault();

            if (costo != null)
            {
                SqlContext.CostoSalones.Remove(costo);

                SqlContext.SaveChanges();
            }

        }

        public void NuevoCostoSalon(CostoSalones costo)
        {
            SqlContext.CostoSalones.Add(costo);
            SqlContext.SaveChanges();
        }

        public CostoLogistica BuscarCostoLogistica(int id)
        {
            return SqlContext.CostoLogistica.Where(o => o.Id == id).SingleOrDefault();
        }

        public void ActualizarCostoLogistica(CostoLogistica costos)
        {
            CostoLogistica edit = SqlContext.CostoLogistica.Where(o => o.Id == costos.Id).SingleOrDefault();

            edit.Costo = costos.Costo;
            edit.Valor = costos.Valor;
            edit.Margen = costos.Margen;

            SqlContext.SaveChanges();
        }

        public CostoCanon BuscarCostoCanon(int id)
        {
            return SqlContext.CostoCanon.Where(o => o.Id == id).SingleOrDefault();

        }
    }
}


public partial class ManipuladorExcel
{


    private readonly ExcelQueryFactory _excel;

    public ManipuladorExcel(string nombreArchivo)
    {
        _excel = new ExcelQueryFactory(nombreArchivo)
{
    ReadOnly = true,
    UsePersistentConnection = true
};

    }

    public IEnumerable<CostoSalones> ObtenerCostoSaloneDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<CostoSalones>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();

        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas

    
     

            foreach (var item in listado)
            {




                CostoSalones nuevaPersona = new CostoSalones();


                nuevaPersona.LocacionId = int.Parse(item.ElementAt(0).Value.ToString());
                nuevaPersona.Anio = int.Parse(item.ElementAt(1).Value.ToString());
                nuevaPersona.Mes = int.Parse(item.ElementAt(2).Value.ToString());
                nuevaPersona.Dia = item.ElementAt(3).Value.ToString();
                nuevaPersona.SectorId = int.Parse(item.ElementAt(4).Value.ToString());
                nuevaPersona.JornadaId = int.Parse(item.ElementAt(5).Value.ToString());
                nuevaPersona.CantidadInvitados = int.Parse(item.ElementAt(6).Value.ToString());
                nuevaPersona.PorcentajedelTotal = double.Parse(item.ElementAt(7).Value.ToString());
                nuevaPersona.Precio = double.Parse(item.ElementAt(8).Value.ToString());
                nuevaPersona.Costo = double.Parse(item.ElementAt(9).Value.ToString());

                //var nuevaPersona = new CostoSalones
                //{
                //    LocacionId = int.Parse(item.ElementAt(0).Value.ToString()),
                //    Anio = int.Parse(item.ElementAt(1).Value.ToString()),
                //    Mes = int.Parse(item.ElementAt(2).Value.ToString()),
                //    Dia = item.ElementAt(3).Value.ToString(),
                //    SectorId = int.Parse(item.ElementAt(4).Value.ToString()),
                //    JornadaId = int.Parse(item.ElementAt(5).Value.ToString()),
                //    CantidadInvitados = int.Parse(item.ElementAt(6).Value.ToString()),
                //    PorcentajedelTotal = double.Parse(item.ElementAt(7).Value.ToString()),
                //    Precio = double.Parse(item.ElementAt(8).Value.ToString()),
                //    Costo = double.Parse(item.ElementAt(9).Value.ToString()),
                //    ValorMas5PorCiento = double.Parse(item.ElementAt(11).ToString()),
                //    ValorMenos5PorCiento = double.Parse(item.ElementAt(13).ToString()),
                //    ValorMenos10PorCiento = double.Parse(item.ElementAt(14).ToString()),

                //};

                listaPersonas.Add(nuevaPersona);
            }

            return listaPersonas;

      
    }

    public IEnumerable<CostoCatering> ObtenerCostoCateringDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<CostoCatering>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();

        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas
        foreach (var item in listado)
        {
            var nuevaPersona = new CostoCatering
            {
                TipoCateringId = int.Parse(item.ElementAt(0).Value.ToString()),
                TipoCateringDescripcion = item.ElementAt(1).Value.ToString(),
                CantidadPersonas = int.Parse(item.ElementAt(2).Value.ToString()),
                Precio = double.Parse(item.ElementAt(3).Value.ToString()),
                ValorMas5PorCiento = double.Parse(item.ElementAt(4).ToString()),
                ValorMenos5PorCiento = double.Parse(item.ElementAt(6).ToString()),
                ValorMenos10PorCiento = double.Parse(item.ElementAt(7).ToString()),
                Costo = double.Parse(item.ElementAt(10).ToString())
                //Telefono = item.ElementAt(3).ToString()
            };

            listaPersonas.Add(nuevaPersona);
        }

        return listaPersonas;
    }

    public IEnumerable<CostoBarra> ObtenerCostoBarrasDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<CostoBarra>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();

        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas
        foreach (var item in listado)
        {
            var nuevaPersona = new CostoBarra
            {
                TipoBarraId = int.Parse(item.ElementAt(0).Value.ToString()),
                TipoBarraDescripcion = item.ElementAt(1).Value.ToString(),
                CantidadPersonas = int.Parse(item.ElementAt(3).Value.ToString()),
                Precios = double.Parse(item.ElementAt(4).Value.ToString()),
                ValorMas5PorCiento = double.Parse(item.ElementAt(5).ToString()),
                ValorMenos5PorCiento = double.Parse(item.ElementAt(7).ToString()),
                ValorMenos10PorCiento = double.Parse(item.ElementAt(8).ToString()),
                Costo = double.Parse(item.ElementAt(9).ToString())
                //Telefono = item.ElementAt(3).ToString()
            };

            listaPersonas.Add(nuevaPersona);
        }

        return listaPersonas;
    }

    public IEnumerable<CostoTecnica> ObtenerCostoTecnicaDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<CostoTecnica>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();

        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas
        foreach (var item in listado)
        {
            var nuevaPersona = new CostoTecnica
            {
                TipoServicioId = int.Parse(item.ElementAt(5).Value.ToString()),
                TipoServicioDescripcion = item.ElementAt(15).Value.ToString(),
                SegmentoId = int.Parse(item.ElementAt(4).Value.ToString()),
                SegmentoDescripcion = item.ElementAt(14).Value.ToString(),
                Anio = int.Parse(item.ElementAt(3).Value.ToString()),
                Mes = int.Parse(item.ElementAt(2).Value.ToString()),
                Dia = item.ElementAt(1).Value.ToString(),
                Precio = double.Parse(item.ElementAt(6).Value.ToString()),
                ValorMas5PorCiento = double.Parse(item.ElementAt(7).ToString()),
                ValorMenos5PorCiento = double.Parse(item.ElementAt(9).ToString()),
                ValorMenos10PorCiento = double.Parse(item.ElementAt(10).ToString())
                //Costo =(item.ElementAt(13) == null ? '0' : double.Parse(item.ElementAt(13).ToString()))

                //(Cc.ProveedorId == null ? null : Cc.ProveedorId),
                //Telefono = item.ElementAt(3).ToString()
            };

            listaPersonas.Add(nuevaPersona);
        }

        return listaPersonas;
    }

    public IEnumerable<CostoAmbientacion> ObtenerCostoAmbientacionDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<CostoAmbientacion>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();

        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas
        foreach (var item in listado)
        {
            var nuevaPersona = new CostoAmbientacion
            {
                CategoriaId = int.Parse(item.ElementAt(0).Value.ToString()),
                CategoriaDescripcion = item.ElementAt(1).Value.ToString(),
                CantidadInvitados = int.Parse(item.ElementAt(2).Value.ToString()),
                Precio = double.Parse(item.ElementAt(3).Value.ToString()),
                ValorMas5PorCiento = double.Parse(item.ElementAt(4).ToString()),
                ValorMenos5PorCiento = double.Parse(item.ElementAt(6).ToString()),
                ValorMenos10PorCiento = double.Parse(item.ElementAt(7).ToString())
                //Costo =(item.ElementAt(10) == null ? '0' : double.Parse(item.ElementAt(13).ToString()))


            };

            listaPersonas.Add(nuevaPersona);
        }

        return listaPersonas;
    }

    public IEnumerable<CostoAdicionales> ObtenerCostoAdicionalesDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<CostoAdicionales>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();

        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas
        foreach (var item in listado)
        {
            var nuevaPersona = new CostoAdicionales
            {
                AdicionalId = int.Parse(item.ElementAt(0).Value.ToString()),
                AdicionalDescripcion = item.ElementAt(1).Value.ToString(),
                CantidadPersonas = int.Parse(item.ElementAt(2).Value.ToString()),
                Precio = double.Parse(item.ElementAt(3).Value.ToString()),
                ValorMas5PorCiento = double.Parse(item.ElementAt(4).ToString()),
                ValorMenos5PorCiento = double.Parse(item.ElementAt(6).ToString()),
                ValorMenos10PorCiento = double.Parse(item.ElementAt(7).ToString()),
                Costo = double.Parse(item.ElementAt(8).ToString()),
                ProveedorId = int.Parse(item.ElementAt(2).Value.ToString()),
                Locacion = int.Parse(item.ElementAt(2).Value.ToString())


            };

            listaPersonas.Add(nuevaPersona);
        }

        return listaPersonas;
    }

    public IEnumerable<CostoLogistica> ObtenerCostoLogisticaDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<CostoLogistica>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();

        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas
        foreach (var item in listado)
        {
            var nuevaPersona = new CostoLogistica
            {
                ConceptoId = int.Parse(item.ElementAt(0).Value.ToString()),
                ConceptoDescripcion = item.ElementAt(1).Value.ToString(),
                LocalidadDescripcion = item.ElementAt(2).Value.ToString(),
                Localidad = int.Parse(item.ElementAt(3).Value.ToString()),
                CantidadInvitados = int.Parse(item.ElementAt(4).ToString()),
                Valor = double.Parse(item.ElementAt(6).ToString())



            };

            listaPersonas.Add(nuevaPersona);
        }

        return listaPersonas;
    }

    public IEnumerable<CostoCanon> ObtenerCostoCanonDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<CostoCanon>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();

        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas
        foreach (var item in listado)
        {
            var nuevaPersona = new CostoCanon
            {
                SegmentoId = int.Parse(item.ElementAt(0).Value.ToString()),
                CaracteristicaId = int.Parse(item.ElementAt(2).Value.ToString()),
                TipoCateringId = int.Parse(item.ElementAt(4).Value.ToString()),
                SegmentoDescripcion = item.ElementAt(1).Value.ToString(),
                CaracteristicaDescripcion = item.ElementAt(3).ToString(),
                TipoCateringDescripcion = item.ElementAt(5).ToString(),
                CanonInterno = double.Parse(item.ElementAt(6).ToString()),
                CanonExterno = double.Parse(item.ElementAt(7).ToString()),
                UsoCocina = double.Parse(item.ElementAt(8).ToString())



            };

            listaPersonas.Add(nuevaPersona);
        }

        return listaPersonas;
    }

    public IEnumerable<ConfiguracionCateringTecnica> ObtenerConfiguracionCateringTecnicaDesdeArchivo(string CeldaInicio, string CeldaFin)
    {
        var listaPersonas = new List<ConfiguracionCateringTecnica>();

        //Tomaremos los valores desde B3 a E9, en la primera hoja, es decir el índice 0
        //Y lo guardamos en la varible listado
        var listado = _excel.WorksheetRangeNoHeader(CeldaInicio, CeldaFin, 0).ToList();



        //Iteramos sobre este listado y generamos nuestros objetos para agregarlos a la lista de personas
        foreach (var item in listado)
        {
            var nuevaPersona = new ConfiguracionCateringTecnica
            {
                SegmentoId = int.Parse(item.ElementAt(1).Value.ToString()),
                CaracteristicaId = int.Parse(item.ElementAt(9).Value.ToString()),
                TipoCateringId = int.Parse(item.ElementAt(7).Value.ToString()),
                TipoServicioId = int.Parse(item.ElementAt(11).Value.ToString()),
                MomentoDiaId = int.Parse(item.ElementAt(3).ToString()),
                DuracionId = int.Parse(item.ElementAt(5).ToString()),

                SegmentoDescripcion = item.ElementAt(0).Value.ToString(),
                CaracteristicaDescripcion = item.ElementAt(8).Value.ToString(),
                TipoCateringDescripcion = item.ElementAt(6).Value.ToString(),
                TipoServicioDescripcion = item.ElementAt(10).Value.ToString(),
                MomentodelDiaDescripcion = item.ElementAt(2).Value.ToString(),
                DuracionDescripcion = item.ElementAt(4).Value.ToString()


            };

            listaPersonas.Add(nuevaPersona);
        }

        return listaPersonas;


    }


}
