namespace CORE.Interfaces
{
    public interface IMembresias
    {
        Task<bool> GuardarMembresia(MODELS.Membresias membresias);
        Task<bool> EliminarMembresia(MODELS.Membresias membresias);
        Task<bool> ActualizarMembresia(MODELS.Membresias membresias);
        Task<List<MODELS.Empleado>> ListarMembresia();
    }
}