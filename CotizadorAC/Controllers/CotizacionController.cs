namespace CotizadorAC.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using CotizadorAC.Services;
    using CotizadorAC.Models;
    using CotizadorAC.Data;

    [ApiController]
    [Route("api/[controller]")]

    public class CotizacionController : ControllerBase
    {
        private readonly CotizadorService _cotizadorService;
        private readonly AppDbContext _context;
        public CotizacionController(CotizadorService cotizadorService, AppDbContext context)
        {
            _cotizadorService = cotizadorService;
            _context = context;
        }
        [HttpPost("cotizar")]
        public async Task<IActionResult> Cotizar([FromBody] CotizacionRequest request)

        {
            if (request == null || string.IsNullOrEmpty(request.Nombre) || request.Edad <= 0 || string.IsNullOrEmpty(request.TipoSeguro) || request.ValorAsegurado <= 0)
            {
                return BadRequest("Datos de cotización inválidos.");
            }
            var prima = _cotizadorService.CalcularPrima(request);
            var entity = new CotizacionEntity
            {
                Nombre = request.Nombre,
                TipoSeguro = request.TipoSeguro,
                ValorAsegurado = request.ValorAsegurado,
                Edad = request.Edad,
                Ciudad = request.ciudad,
                Prima = prima,
                FechaGeneracion = DateTime.Now
            };

            _context.Cotizaciones.Add(entity);
            await _context.SaveChangesAsync();

            return Ok(new CotizacionResponse
            {
                Nombre = entity.Nombre,
                TipoSeguro = entity.TipoSeguro,
                ValorAsegurado = entity.ValorAsegurado,
                Edad = entity.Edad,
                Ciudad = entity.Ciudad,
                Prima = entity.Prima,
                FechaGeneracion = entity.FechaGeneracion
            });

        }
        [HttpPost("excel")]
        public IActionResult DescargarEXcel()
        {
            var cotizaciones = _context.Cotizaciones.ToList();
            var excel = Excel.ExcelGenerator.GenerarExcel(cotizaciones);
            return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cotizaciones.xlsx");



        }
    


    }
}
