using DbEntidades.Entities;
using LibDB2;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace DbEntidades.Operators
{
    public partial class RatiosOperator
    {
        ////GetAllWithDetails////
        // Inputs:
        // Obtiene todos los registros al igual que GetAll
        // pero los pasa a una clase con datos extras para mostrar en pantalla
        public static List<RatiosListado> GetAllWithDetails()
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoProductoBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            List<RatiosListado> lista = new List<RatiosListado>();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios").Tables[0];
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Ratios Ratios = new Ratios();
                foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(Ratios, value, null); }
                    catch (System.ArgumentException) { }
                }
                RatiosListado RatiosDetail = new RatiosListado();
                RatiosDetail.Id = Ratios.Id;
                RatiosDetail.ItemId = Ratios.ItemId;
                RatiosDetail.ExperienciaBarraCodigo = Ratios.ExperienciaBarra;
                if (Ratios.ExperienciaBarra.Substring(0, 3) == "BAR")
                {
                    RatiosDetail.ExperienciaBarra = TiposBarrasOperator.GetOneByParameter("Id", Ratios.ExperienciaBarra.Substring(3)).Descripcion;
                }
                else
                {
                    RatiosDetail.ExperienciaBarra = TipoCateringOperator.GetOneByParameter("Id", Ratios.ExperienciaBarra.Substring(4)).Descripcion;
                }
                RatiosDetail.ItemDetalle = ItemsOperator.GetOneByIdentity(Ratios.ItemId).Detalle;
                RatiosDetail.TipoRatio = Ratios.TipoRatio;
                RatiosDetail.BaseRatio = Ratios.BaseRatio;
                RatiosDetail.ValorRatio = Ratios.ValorRatio;
                RatiosDetail.TopeRatio = Ratios.TopeRatio;
                RatiosDetail.ItemRatioId = Ratios.ItemRatioId;
                RatiosDetail.Isla = Ratios.Isla.Value ? "Si":"No";
                RatiosDetail.Adultos = Ratios.Adultos ? "Si" : "No";
                RatiosDetail.Menores3 = Ratios.Menores3 ? "Si" : "No";
                RatiosDetail.Menores3y8 = Ratios.Menores3y8 ? "Si" : "No";
                RatiosDetail.Adolescentes = Ratios.Adolescentes ? "Si" : "No";
                RatiosDetail.FijoRatio = Ratios.FijoRatio ? "Si" : "No";
                RatiosDetail.EstadoId = Ratios.EstadoId;

                RatiosDetail.Estado = EstadosOperator.GetOneByIdentity(RatiosDetail.EstadoId).Descripcion;

                lista.Add(RatiosDetail);
            }
            return lista;
        }
        ////GetAllByParameter////
        // Inputs: nombrecampo / valor 
        // funciona tanto para campos int como para campos string y realiza la conversion
        
        // Ratio Validation //
        // recibe un list con los campos ItemId,CategoriaId,TipoRatio,DetalleTipo 
        // deben estar en ese orden
        public static bool RatioValidation(List<string> key)
        {
            bool result = false;
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios where  ItemId = " + key[0]
                                                                                       + "and ExperienciaBarra = \'" + key[1] + "\'"
                                                                                       + "and CategoriaId = " + key[2]
                                                                                       + "and TipoRatio = \'" + key[3] + "\'"
                                                                                       + "and DetalleTipo = \'" + key[4] + "\'").Tables[0];

            if (dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public static int GetRatioId(List<string> key)
        {
            if (!DbEntidades.Seguridad.Permiso("PermisoRatiosBrowse")) throw new PermisoException();
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios where  ItemId = " + key[0]
                                                                                       + "and ExperienciaBarra = \'" + key[1] + "\'"
                                                                                       + "and CategoriaId = " + key[2]
                                                                                       + "and TipoRatio = \'" + key[3] + "\'"
                                                                                       + "and DetalleTipo = \'" + key[4] + "\'").Tables[0];
            var id = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
                {
                    string value = dt.Rows[0]["Id"].ToString();
                    id = int.Parse(value);
                }

            }

            return id;
        }
        public static void Delete(int id)
        {
            Ratios u = RatiosOperator.GetOneByIdentity(id);
            u.EstadoId = EstadosOperator.GetDeshabilitadoID("Ratios");
            Update(u);
        }
        public static double ObtenerValorRatio(int ItemId,int ProductoId,int CategoriaItemId,string clave,int canAdultos,int canMenores3, int canMenores3y8,int canAdolescentes)
        {
            var ratioFinal = 0.0;
            string columnas = string.Empty;
            foreach (PropertyInfo prop in typeof(Ratios).GetProperties()) columnas += prop.Name + ", ";
            columnas = columnas.Substring(0, columnas.Length - 2);
            DB db = new DB();
            var claveTabla = "";
            if (ItemId > 0) claveTabla = "ItemId = " + ItemId;
            if (ProductoId > 0)
            {
                claveTabla = "ItemId = -1 and ProductoRatioId = " + ProductoId;
            }
            if (CategoriaItemId > 0) claveTabla = "ItemId = -1 and CategoriaItemId = " + CategoriaItemId;
            DataTable dt = db.GetDataSet("select " + columnas + " from Ratios where " + claveTabla
                                                                                        + " and ExperienciaBarra = \'" + clave + "\'"
                                                                                        + "order by BaseRatio"
                                                                                        ).Tables[0];
            List<Ratios> lista = new List<Ratios>();
            foreach (DataRow dr in dt.AsEnumerable())
            {

                Ratios entidad = new Ratios();
                foreach (PropertyInfo prop in typeof(Ratios).GetProperties())
                {
                    object value = dr[prop.Name];
                    if (value == DBNull.Value) value = null;
                    try { prop.SetValue(entidad, value, null); }
                    catch (System.ArgumentException) { }
                }
                lista.Add(entidad);
            }
            List<int> parametros = new List<int>();
            parametros.Add(canAdultos);
            parametros.Add(canMenores3);
            parametros.Add(canMenores3y8);
            parametros.Add(canAdolescentes);

            ratioFinal = CalculaValorRatio(lista, parametros);
            

            return ratioFinal;
        }
        private static double CalculaValorRatio(List<Ratios> lista ,List<int> parametros)
        {
            var valorRatio = 0.0;
            List<Ratios> listaFiltrada = new List<Ratios>();
            if (lista.Count > 0)
            {
                List<Ratios> lista2 = new List<Ratios>();
                if (parametros[0] > 0)
                {
                    lista2 = lista.Where(x => x.Adultos == true).ToList();
                    if(lista2.Count > 0)
                    {
                        listaFiltrada.Add(lista2.First(x => x.TopeRatio >= parametros[0]));
                    }
                }
                if (parametros[1] > 0)
                    listaFiltrada.Add(lista.First(x => x.TopeRatio >= parametros[1] && x.Menores3 == true));
                if (parametros[2] > 0)
                    listaFiltrada.Add(lista.First(x => x.TopeRatio >= parametros[2] && x.Menores3y8 == true));
                if (parametros[3] > 0)
                    listaFiltrada.Add(lista.First(x => x.TopeRatio >= parametros[3] && x.Adolescentes == true));

                var listaItem = listaFiltrada.Where(x => x.TipoRatio == "ITEM").ToList();
                var listaPax = listaFiltrada.Where(x => x.TipoRatio == "PAX").ToList();
                if (listaPax.Any())
                {
                    valorRatio = CalculaRatioPAX(listaPax, parametros);
                }
                if (listaItem.Any())
                {
                    valorRatio = CalculaRatioITEM(listaItem, parametros);
                }
            }
            return valorRatio;
        }
        private static double CalculaRatioPAX(List<Ratios> lista, List<int> parametros)
        {
            double valorRatio = 0.0;
            foreach (var ratio in lista)
            {
                if (ratio.Adultos == true)
                {
                    valorRatio = valorRatio + (ratio.ValorRatio * parametros[0]);
                }
                if (ratio.Menores3 == true)
                {
                    valorRatio = valorRatio + (ratio.ValorRatio * parametros[1]);
                }
                if (ratio.Menores3y8 == true)
                {
                    valorRatio = valorRatio + (ratio.ValorRatio * parametros[2]);
                }
                if (ratio.Adolescentes == true)
                {
                    valorRatio = valorRatio + (ratio.ValorRatio * parametros[3]);
                }
            }
            return valorRatio;
        }
        public static double CalculaRatioITEM(List<Ratios> lista, List<int> parametros)
        {
            double valorRatio = 0.0;
            List<string> fields = new List<string>();
            List<string> values = new List<string>();
            List<string> getFields = new List<string>();
            //itero todos los ratios de la lista de argumentos
            foreach (var ratio in lista)
            {
                fields.Clear();
                values.Clear();
                fields.Add("ItemId");
                values.Add(ratio.ItemRatioId.ToString());
                fields.Add("ExperienciaBarra");
                values.Add(ratio.ExperienciaBarra);
                fields.Add("TipoRatio");
                values.Add("PAX");
                //utilizo el validador comun para ver si existe un ratio tipo PAX correspondiente al itemratioid del ratio ITEM
                if (CommonOperator.CommonValidation("Ratios", fields, values))
                {
                    var ratiosData = CommonOperator.CommonGetRecords("Ratios", fields, getFields, values);
                    foreach (var ratiodta in ratiosData)
                    {
                        //CommonGetRecords recupera en este caso todos los campos de la tabla en una lista tipo matriz
                        //los campos ratio[9..12] corresponden a los bool adultos, menores,etc...
                        if (ratiodta[9] == "1")
                        {
                            valorRatio = valorRatio + (double.Parse(ratiodta[5]) * parametros[0]);
                        }
                        if (ratiodta[10] == "1")
                        {
                            valorRatio = valorRatio + (double.Parse(ratiodta[5]) * parametros[1]);
                        }
                        if (ratiodta[11] == "1")
                        {
                            valorRatio = valorRatio + (double.Parse(ratiodta[5]) * parametros[2]);
                        }
                        if (ratiodta[12] == "1")
                        {
                            valorRatio = valorRatio + (double.Parse(ratiodta[5]) * parametros[3]);
                        }
                    }
                }
            }
            
            return valorRatio;
        }
    }
}
