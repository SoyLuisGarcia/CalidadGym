namespace CORE.Interfaces;

public interface IFacturacion
{
    Task<bool> GuardarFactura(MODELS.Facturacion facturacion);
    Task<bool> EliminarFactura(MODELS.Facturacion facturacion);
    Task<bool> ActualizarFactura(MODELS.Facturacion facturacion);
    Task<List<MODELS.Facturacion>> ListarFactura();
}