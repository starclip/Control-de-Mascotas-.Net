using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMascotas.BL
{
    public static class TextoRespuesta
    {
        public static string ListaObtenida { get { return "Lista Obtenida";  } }
        public static string TotalRegistros { get { return "Total de registros obtenidos de la lista";  } }
        public static string EstadoObtenido { get { return "Estado";  } }
        public static string InsercionRegistro { get { return "Se agregó el nuevo registro al catálogo";  } }
        public static string ActualizacionRegistro { get { return "Se actualizó el registro";  } }
        public static string ObtenerRegistro { get { return "Se obtiene un único registro";  } }
        public static string EliminarRegistro { get { return "Se elimina el cliente seleccionado";  } }
    }
}
