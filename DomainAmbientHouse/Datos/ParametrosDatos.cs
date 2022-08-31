using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class ParametrosDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }


        public ParametrosDatos()
        {
            SqlContext = new AmbientHouseEntities();
        }
        
        public virtual Parametros BuscarParametros(string valorParametro)
        {

            return SqlContext.Parametros.Where(o=> o.Descripcion.Equals(valorParametro)).FirstOrDefault();

        }


        public List<Parametros> ObtenerParametros()
        {
            return SqlContext.Parametros.ToList();
        }

        public Parametros BuscarParametros(int id)
        {
            return SqlContext.Parametros.Where(o => o.Id == id).FirstOrDefault();
        }

        public void NuevoParametros(Parametros parametros)
        {
            if (parametros.Id > 0)
            {

                Parametros catEdit = SqlContext.Parametros.Where(o => o.Id == parametros.Id).First();

                catEdit.Descripcion = parametros.Descripcion;
                catEdit.Valor = parametros.Valor;


                SqlContext.SaveChanges();
            }
            else
            {

                SqlContext.Parametros.Add(parametros);
                SqlContext.SaveChanges();
            }

        }
    }
}
