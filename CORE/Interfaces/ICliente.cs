namespace CORE.Interfaces
{
    public interface ICliente
    {
        Task<bool> GuardarCliente(MODELS.Cliente cliente);
        Task<bool> EliminarCliente(MODELS.Cliente cliente);
        Task<bool> ActualizarCliente(MODELS.Cliente cliente);
        Task<List<MODELS.Empleado>> ListarCliente();
    }
}