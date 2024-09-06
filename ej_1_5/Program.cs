using ej_1_5.Dominio;
using ej_1_5.Servicios;

//creo manager
FacturaManager facturaManager = new FacturaManager();
//listar articulos
List<Articulo> ListaArticulos = facturaManager.GetAllArticulos();
foreach(Articulo articulo in ListaArticulos)
{
    Console.WriteLine(articulo);
}
//listar formas de pago
List<FormaPago> ListaFormaPago = facturaManager.GetAllFormasPago();
foreach(FormaPago formaPago in ListaFormaPago)
{
    Console.WriteLine(formaPago);
}
//listar facturas
List<Factura> ListaFacturas = facturaManager.GetAllFacturas();
foreach(Factura factura in ListaFacturas)
{
    Console.WriteLine(factura);
}
//Nueva Factura
Factura facturaNueva = new Factura
{
    Fecha = DateTime.Now,
    FormaDePago = ListaFormaPago[0],
    Cliente = "Ruben Ramirez",
    DetalleDeFacturas = new List<DetalleFactura>
    {
        new DetalleFactura
        {
            Articulo = ListaArticulos[2],
            Cantidad = 2
        },
        new DetalleFactura
        {
            Articulo = ListaArticulos[3],
            Cantidad = 1
        },
        new DetalleFactura
        {
            Articulo = ListaArticulos[1],
            Cantidad = 5
        }
    }
};
//Guardar Factura
if (facturaManager.SaveFactura(facturaNueva))
{
    Console.WriteLine("Factura Guardada");
}
else
{
    Console.WriteLine("Error al guardar factura");
}
//listar facturas con la nueva
ListaFacturas = facturaManager.GetAllFacturas();
foreach (Factura factura in ListaFacturas)
{
    Console.WriteLine(factura);
}