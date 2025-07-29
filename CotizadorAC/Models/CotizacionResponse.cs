namespace CotizadorAC.Models
{
    // Construir el modelo de la respuesta de cotización se almacena en la base de datos
    public class CotizacionResponse
    {
        public string Nombre { get; set; }
        public string TipoSeguro { get; set; }
        public float ValorAsegurado { get; set; }
        public int Edad { get; set; }
        public string ciudad { get; set; }
        public decimal Prima { get; set; }
        public DateTime FechaGeneracion { get; set; }

    }
}
