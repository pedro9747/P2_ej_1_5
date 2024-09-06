using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_1_5.Dominio
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaDePago { get; set; }
        public string Cliente { get; set; }
        public List<DetalleFactura> DetalleDeFacturas { get; set; }
        private string DetallesToString()
        {
            string detalles = "";
            foreach (DetalleFactura detalle in DetalleDeFacturas)
            {
                detalles += detalle.ToString() + "\n";
            }
            return detalles;
        }
        public override string ToString()
        {
            return IdFactura + " " + Fecha + " " + FormaDePago + " " + Cliente + "\n" + DetallesToString();
        }
    }


}
