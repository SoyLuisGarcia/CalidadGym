namespace CORE.Interfaces
{
    public interface IEmpleado
    {
        Task<bool> GuardarEmplado(MODELS.Empleado empleado);
        Task<bool> EliminarEmpleado(MODELS.Empleado empleado);
        Task<bool> ActualizarEmpleado(MODELS.Empleado empleado);
        Task<List<MODELS.Empleado>> ListarEmpleados();
    }    
}

