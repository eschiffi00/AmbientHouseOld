namespace DbEntidades.Entities
{
    public partial class Negocios
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return "\r\n " +
            "Id: " + Id.ToString() + "\r\n ";
        }
        public Negocios()
        {
            Id = -1;

        }





        public static bool CanBeNull(string colName)
        {
            switch (colName)
            {
                case "Id": return false;
                default: return false;
            }
        }
    }
}

