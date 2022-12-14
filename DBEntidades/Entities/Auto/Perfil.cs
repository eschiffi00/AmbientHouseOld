namespace DbEntidades.Entities
{
    public partial class Perfil
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return "\r\n " +
            "ID: " + ID.ToString() + "\r\n " +
            "Descripcion: " + Descripcion.ToString() + "\r\n ";
        }
        public Perfil()
        {
            ID = -1;

        }





        public static bool CanBeNull(string colName)
        {
            switch (colName)
            {
                case "ID": return false;
                case "Descripcion": return false;
                default: return false;
            }
        }
    }
}

