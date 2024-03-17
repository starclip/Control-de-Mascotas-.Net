namespace ApiMascotas.Entidades
{
    public abstract class Control
    {
        public long Id { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public long IdUsuarioModificacion { get; set; }
        public string Cambios { get; set; }
    }
}
