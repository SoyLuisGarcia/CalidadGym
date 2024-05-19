using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class FacturacionServicio : IFacturacion
    {
        public Task<bool> GuardarFactura(Facturacion facturacion)
        {
            bool resultado = false;
            
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from f in conexion.Facturacion where f.FacturaID == facturacion.FacturaID select f).FirstOrDefault();

                if (consulta == null)
                {
                    Facturacion f = new Facturacion();
                    f.FacturaID = facturacion.FacturaID;
                    f.MembresiaID = facturacion.MembresiaID;
                    f.FechaEmision = facturacion.FechaEmision;
                    f.MontoTotal = facturacion.MontoTotal;
                    f.Estado = facturacion.Estado;
                    conexion.Facturacion.Add(f);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarFactura(Facturacion facturacion)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from f in conexion.Facturacion where f.FacturaID == facturacion.FacturaID select f)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Facturacion.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarFactura(Facturacion facturacion)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from f in conexion.Facturacion where f.FacturaID == facturacion.FacturaID select f).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.FacturaID = facturacion.FacturaID;
                    consulta.MembresiaID = facturacion.MembresiaID;
                    consulta.FechaEmision = facturacion.FechaEmision;
                    consulta.MontoTotal = facturacion.MontoTotal;
                    consulta.Estado = facturacion.Estado;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Facturacion>> ListarFactura()
        {
            List<Facturacion> listaFacturacions = new List<Facturacion>();
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from c in conexion.Facturacion select c).ToList();

                foreach (var f in consulta)
                {
                    listaFacturacions.Add(new Facturacion()
                    {
                        FacturaID = f.FacturaID,
                        MembresiaID = f.MembresiaID,
                        FechaEmision = f.FechaEmision,
                        MontoTotal = f.MontoTotal,
                        Estado = f.Estado
                    });
                }

                return Task.FromResult(listaFacturacions);

            }
        }

    }
}