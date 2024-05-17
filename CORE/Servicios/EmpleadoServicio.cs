using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class EmpleadoServicio : IEmpleado
    {
        public Task<bool> GuardarEmplado(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarEmpleado(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarEmpleado(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public Task<List<Empleado>> ListarEmpleados()
        {
            throw new NotImplementedException();
        }
    }
}