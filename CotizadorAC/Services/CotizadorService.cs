using CotizadorAC.Models;
using OfficeOpenXml.Packaging.Ionic.Zlib;

namespace CotizadorAC.Services
{
    public class CotizadorService
    {
        public decimal CalcularPrima(CotizacionRequest req)
        {
            decimal factor = 0;
            decimal costoEdad = 0;
            decimal costoZona = 0;

            if (req.TipoSeguro == "VIDA")
            {
                factor = req.Edad < 35 ? 0.01m : (req.Edad < 50 ? 0.02m : 0.03m);
                costoEdad = req.Edad >= 60 ? 20000 : 0; // Costo adicional si la edad es mayor o igual a 60
            }
            else if (req.TipoSeguro == "VEHICULO")
            {
                factor = req.ciudad switch
                {
                    "Bogotá" => 0.05m, 
                    "Ciudad2" => 0.04m,
                    "Ciudad3" => 0.035m,
                    _ => 0.03m 
                };
                costoEdad = req.Edad < 25 ? 50000 : 0; // Costo adicional si la edad es menor a 25
            }
            else if (req.TipoSeguro == "SALUD")
            {
                factor = req.Edad < 18 ? 0.015m : (req.Edad < 60 ? 0.02m : 0.03m);
                costoEdad = req.Edad >= 60 ? 25000 : 0; // Costo adicional si la edad es mayor o igual a 60
            }
            return (req.ValorAsegurado * factor) + costoEdad + costoZona; // Retornar el calculo de la prima total
        }
    }
}
