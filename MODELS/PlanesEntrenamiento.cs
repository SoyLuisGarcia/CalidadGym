using System.ComponentModel.DataAnnotations;

namespace MODELS
{
    public class PlanesEntrenamiento
    {
        [Key]
        public int PlanID { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public int DuracionMeses { get; set; }
        public double Precio { get; set; }
    }    
}

