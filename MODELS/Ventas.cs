using System.ComponentModel.DataAnnotations;

namespace MODELS;

public class Ventas
{
    [Key]
    public int VentaID { get; set; }
    public int ClienteID { get; set; }
    public int SuplementoID { get; set; }
    public int Cantidad { get; set; }
    public DateOnly FechaVenta { get; set; }
    public decimal Total { get; set; }
    
}