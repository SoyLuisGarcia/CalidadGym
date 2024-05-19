using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class SuplementosServicio : ISuplementos
    {
        public Task<bool> GuardarSuplementos(Suplementos suplementos)
        {
            bool resultado = false;
            
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from s in conexion.Suplementos where s.SuplementoID == suplementos.SuplementoID select s).FirstOrDefault();

                if (consulta == null)
                {
                    Suplementos s = new Suplementos();
                    s.SuplementoID = suplementos.SuplementoID;
                    s.Nombre = suplementos.Nombre;
                    s.Descripcion = suplementos.Descripcion;
                    s.Precio = suplementos.Precio;
                    s.Stock = suplementos.SuplementoID;
                    conexion.Suplementos.Add(s);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarSuplementos(Suplementos suplementos)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from s in conexion.Suplementos where s.SuplementoID == suplementos.SuplementoID select s)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Suplementos.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarSuplementos(Suplementos suplementos)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from s in conexion.Suplementos where s.SuplementoID == suplementos.SuplementoID select s).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.SuplementoID = suplementos.SuplementoID;
                    consulta.Nombre = suplementos.Nombre;
                    consulta.Descripcion = suplementos.Descripcion;
                    consulta.Precio = suplementos.Precio;
                    consulta.Stock = suplementos.Stock;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Suplementos>> ListarSuplementos()
        {
            List<Suplementos> listaSuplementos = new List<Suplementos>();
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from c in conexion.Suplementos select c).ToList();

                foreach (var s in consulta)
                {
                    listaSuplementos.Add(new Suplementos()
                    {
                        SuplementoID = s.SuplementoID,
                        Nombre = s.Nombre,
                        Descripcion = s.Descripcion,
                        Precio = s.Precio,
                        Stock = s.Stock
                    });
                }

                return Task.FromResult(listaSuplementos);

            }
        }

    }
}