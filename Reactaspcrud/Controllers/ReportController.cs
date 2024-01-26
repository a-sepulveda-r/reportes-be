using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactaspcrud.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Reactaspcrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportDbContext _reportDbContext;

        public ReportController(ReportDbContext reportDbContext)
        {
            _reportDbContext = reportDbContext;
        }

        [HttpGet]
        [Route("GetReport")]
        public async Task<IActionResult> GetReports()
        {
            try
            {
                var reports = await _reportDbContext.Report.ToListAsync();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al procesar la solicitud. Detalles: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("AddReport")]
        public async Task<IActionResult> AddReport([FromForm] IFormCollection form)
        {
            try
            {
                var fechaString = form["fecha"];
                var descripcion = form["descripcion"];
                var accionesInmediatas = form["accionesInmediatas"];
                var antecedentes = form["antecedentes"];
                var atencionAlEvento = form["atencionAlEvento"];
                var personalInvolucrado = form["personalInvolucrado"];
                var impacto = form["impacto"];
                var image = form.Files["image"];

                if (!DateTime.TryParse(fechaString, out var fecha))
                {
                    return BadRequest("La Fecha no es válida.");
                }

                var objReport = new Report
                {
                    Fecha = fecha,
                    Descripcion = descripcion,
                    AccionesInmediatas = accionesInmediatas,
                    Antecedentes = antecedentes,
                    AtencionAlEvento = atencionAlEvento,
                    PersonalInvolucrado = personalInvolucrado,
                    Impacto = impacto,
                    imagePath = await SaveImage(image),
                };

                _reportDbContext.Report.Add(objReport);
                await _reportDbContext.SaveChangesAsync();
                return Ok(objReport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al procesar la solicitud. Detalles: " + ex.Message);
            }
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            if (image == null)
            {
                return string.Empty;
            }

            var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            var uniqueFileName = $"{Path.GetRandomFileName()}{Path.GetExtension(image.FileName)}";
            var filePath = Path.Combine(imagesFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return $"Images/{uniqueFileName}";
        }
    }
}
