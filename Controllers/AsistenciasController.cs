using LibroDigital.Models;
using LibroDigital.Services;
using LibroDigital.Services.Asistencias;
using LibroDigital.Services.Cursos;
using Microsoft.AspNetCore.Mvc;

namespace LibroDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciasController : Controller
    {
        private readonly IAsistenciaService _service;

        public AsistenciasController(IAsistenciaService asistencia)
        {
            _service = asistencia;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asistencias = await _service.GetAllAsistenciasAsync();
            return Ok(asistencias); // Lista de Asistencias
        }

        // GET: api/asistencias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetAsistenciaByIdAsync(id);

            if (result == null)
                return NotFound(new { success = false, errorMessage = $"Asistencia {id} no encontrada." });

            return Ok(new { success = true, data = result });
        }

        // POST: api/asistencias
        [HttpPost]
        public async Task<IActionResult> Create(Asistencia asistencia)
        {
            var result = await _service.CreateAsistenciaAsync(asistencia);

            if (!result.Success)
                return BadRequest(new { success = false, errorMessage = result.ErrorMessage });

            return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id },
                                   new { success = true, data = result.Data });
        }

        // PUT: api/asistencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Asistencia asistencia)
        {
            var result = await _service.UpdateAsistenciaAsync(id, asistencia);

            if (!result.Success)
                return BadRequest(new { success = false, errorMessage = result.ErrorMessage });

            if (result.Data == null)
                return NotFound(new { success = false, errorMessage = $"Asistencia {id} no encontrada." });

            return Ok(new { success = true, data = result.Data });
        }

        // DELETE: api/asistencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsistenciaAsync(id);

            if (!deleted)
                return NotFound(new { success = false, errorMessage = $"Asistencia {id} no encontrada." });

            return NoContent();
        }

    }
}

