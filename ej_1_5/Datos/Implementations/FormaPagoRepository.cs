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
    internal class FormaPagoRepository : IFormaPago
    {
        public List<FormaPago> GetAll()
        {
            //Crear una lista de formas de pago
            List<FormaPago> formasPago = new List<FormaPago>();

            //Crear sp
            string sp = "SP_MOSTRAR_FORMAS_PAGO";

            //obtener la datatable de la cual fabricar la lista
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery(sp, null);

            //mapear la datatable a la lista
            foreach (DataRow r in dt.Rows)
            {
                FormaPago formaPago = new FormaPago
                {
                    IdFormaPago = Convert.ToInt32(r["Id_Forma_Pago"]),
                    Descripcion = r["detalle"].ToString()
                };
                formasPago.Add(formaPago);
            }

            //devolver la lista
            return formasPago;
        }

        public FormaPago GetFormaPagoById(int id)
        {
            //Crear una forma de pago
            FormaPago formaPago = new FormaPago();

            //Crear sp
            string sp = "SP_MOSTRAR_FORMAS_PAGO_POR_ID";

            //Crear parametros
            List<ParameterSQL> parameters = new List<ParameterSQL>
            {
                new ParameterSQL("@Id_FormaPago", id)
            };

            //obtener la datatable de la cual fabricar la lista
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery(sp, parameters);

            //mapear la datatable a la lista
            foreach (DataRow r in dt.Rows)
            {
                formaPago.IdFormaPago = Convert.ToInt32(r["Id_Forma_Pago"]);
                formaPago.Descripcion = r["detalle"].ToString();
            }

            //devolver la lista
            return formaPago;
        }
    }
}
