namespace CotizadorAC.Models
{
    // Construir el modelo de la respuesta de cotización se almacena en la base de datos
    public class CotizacionResponse
    {
        public string Nombre { get; set; }
        public string TipoSeguro { get; set; }
        public decimal ValorAsegurado { get; set; }
        public int Edad { get; set; }
        public string Ciudad { get; set; }
        public decimal Prima { get; set; }
        public DateTime FechaGeneracion { get; set; }

    }
}
