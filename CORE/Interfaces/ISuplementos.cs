namespace CORE.Interfaces;

public interface ISuplementos
{
    Task<bool> GuardarSuplementos(MODELS.Suplementos suplementos);
    Task<bool> EliminarSuplementos(MODELS.Suplementos suplementos);
    Task<bool> ActualizarSuplementos(MODELS.Suplementos suplementos);
    Task<List<MODELS.Suplementos>> ListarSuplementos();
}