using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class ClienteServicio : ICliente
    {
        public Task<bool> GuardarCliente(Cliente cliente)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from c in conexion.Cliente where c.ClienteID == cliente.ClienteID select c).FirstOrDefault();

                if (consulta == null)
                {
                    Cliente c = new Cliente();
                    c.ClienteID = cliente.ClienteID;
                    c.Nombre = cliente.Nombre;
                    c.Apellido = cliente.Apellido;
                    c.Edad = cliente.Edad;
                    c.Email = cliente.Email;
                    c.Telefono = cliente.Telefono;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarCliente(Cliente cliente)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from c in conexion.Cliente where c.ClienteID == cliente.ClienteID select c).FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Cliente.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);        
        }

        public Task<bool> ActualizarCliente(Cliente cliente)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (
                    from c in conexion.Cliente
                    where c.ClienteID == cliente.ClienteID
                    select c
                ).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.ClienteID = cliente.ClienteID;
                    consulta.Nombre = cliente.Nombre;
                    consulta.Apellido = cliente.Apellido;
                    consulta.Edad = cliente.Edad;
                    consulta.Email = cliente.Email;
                    consulta.Telefono = cliente.Telefono;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);        
        }

        public Task<List<Cliente>> ListarCliente()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from c in conexion.Cliente select c).ToList();

                foreach (var c in consulta)
                {
                    listaClientes.Add(new Cliente()
                    {
                        ClienteID = c.ClienteID,
                        Nombre = c.Nombre,
                        Apellido = c.Apellido,
                        Edad = c.Edad,
                        Email = c.Email,
                        Telefono = c.Telefono
                    });
                }
            
                return Task.FromResult(listaClientes);
            }        
        }
    }    
}
