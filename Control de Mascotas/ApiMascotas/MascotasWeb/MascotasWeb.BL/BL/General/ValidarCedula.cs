namespace MascotasWeb.BL
{
    public class ValidarCedula
    {
        public bool Ejecute(string Cedula)
        {
            return new Servicios.ValidarCedula().Ejecute(Cedula);
        }
    }
}
