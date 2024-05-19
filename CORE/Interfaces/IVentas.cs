namespace CORE.Interfaces;

public interface IVentas
{
    Task<bool> GuardarVentas(MODELS.Ventas ventas);
    Task<bool> EliminarVentas(MODELS.Ventas ventas);
    Task<bool> ActualizarVentas(MODELS.Ventas ventas);
    Task<List<MODELS.Ventas>> ListarVentas();
}