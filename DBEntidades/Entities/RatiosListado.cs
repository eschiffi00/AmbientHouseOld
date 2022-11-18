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
        public string DetalleTipo { get; set; }
        public double? ValorRatio { get; set; }
        public double? TopeRatio { get; set; }
        public int Adultos { get; set; }
        public int Menores3 { get; set; }
        public int Menores3y8 { get; set; }
        public int Adolescentes { get; set; }
        public int AdicionalRatio { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }

        public override string ToString()
        {
            return "\r\n " +
            "ID: " + Id.ToString() + "\r\n " +
            "ItemId: " + ItemId.ToString() + "\r\n " +
            "ItemDetalle: " + ItemDetalle.ToString() + "\r\n " +
            "TipoRatio: " + TipoRatio.ToString() + "\r\n " +
            "DetalleTipo: " + DetalleTipo.ToString() + "\r\n " +
            "TopeRatio: " + TopeRatio.ToString() + "\r\n " +
            "Menores3: " + Menores3.ToString() + "\r\n " +
            "Menores3y8: " + Menores3y8.ToString() + "\r\n " +
            "Adolescentes: " + Adolescentes.ToString() + "\r\n " +
            "EstadoID: " + EstadoId.ToString() + "\r\n " +
            "Estado: " + Estado.ToString() + "\r\n ";
        }
        public RatiosListado()
        {
            Id = -1;

        }
    }

}

