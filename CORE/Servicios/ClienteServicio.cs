using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class ClienteServicio : ICliente
    {
        public Task<bool> GuardarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<Empleado>> ListarCliente()
        {
            throw new NotImplementedException();
        }
    }    
}
