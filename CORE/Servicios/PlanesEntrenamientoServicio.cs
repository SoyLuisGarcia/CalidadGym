using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class PlanesEntrenamientoServicio : IPlanesEntrenamiento
    {
        public Task<bool> GuardarPlan(PlanesEntrenamiento planes)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarPlan(PlanesEntrenamiento planes)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarPlan(Empleado plan)
        {
            throw new NotImplementedException();
        }

        public Task<List<Empleado>> ListarPlanes()
        {
            throw new NotImplementedException();
        }
    }
}