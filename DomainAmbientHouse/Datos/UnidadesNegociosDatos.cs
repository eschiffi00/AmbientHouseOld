using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class UnidadesNegociosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public UnidadesNegociosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }

        public virtual List<UnidadesNegocios> ObtenerUnidadesNegociosPorDepartamento()
        {

            return SqlContext.UnidadesNegocios.ToList();


        }

        public List<UnidadesNegocios> ObtenerUN()
        {
            var query = from u in SqlContext.UnidadesNegocios
                        select new
                        {
                            Id = u.Id,
                            Descripcion = u.Descripcion,
                           

                        };

            List<UnidadesNegocios> Salida = new List<UnidadesNegocios>();
            foreach (var item in query)
            {

                UnidadesNegocios cat = new UnidadesNegocios();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;
               
              


                Salida.Add(cat);
            }

            return Salida.ToList();

        }

        public List<UnidadesNegocios> ObtenerUNCotizador()
        {
            int unCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int unTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int unAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
            int unBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int unOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
           


            List<int> lista = new List<int> { unCatering, unTecnica, unAmbientacion, unBarra, unOrganizacion };

            var query = from u in SqlContext.UnidadesNegocios
                        where lista.Contains(u.Id)
                        select new
                        {
                            Id = u.Id,
                            Descripcion = u.Descripcion,


                        };

            List<UnidadesNegocios> Salida = new List<UnidadesNegocios>();
            foreach (var item in query)
            {

                UnidadesNegocios cat = new UnidadesNegocios();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;




                Salida.Add(cat);
            }

            return Salida.ToList();

        }


        public List<UnidadesNegocios> ObtenerUNReporte()
        {
            int unCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int unTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int unAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
            int unBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int unOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());
            int unAdicional = Int32.Parse(ConfigurationManager.AppSettings["RubroAdicional"].ToString());



            List<int> lista = new List<int> { unCatering, unTecnica, unAmbientacion, unBarra, unOrganizacion, unAdicional };

            var query = from u in SqlContext.UnidadesNegocios
                        where lista.Contains(u.Id)
                        select new
                        {
                            Id = u.Id,
                            Descripcion = u.Descripcion,


                        };

            List<UnidadesNegocios> Salida = new List<UnidadesNegocios>();
            foreach (var item in query)
            {

                UnidadesNegocios cat = new UnidadesNegocios();

                cat.Id = item.Id;
                cat.Descripcion = item.Descripcion;




                Salida.Add(cat);
            }

            return Salida.ToList();

        }

        public UnidadesNegocios BuscarUnidadesNegocios(int id)
        {
            return SqlContext.UnidadesNegocios.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevoUnidadesNegocios(UnidadesNegocios rubro)
        {
            if (rubro.Id > 0)
            {

                UnidadesNegocios rubroEdit = SqlContext.UnidadesNegocios.Where(o => o.Id == rubro.Id).First();

                rubroEdit.Descripcion = rubro.Descripcion;
                


                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.UnidadesNegocios.Add(rubro);
                SqlContext.SaveChanges();
            }
        }

        public List<UnidadesNegocios> ObtenerUnidadesNegocios()
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
            int RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());


            List<int> lista = new List<int>() { RubroCatering, RubroTecnica, RubroAmbientacion, RubroBarra, RubroSalon };


            var query = from un in SqlContext.UnidadesNegocios
                        where lista.Contains(un.Id)
                        select un;

            return query.ToList();

        }

        public List<UnidadesNegocios_Proveedores> BuscarUnidadesNegociosPorProveedor(int ProveedorId)
        {
            var query = from UNP in SqlContext.UnidadesNegocios_Proveedores
                        join Un in SqlContext.UnidadesNegocios on UNP.UnidadNegocioId equals Un.Id
                        where UNP.ProveedorId == ProveedorId
                        select new { 
                        Id = UNP.Id,
                        UnidadNegocioId= UNP.UnidadNegocioId,
                        Descripcion = Un.Descripcion
                        };


            List<UnidadesNegocios_Proveedores> Salida = new List<UnidadesNegocios_Proveedores>();
            foreach (var item in query)
            {
                UnidadesNegocios_Proveedores unproveedor = new UnidadesNegocios_Proveedores();

                unproveedor.Id = item.Id;
                unproveedor.UnidadNegocioId = item.UnidadNegocioId;
                unproveedor.Descripcion = item.Descripcion;

                Salida.Add(unproveedor);
            }

            return Salida;
        }

        public List<UnidadesNegocios> ObtenerUN(List<UnidadesNegocios> ListUN)
        {
            int RubroCatering = Int32.Parse(ConfigurationManager.AppSettings["RubroCatering"].ToString());
            int RubroTecnica = Int32.Parse(ConfigurationManager.AppSettings["RubroTecnica"].ToString());
            int RubroAmbientacion = Int32.Parse(ConfigurationManager.AppSettings["RubroAmbientacion"].ToString());
            int RubroBarra = Int32.Parse(ConfigurationManager.AppSettings["RubroBarras"].ToString());
            int RubroSalon = Int32.Parse(ConfigurationManager.AppSettings["RubroSalon"].ToString());
            int RubroOrganizacion = Int32.Parse(ConfigurationManager.AppSettings["RubroOrganizacion"].ToString());


            List<int> lista = new List<int>() { RubroCatering, RubroTecnica, RubroAmbientacion, RubroBarra, RubroSalon, RubroOrganizacion };


            List<UnidadesNegocios> queryFinal = (from un in SqlContext.UnidadesNegocios
                        where lista.Contains(un.Id)
                        select un).ToList();



            return queryFinal.Except(ListUN).ToList();

        }
    }
}
