using ej_1_5.Datos.Contracts;
using ej_1_5.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_1_5.Dominio
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public override string ToString()
        {
            return Nombre +" $"+ Precio; 
        }
    }
}
