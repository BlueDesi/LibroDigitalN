using LibroDigital.Models;
using LibroDigital.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibroDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {


        private readonly IEstudianteService _service;

        public EstudiantesController(IEstudianteService service)
        {
            _service = service;
        }

        // GET: api/estudiantes
        [HttpGet]
        public async Task<ActionResult<List<Estudiante>>> GetAll()
        {
            var estudiantes = await _service.GetAllEstudiantesAsync();
            return Ok(estudiantes);
        }

        // GET: api/profesores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetById(int id)
        {
            var estudiante = await _service.GetEstudianteByIdAsync(id);
            if (estudiante == null) return NotFound();
            return Ok(estudiante);
        }

        // POST: api/profesores
        [HttpPost]
        public async Task<ActionResult<Estudiante>> Create(Estudiante estudiante)
        {
            var created = await _service.CreateEstudianteAsync(estudiante);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/profesores/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Estudiante>> Update(int id, Estudiante estudiante)
        {
            var updated = await _service.UpdateEstudianteAsync(id, estudiante);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE: api/estudiantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteEstudianteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }


}

