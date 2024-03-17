namespace MascotasWeb.Servicios
{
    public static class Rutas
    {
        // Rutas iniciales
        public static string RutaPrincipal = "Home/IniciarSesion";
        public static string RutaSolicitarAcceso = "Home/SolicitarAcceso";

        // Clientes
        public static string ObtenerClientes = "Cliente/ObtenerClientes";
        public static string ObtenerCliente = "Cliente/Obtener";
        public static string ObtenerClientesTotales = "Cliente/ObtenerTotal";
        public static string AgregarCliente = "Cliente/Agregar";
        public static string EditarCliente = "Cliente/Editar";
        public static string EliminarCliente = "Cliente/Eliminar";

        // Generales
        public static string ObtenerSexos = "General/ObtenerSexos";
        public static string ObtenerProvincias = "General/ObtenerProvincias";
        public static string ObtenerCantones = "General/ObtenerCantones";
        public static string ObtenerDistritos = "General/ObtenerDistritos";
        public static string ValidarCedula = "General/ValidarCedula";
    }
}
