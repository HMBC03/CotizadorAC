namespace CotizadorAC.Models
{
    //Construir el modelo de la solicitud de cotización
    public class CotizacionRequest
    { 
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string TipoSeguro { get; set; }

        public decimal ValorAsegurado { get; set; }
        public string ciudad { get; set; }


    }
}
