using ej_1_5.Datos.Contracts;
using ej_1_5.Datos.Implementations;
using ej_1_5.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_1_5.Servicios
{
    internal class FacturaManager
    {
        private IArticulo _articulo;
        private IFormaPago _formaPago;
        private IFactura _factura;

        public FacturaManager()
        {
            _articulo = new ArticuloRepository();
            _formaPago = new FormaPagoRepository();
            _factura = new FacturaRepository();
        }

        public List<Articulo> GetAllArticulos()
        {
            return _articulo.GetAll();
        }
        public List<FormaPago> GetAllFormasPago()
        {
            return _formaPago.GetAll();
        }
        public List<Factura> GetAllFacturas()
        {
            return _factura.GetAll();
        }
        public bool SaveFactura(Factura factura)
        {
            return _factura.SaveFactura(factura);
        }
    }
}
