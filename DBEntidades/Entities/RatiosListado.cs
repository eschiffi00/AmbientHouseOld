namespace DbEntidades.Entities
{
    public partial class RatiosListado
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemDetalle { get; set; }
        public string ExperienciaBarra { get; set; }
        public string ExperienciaBarraCodigo { get; set; }
        public string TipoRatio { get; set; }
        public double BaseRatio { get; set; }
        public double ValorRatio { get; set; }
        public double TopeRatio { get; set; }
        public string Isla { get; set; }
        public string Adultos { get; set; }
        public string Menores3 { get; set; }
        public string Menores3y8 { get; set; }
        public string Adolescentes { get; set; }
        public string FijoRatio { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }
        public int? ItemRatioId { get; set; }
        public int? ProductoRatioId { get; set; }
        public int? CategoriaRatioId { get; set; }

        public override string ToString()
        {
            return "\r\n " +
            "ID: " + Id.ToString() + "\r\n " +
            "ItemId: " + ItemId.ToString() + "\r\n " +
            "ItemDetalle: " + ItemDetalle.ToString() + "\r\n " +
            "TipoRatio: " + TipoRatio.ToString() + "\r\n " +
            "DetalleTipo: " + BaseRatio.ToString() + "\r\n " +
            "TopeRatio: " + TopeRatio.ToString() + "\r\n " +
            "ItemRatioId: " + ItemRatioId.ToString() + "\r\n " +
            "Isla: " + Isla.ToString() + "\r\n " +
            "Adultos: " + Adultos.ToString() + "\r\n " +
            "Menores3: " + Menores3.ToString() + "\r\n " +
            "Menores3y8: " + Menores3y8.ToString() + "\r\n " +
            "Adolescentes: " + Adolescentes.ToString() + "\r\n " +
            "EstadoID: " + EstadoId.ToString() + "\r\n " +
            "Estado: " + Estado.ToString() + "\r\n ";
        }
        public RatiosListado()
        {
            Id = -1;
            ItemId = 0;
            ItemDetalle = "";         
            ExperienciaBarra = "";
            ExperienciaBarraCodigo = "";
            TipoRatio = "";
            BaseRatio = 0.0;
            ValorRatio = 0.0;
            TopeRatio = 0.0;
            Isla = "";
            Adultos = "";
            Menores3 = "";
            Menores3y8 = "";
            Adolescentes = "";
            FijoRatio = "";
            EstadoId = 0;              
            Estado = "";
            ItemRatioId = 0;
            ProductoRatioId = 0;
            CategoriaRatioId = 0;

        }
    }

}

