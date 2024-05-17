using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class MembresiasServicio : IMembresias
    {
        public Task<bool> GuardarMembresia(Membresias membresia)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from m in conexion.Membresias where m.MembresiaID == membresia.MembresiaID select m)
                    .FirstOrDefault();

                if (consulta == null)
                {
                    Membresias m = new Membresias();
                    m.MembresiaID = membresia.MembresiaID;
                    m.ClientID = membresia.ClientID;
                    m.PlanID = membresia.PlanID;
                    m.EmpleadoID = membresia.EmpleadoID;
                    m.FechaInicio = membresia.FechaInicio;
                    m.FechaFin = membresia.FechaFin;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarMembresia(Membresias membresia)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from m in conexion.Membresias where m.MembresiaID == membresia.MembresiaID select m)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Membresias.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarMembresia(Membresias membresia)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from m in conexion.Membresias where m.MembresiaID == membresia.MembresiaID select m)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    consulta.MembresiaID = membresia.MembresiaID;
                    consulta.ClientID = membresia.ClientID;
                    consulta.PlanID = membresia.PlanID;
                    consulta.EmpleadoID = membresia.EmpleadoID;
                    consulta.FechaInicio = membresia.FechaInicio;
                    consulta.FechaInicio = membresia.FechaFin;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Membresias>> ListarMembresia()
        {
            List<Membresias> listaMembresias = new List<Membresias>();
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from m in conexion.Membresias select m).ToList();

                foreach (var m in consulta)
                {
                    listaMembresias.Add(new Membresias()
                    {
                        MembresiaID = m.MembresiaID,
                        ClientID = m.ClientID,
                        PlanID = m.PlanID,
                        EmpleadoID = m.EmpleadoID,
                        FechaInicio = m.FechaInicio,
                        FechaFin = m.FechaFin
                    });
                }

                return Task.FromResult(listaMembresias);

            }
        }

    }
}