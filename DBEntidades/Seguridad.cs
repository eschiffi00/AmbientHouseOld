namespace DbEntidades
{
    public class Seguridad
    {
        public static int IdUsuarioActual = 0; //siempre mantiene en static el usuario actual

        public static bool Permiso(string permiso)
        {
            return true;
        }
    }
}