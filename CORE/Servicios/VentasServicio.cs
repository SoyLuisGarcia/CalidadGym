using CORE.Interfaces;
using MODELS;

namespace CORE.Servicios
{
    public class VentasServicio : IVentas
    {
        public Task<bool> GuardarVentas(Ventas ventas)
        {
            bool resultado = false;
            
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from v in conexion.Ventas where v.VentaID == ventas.VentaID select v).FirstOrDefault();

                if (consulta == null)
                {
                    Ventas v = new Ventas();
                    v.VentaID = ventas.VentaID;
                    v.ClienteID = ventas.ClienteID;
                    v.SuplementoID = ventas.SuplementoID;
                    v.Cantidad = ventas.Cantidad;
                    v.FechaVenta = ventas.FechaVenta;
                    v.Total = ventas.Total;
                    conexion.Ventas.Add(v);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarVentas(Ventas ventas)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from v in conexion.Ventas where v.VentaID == ventas.VentaID select v)
                    .FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Ventas.Remove(consulta);
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);

        }

        public Task<bool> ActualizarVentas(Ventas ventas)
        {
            bool resultado = false;
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from v in conexion.Ventas where v.VentaID == ventas.VentaID select v).FirstOrDefault();

                if (consulta != null)
                {
                    consulta.VentaID = ventas.VentaID;
                    consulta.ClienteID = ventas.ClienteID;
                    consulta.SuplementoID = ventas.SuplementoID;
                    consulta.Cantidad = ventas.Cantidad;
                    consulta.FechaVenta = ventas.FechaVenta;
                    consulta.Total = ventas.Total;
                    resultado = conexion.SaveChanges() > 0;
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<List<Ventas>> ListarVentas()
        {
            List<Ventas> listaVentas = new List<Ventas>();
            using (var conexion = new DATA.DataContext.DatabaseContext())
            {
                var consulta = (from c in conexion.Ventas select c).ToList();

                foreach (var v in consulta)
                {
                    listaVentas.Add(new Ventas()
                    {
                        VentaID = v.VentaID,
                        ClienteID = v.ClienteID,
                        SuplementoID = v.SuplementoID,
                        Cantidad = v.Cantidad,
                        FechaVenta = v.FechaVenta,
                        Total = v.Total
                    });
                }

                return Task.FromResult(listaVentas);

            }
        }

    }
}