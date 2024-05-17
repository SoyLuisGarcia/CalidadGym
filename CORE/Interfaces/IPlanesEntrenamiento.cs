namespace CORE.Interfaces
{
    public interface IPlanesEntrenamiento
    {
        Task<bool> GuardarPlan(MODELS.PlanesEntrenamiento planesEntrenamiento);
        Task<bool> EliminarPlan(MODELS.PlanesEntrenamiento planesEntrenamiento);
        Task<bool> ActualizarPlan(MODELS.PlanesEntrenamiento planesEntrenamiento);
        Task<List<MODELS.PlanesEntrenamiento>> ListarPlanes();
    }
}