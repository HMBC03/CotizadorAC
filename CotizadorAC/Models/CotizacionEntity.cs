namespace CotizadorAC.Models
{
    public class CotizacionEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoSeguro { get; set; }
        public decimal ValorAsegurado { get; set; }
        public int Edad { get; set; }
        public string Ciudad { get; set; }
        public decimal Prima { get; set; }
        public DateTime FechaGeneracion { get; set; }
        /* Constructor para inicializar la fecha de generación
        public CotizacionEntity()
        {
            FechaGeneracion = DateTime.Now;
        }*/

    }
}
