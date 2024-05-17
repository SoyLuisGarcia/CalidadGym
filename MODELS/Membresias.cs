namespace MODELS
{
    public class Membresias
    {
        public int MembresiaID { get; set; }
        public int ClientID { get; set; }
        public int PlanID { get; set; }
        public int EmpleadoID { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
    }
}

