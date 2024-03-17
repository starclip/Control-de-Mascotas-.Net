namespace ApiMascotas.Entidades
{
    public class Persona: Control
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
