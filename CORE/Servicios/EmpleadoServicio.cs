using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class EmpleadoServicio : IEmpleado
    {
        public Task<bool> GuardarEmpleado(Empleado empleado)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from e in conexion.Empleado where e.EmpleadoID == empleado.EmpleadoID select e)
                    .FirstOrDefault();

                if (consulta == null)
                {
                    Empleado e = new Empleado();
                    e.EmpleadoID = empleado.EmpleadoID;
                    e.Nombre = empleado.Nombre;
                    e.Apellido = empleado.Apellido;
                    e.Posicion = empleado.Posicion;
                    e.Email = empleado.Email;
                    e.Telefono = empleado.Telefono;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarEmpleado(Empleado empleado)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from e in conexion.Empleado where e.EmpleadoID == empleado.EmpleadoID select e)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Empleado.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarEmpleado(Empleado empleado)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from e in conexion.Empleado where e.EmpleadoID == empleado.EmpleadoID select e)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    consulta.EmpleadoID = empleado.EmpleadoID;
                    consulta.Nombre = empleado.Nombre;
                    consulta.Apellido = empleado.Apellido;
                    consulta.Posicion = empleado.Posicion;
                    consulta.Email = empleado.Email;
                    consulta.Telefono = empleado.Telefono;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Empleado>> ListarEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from c in conexion.Empleado select c).ToList();

                foreach (var e in consulta)
                {
                    listaEmpleados.Add(new Empleado()
                    {
                        EmpleadoID = e.EmpleadoID,
                        Nombre = e.Nombre,
                        Apellido = e.Apellido,
                        Posicion = e.Posicion,
                        Email = e.Email,
                        Telefono = e.Telefono
                    });
                }

                return Task.FromResult(listaEmpleados);

            }
        }

    }
}