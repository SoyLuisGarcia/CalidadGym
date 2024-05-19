using System.ComponentModel.DataAnnotations;

namespace MODELS;

public class Facturacion
{
    [Key] 
    public int FacturaID { get; set; }
    public int MembresiaID { get; set; }
    public DateOnly FechaEmision { get; set; }
    public decimal MontoTotal { get; set; }
    public String Estado { get; set; }
}