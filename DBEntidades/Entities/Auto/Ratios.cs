namespace DbEntidades.Entities
{
    public partial class Ratios
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ExperienciaBarra { get; set; }
        public string TipoRatio { get; set; }
        public string DetalleTipo { get; set; }
        public double? ValorRatio { get; set; }
        public double? TopeRatio { get; set; }
        public int? IslaId { get; set; }
        public int Menores3 { get; set; }
        public int Menores3y8 { get; set; }
        public int Adolescentes { get; set; }
        public int AdicionalRatio { get; set; }
        public int EstadoId { get; set; }

        public override string ToString()
        {
            return "\r\n " +
            "Id: " + Id.ToString() + "\r\n " +
            "ItemId: " + ItemId.ToString() + "\r\n " +
            "TipoRatio: " + TipoRatio.ToString() + "\r\n " +
            "DetalleTipo: " + DetalleTipo.ToString() + "\r\n " +
            "ValorRatio: " + ValorRatio.ToString() + "\r\n " +
            "TopeRatio: " + TopeRatio.ToString() + "\r\n " +
            "Menores3: " + Menores3.ToString() + "\r\n " +
            "Menores3y8: " + Menores3y8.ToString() + "\r\n " +
            "Adolescentes: " + Adolescentes.ToString() + "\r\n " +
            "AdicionalRatio: " + AdicionalRatio.ToString() + "\r\n " +
            "EstadoId: " + EstadoId.ToString() + "\r\n ";
        }
        public Ratios()
        {
            Id = -1;

        }





        public static bool CanBeNull(string colName)
        {
            switch (colName)
            {
                case "Id": return false;
                case "ItemId": return false;
                case "TipoRatio": return false;
                case "DetalleTipo": return false;
                case "ValorRatio": return false;
                case "TopeRatio": return false;
                case "Menores3": return false;
                case "Menores3y8": return false;
                case "Adolescentes": return false;
                case "AdicionalRatio": return false;
                default: return false;
            }
        }
    }
}

