namespace ApiMascotas.Entidades
{
    public class DatosFiltroCliente: Cliente
    {
        public int NumeroPagina { get; set; }
        public int CantidadRegistros { get; set; }
        public string ColumnaOrdenamiento { get; set; }
        public string TipoOrdenamiento { get; set; }
    }
}
