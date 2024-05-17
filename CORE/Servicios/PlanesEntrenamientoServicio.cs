using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class PlanesEntrenamientoServicio : IPlanesEntrenamiento
    {
        public Task<bool> GuardarPlan(PlanesEntrenamiento planesEntrenamiento)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from p in conexion.PlanesEntrenamiento where p.PlanID == planesEntrenamiento.PlanID select p).FirstOrDefault();

                if (consulta == null)
                {
                    PlanesEntrenamiento p = new PlanesEntrenamiento();
                    p.PlanID = planesEntrenamiento.PlanID;
                    p.Nombre = planesEntrenamiento.Nombre;
                    p.Descripcion = planesEntrenamiento.Descripcion;
                    p.DuracionMeses = planesEntrenamiento.DuracionMeses;
                    p.Precio = planesEntrenamiento.Precio;
                    conexion.PlanesEntrenamiento.Add(p);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarPlan(PlanesEntrenamiento planesEntrenamiento)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from p in conexion.PlanesEntrenamiento where p.PlanID == planesEntrenamiento.PlanID select p)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.PlanesEntrenamiento.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarPlan(PlanesEntrenamiento planesEntrenamiento)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from p in conexion.PlanesEntrenamiento where p.PlanID == planesEntrenamiento.PlanID select p)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    consulta.PlanID = planesEntrenamiento.PlanID;
                    consulta.Nombre = planesEntrenamiento.Nombre;
                    consulta.Descripcion = planesEntrenamiento.Descripcion;
                    consulta.DuracionMeses = planesEntrenamiento.DuracionMeses;
                    consulta.Precio = planesEntrenamiento.Precio;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<PlanesEntrenamiento>> ListarPlanes()
        {
            List<PlanesEntrenamiento> listaPlanes = new List<PlanesEntrenamiento>();
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from p in conexion.PlanesEntrenamiento select p).ToList();

                foreach (var p in consulta)
                {
                    listaPlanes.Add(new PlanesEntrenamiento()
                    {
                        PlanID = p.PlanID,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        DuracionMeses = p.DuracionMeses,
                        Precio = p.Precio
                    });
                }

                return Task.FromResult(listaPlanes);

            }
        }

    }
}