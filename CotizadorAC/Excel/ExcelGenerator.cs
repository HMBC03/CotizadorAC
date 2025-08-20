namespace CotizadorAC.Excel
{
    using OfficeOpenXml;
    using CotizadorAC.Models;
    using System.Collections.Generic;

    public static class ExcelGenerator
    {
        public static byte[] GenerarExcel(List<CotizacionEntity> cotizaciones)
        {
            // EPPlus 8+ requiere establecer el contexto de licencia a nivel global, no por instancia.
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("Cotizaciones");

            // Encabezados
            worksheet.Cells[1, 1].Value = "Nombre";
            worksheet.Cells[1, 2].Value = "Tipo Seguro";
            worksheet.Cells[1, 3].Value = "Valor Asegurado";
            worksheet.Cells[1, 4].Value = "Edad";
            worksheet.Cells[1, 5].Value = "Ciudad";
            worksheet.Cells[1, 6].Value = "Prima";
            worksheet.Cells[1, 7].Value = "Fecha Generación";

            // Cargar los datos
            for (int i = 0; i < cotizaciones.Count; i++)
            {
                var cotizacion = cotizaciones[i];
                worksheet.Cells[i + 2, 1].Value = cotizacion.Nombre;
                worksheet.Cells[i + 2, 2].Value = cotizacion.TipoSeguro;
                worksheet.Cells[i + 2, 3].Value = cotizacion.ValorAsegurado;
                worksheet.Cells[i + 2, 4].Value = cotizacion.Edad;
                worksheet.Cells[i + 2, 5].Value = cotizacion.Ciudad;
                worksheet.Cells[i + 2, 6].Value = cotizacion.Prima;
                worksheet.Cells[i + 2, 7].Value = cotizacion.FechaGeneracion.ToString("yyyy-MM-dd");
            }

            // Ajustar ancho de columnas automáticamente
            worksheet.Cells.AutoFitColumns();

            // Retornar como array de bytes
            return package.GetAsByteArray();
        }
    }
}
