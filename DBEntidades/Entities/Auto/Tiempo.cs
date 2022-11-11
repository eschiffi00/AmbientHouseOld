namespace DbEntidades.Entities
{
    public partial class Tiempo
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public int Orden { get; set; }

        public override string ToString()
        {
            return "\r\n " +
            "ID: " + ID.ToString() + "\r\n " +
            "Descripcion: " + Descripcion.ToString() + "\r\n " +
            "Duracion: " + Duracion.ToString() + "\r\n " +
            "Orden: " + Orden.ToString() + "\r\n ";
        }
        public Tiempo()
        {
            ID = -1;

        }





        public static bool CanBeNull(string colName)
        {
            switch (colName)
            {
                case "ID": return false;
                case "Descripcion": return false;
                case "Duracion": return false;
                case "Orden": return false;
                default: return false;
            }
        }
    }
}

