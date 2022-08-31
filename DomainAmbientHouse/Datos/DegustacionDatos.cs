using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;
using System.Configuration;

namespace DomainAmbientHouse.Datos
{
    public class DegustacionDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        public DegustacionDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }


        public bool GrabarDegustacion(Degustacion degustacion)
        {

            try
            {
                if (degustacion.Id <= 0)
                {
                    this.SqlContext.Degustacion.Add(degustacion);
                    this.SqlContext.SaveChanges();
                    return true;
                }
                else
                {
                    Degustacion edit = SqlContext.Degustacion.Where(o => o.Id == degustacion.Id).FirstOrDefault();

                    edit.CantidadMesas = degustacion.CantidadMesas;
                    edit.FechaDegustacion = degustacion.FechaDegustacion;
                    edit.HoraCorporativo = degustacion.HoraCorporativo;
                    edit.HoraSocial = degustacion.HoraSocial;
                    edit.Locacion = degustacion.Locacion;
                    edit.EstadoId = degustacion.EstadoId;
                    edit.ConfirmoTecnica = degustacion.ConfirmoTecnica;
                    edit.ConfirmoAmbientacion = degustacion.ConfirmoAmbientacion;
                    SqlContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public virtual List<Degustacion> ObtenerDegustaciones()
        {
            var query = from d in SqlContext.Degustacion
                        select d;


            return this.DegustacionToModel(query).ToList();
        }

        private List<Degustacion> DegustacionToModel(IQueryable<Degustacion> query)
        {

            List<Degustacion> list = new List<Degustacion>();

            foreach (var item in query)
            {
                Degustacion salida = new Degustacion();

                salida.Id = item.Id;

                salida.HoraSocial = item.HoraSocial;
                salida.HoraCorporativo = item.HoraCorporativo;
                salida.FechaDegustacion = item.FechaDegustacion;
                salida.CantidadMesas = item.CantidadMesas;
                salida.EstadoId = item.EstadoId;
                salida.EstadoDescripcion = SqlContext.Estados.Where(o => o.Id == item.EstadoId).FirstOrDefault().Descripcion;
                salida.FechaDegustacion = item.FechaDegustacion;
                salida.ConfirmoAmbientacion = item.ConfirmoAmbientacion;
                salida.ConfirmoTecnica = item.ConfirmoTecnica;
                salida.Locacion = item.Locacion;
                salida.LocacionDescripcion = SqlContext.Locaciones.Where(o => o.Id == item.Locacion).FirstOrDefault().Descripcion;

                list.Add(salida);

            }
            return list;
        }

        public Degustacion BuscarDegustacion(int id)
        {
            return this.SqlContext.Degustacion.Where(o => o.Id == id).FirstOrDefault();
        }




    }
}

namespace DomainAmbientHouse.Entidades
{
    public partial class Degustacion
    {
        public string EstadoDescripcion { get; set; }

        public string LocacionDescripcion { get; set; }


        public string Identificador {

            get {
                return "Degustacion: " + String.Format("{0:dd/MM/yyyy}", FechaDegustacion);
            }
        }
    }
}


