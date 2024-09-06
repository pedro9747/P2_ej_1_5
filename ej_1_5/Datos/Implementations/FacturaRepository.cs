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
    internal class FacturaRepository : IFactura
    {

        public List<Factura> GetAll()
        {
            //crear variable de retorno
            List<Factura> lista = new List<Factura>();

            //Crear sp
            string sp = "SP_MOSTRAR_FACTURAS";

            //Obtener datatable
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery(sp, null);

            //Mapear datatable a lista con ayuda de otros repos
            FormaPagoRepository formaPagoRepository = new FormaPagoRepository();
            DetalleFacturaRepository detalleFacturaRepository = new DetalleFacturaRepository();

            foreach (DataRow r in dt.Rows)
            {
                Factura oFactura = new Factura();
                oFactura.IdFactura = Convert.ToInt32(r["nro_Factura"]);
                oFactura.Fecha = Convert.ToDateTime(r["Fecha"]);
                //Traigo la forma de pago como objeto usando su repo
                oFactura.FormaDePago = formaPagoRepository.GetFormaPagoById(Convert.ToInt32(r["id_forma_pago"]));
                oFactura.Cliente = (r["cliente"]).ToString();
                //traigo la lista de detalles de factura usando su repo
                oFactura.DetalleDeFacturas = detalleFacturaRepository.GetByIdFactura(Convert.ToInt32(r["nro_Factura"]));
                lista.Add(oFactura);
            }

            //devolver variable de retorno
            return lista;
        }

        public Factura GetFacturaById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveFactura(Factura factura)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;
            string sp = "SP_NUEVA_FACTURA";
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sp, cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@Id_Forma_Pago", factura.FormaDePago.IdFormaPago);
                cmd.Parameters.AddWithValue("@Cliente", factura.Cliente);

                SqlParameter param = new SqlParameter("@Id_Factura", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int idFactura = Convert.ToInt32(param.Value);

                int nDetalle = 1;
                foreach (DetalleFactura detalle in factura.DetalleDeFacturas)
                {
                    sp = "SP_NUEVO_DETALLE_FACTURA";
                    cmd = new SqlCommand(sp, cnn, t);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nro_factura", idFactura);
                    cmd.Parameters.AddWithValue("@Id_Articulo", detalle.Articulo.IdArticulo);
                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmd.Parameters.AddWithValue("@Nro_Detalle", nDetalle);
                    cmd.ExecuteNonQuery();
                    nDetalle++;
                }
                t.Commit();
            }
            catch (SqlException ex)
            {
                t.Rollback();
                result = false;
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

            return result;
        }
    }
}
