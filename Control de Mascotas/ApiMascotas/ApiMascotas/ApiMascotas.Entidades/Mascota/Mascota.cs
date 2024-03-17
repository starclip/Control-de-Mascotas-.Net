namespace ApiMascotas.Entidades
{
    public class Mascota: Control
    {
        public string Nombre { get; set; }
        public string Animal { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Dueno { get; set; }
        public string UltimaCita { get; set; }
    }
}
