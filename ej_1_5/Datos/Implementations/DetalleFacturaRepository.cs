using ej_1_5.Datos.Contracts;
using ej_1_5.Dominio;
using ej_1_5.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_1_5.Datos.Implementations
{
    internal class DetalleFacturaRepository : IDetalleFactura
    {
        private ArticuloRepository articuloRepository = new ArticuloRepository();
        public List<DetalleFactura> GetAll()
        {
            string sp = "SP_MOSTRAR_DETALLES_FACTURA";
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery(sp, null);
            List<DetalleFactura> lista = ReadDataTable(dt);
            return lista;
        }

        public List<DetalleFactura> GetByIdFactura(int idFactura)
        {
            string sp = "SP_MOSTRAR_DETALLES_FACTURA_POR_ID_FACTURA";
            List<ParameterSQL> parameters = new List<ParameterSQL>
            {
                new ParameterSQL("@Id_Factura", idFactura)
            };
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery(sp, parameters);
            List<DetalleFactura> lista = ReadDataTable(dt);

            return lista;
        }
        private List<DetalleFactura> ReadDataTable(DataTable dt)
        {
            List<DetalleFactura> lista = new List<DetalleFactura>();
                       
            foreach (DataRow r in dt.Rows)
            {
                DetalleFactura detalle = new DetalleFactura
                {
                    IdDetalle = Convert.ToInt32(r["id_detalle_factura"]),
                    IdFactura = Convert.ToInt32(r["nro_factura"]),
                    Articulo = articuloRepository.GetArticuloById(Convert.ToInt32(r["Id_Articulo"])),
                    Cantidad = Convert.ToInt32(r["Cantidad"])
                };
                lista.Add(detalle);
            }
            return lista;
        }

        public bool SaveDetalleFactura(DetalleFactura detalle)
        {
            throw new NotImplementedException();
        }
    }
}
