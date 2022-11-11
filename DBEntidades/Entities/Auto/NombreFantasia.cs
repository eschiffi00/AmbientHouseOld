namespace DbEntidades.Entities
{
    public partial class NombreFantasia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return "\r\n " +
            "Id: " + Id.ToString() + "\r\n " +
            "Descripcion: " + Descripcion.ToString() + "\r\n ";
        }
        public NombreFantasia()
        {
            Id = -1;

        }





        public static bool CanBeNull(string colName)
        {
            switch (colName)
            {
                case "Id": return false;
                case "Descripcion": return true;
                default: return false;
            }
        }
    }
}

