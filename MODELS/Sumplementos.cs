using System.ComponentModel.DataAnnotations;

namespace MODELS;

public class Sumplementos
{
    [Key]
    public int SuplementoID { get; set; }
    public String Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}