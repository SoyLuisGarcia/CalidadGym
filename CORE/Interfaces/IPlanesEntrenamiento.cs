namespace CORE.Interfaces
{
    public interface IPlanesEntrenamiento
    {
        Task<bool> GuardarPlan(MODELS.PlanesEntrenamiento planes);
        Task<bool> EliminarPlan(MODELS.PlanesEntrenamiento planes);
        Task<bool> ActualizarPlan(MODELS.Empleado plan);
        Task<List<MODELS.Empleado>> ListarPlanes();
    }
}