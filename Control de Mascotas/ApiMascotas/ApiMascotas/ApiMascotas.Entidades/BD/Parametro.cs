using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMascotas.Entidades.BD
{
    public class Parametro
    {
        private string llave;
        private SqlParameter parametroSQL;

        // Constructor del parámetro cuando es texto.
        public Parametro(string llave, string parametro)
        {
            this.llave = llave;
            parametroSQL = new SqlParameter("@" + llave, parametro);
        }

        // Constructor del parámetro cuando es número.
        public Parametro(string llave, int parametro)
        {
            this.llave = llave;
            parametroSQL = new SqlParameter("@" + llave, parametro);
        }

        // Constructor del parámetro cuando es número largo.
        public Parametro(string llave, long parametro)
        {
            this.llave = llave;
            parametroSQL = new SqlParameter("@" + llave, parametro);
        }

        // Constructor del parámetro cuando es número decimal.
        public Parametro(string llave, decimal parametro)
        {
            this.llave = llave;
            parametroSQL = new SqlParameter("@" + llave, parametro);
        }

        // Constructor del parámetro cuando es número flotante.
        public Parametro(string llave, float parametro)
        {
            this.llave = llave;
            parametroSQL = new SqlParameter("@" + llave, parametro);
        }

        // Constructor del parámetro cuando es booleano.
        public Parametro(string llave, bool parametro)
        {
            this.llave = llave;
            parametroSQL = new SqlParameter("@" + llave, parametro);
        }

        // Constructor del parámetro cuando es fecha.
        public Parametro(string llave, DateTime parametro)
        {
            this.llave = llave;
            parametroSQL = new SqlParameter("@" + llave, parametro);
        }

        // Constructor del parámetro cuando es carácter.
        public Parametro(string llave, char parametro)
        {
            this.llave = llave;
            parametroSQL = new SqlParameter("@" + llave, parametro);
        }

        public SqlParameter ObtenerParametro()
        {
            if (this.parametroSQL.Value == null)
                this.parametroSQL.Value = DBNull.Value;

            return parametroSQL;
        }
    }
}
