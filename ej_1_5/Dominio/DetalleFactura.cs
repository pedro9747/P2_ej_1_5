using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_1_5.Dominio
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }//FK
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }

        public override string ToString()
        {
            return "\t" + " " + Articulo + " " + Cantidad;
        }

    }
}
