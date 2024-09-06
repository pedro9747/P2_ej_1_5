using ej_1_5.Datos.Contracts;
using ej_1_5.Dominio;
using ej_1_5.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_1_5.Datos.Implementations
{
    internal class ArticuloRepository : IArticulo
    {

        public List<Articulo> GetAll()
        {
            //lista de salida
            List<Articulo> lista = new List<Articulo>();
            //crear peticion
            string sp = "SP_MOSTRAR_ARTICULOS";

            //traer tabla
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery(sp, null);
            //mapear a lista
            foreach(DataRow r in dt.Rows)
            {
                Articulo oArticulo = new Articulo
                {
                    IdArticulo = Convert.ToInt32(r["Id_Articulo"]),
                    Nombre = r["detalle"].ToString(),
                    Precio = Convert.ToDouble(r["Precio_unitario"])
                };
                lista.Add(oArticulo);
            }
            return lista;
        }
        public Articulo GetArticuloById(int id)
        {
            string sp = "SP_MOSTRAR_ARTICULO_POR_ID";
            List<ParameterSQL> parameters = new List<ParameterSQL>
            {
                new ParameterSQL("@Id_Articulo", id)
            };
            Articulo oArticulo = new Articulo();
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery(sp, parameters);
            foreach(DataRow r in dt.Rows)
            {
                oArticulo.IdArticulo = Convert.ToInt32(r["Id_Articulo"]);
                oArticulo.Nombre = r["detalle"].ToString();
                oArticulo.Precio = Convert.ToDouble(r["Precio_unitario"]);
            }
            return oArticulo;
        }

    }
}
