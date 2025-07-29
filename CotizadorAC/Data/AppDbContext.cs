namespace CotizadorAC.Data
{
    // Importar los espacios de nombres necesarios
    using Microsoft.EntityFrameworkCore;
    using CotizadorAC.Models;
    // Definición del contexto de la base de datos para la aplicación CotizadorAC
    public class AppDbContext : DbContext
    {
        // Constructor que recibe las opciones de configuración del contexto de la base de datos

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // Definición del DbSet para la entidad CotizacionEntity 
        public DbSet<CotizacionEntity> Cotizaciones { get; set; }
    }
}
