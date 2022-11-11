using DomainAmbientHouse.Entidades;

namespace DomainAmbientHouse.Datos
{
    public class ValorHorasDatos
    {
        public AmbientHouseEntities SqlContext { get; set; }

        //public ValorHorasDatos()
        //{
        //    SqlContext = new AmbientHouseEntities();
        //}

        //public virtual List<ValorHoras> ObtenerValorHoras()
        //{

        //    return SqlContext.ValorHoras.ToList();

        //}

        //public ValorHoras BuscarValorHoras(int id)
        //{
        //    return SqlContext.ValorHoras.Where(o => o.Id == id).FirstOrDefault();
        //}

        //public void NuevoValorHora(ValorHoras vh)
        //{
        //    if (vh.Id > 0)
        //    {

        //        ValorHoras edit = SqlContext.ValorHoras.Where(o => o.Id == vh.Id).First();

        //        edit.SectorEmpresaId = vh.SectorEmpresaId;
        //        edit.TipoEmpleadoId = vh.TipoEmpleadoId;
        //        edit.TipoPagoId = vh.TipoPagoId;
        //        edit.Valor = vh.Valor;

        //        SqlContext.SaveChanges();

        //    }
        //    else
        //    {
        //        SqlContext.ValorHoras.Add(vh);
        //        SqlContext.SaveChanges();
        //    }
        //}

        //public ValorHoras BuscarValorHoraPorSectorTipoEmpleadoTipoPago(int sectorId, int tipoEmpleadoId, int tipoPagoId)
        //{

        //    return SqlContext.ValorHoras.SingleOrDefault(o => o.SectorEmpresaId == sectorId 
        //                                                    && o.TipoEmpleadoId == tipoEmpleadoId 
        //                                                    && o.TipoPagoId == tipoPagoId);
        //}

    }
}
