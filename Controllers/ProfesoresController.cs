using LibroDigital.Models;
using LibroDigital.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibroDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesorService _service;

        public ProfesoresController(IProfesorService service)
        {
            _service = service;
        }

        // GET: api/profesores
        [HttpGet]
        public async Task<ActionResult<List<Profesor>>> GetAll()
        {
            var profesores = await _service.GetAllProfesoresAsync();
            return Ok(profesores);
        }

        // GET: api/profesores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetById(int id)
        {
            var profesor = await _service.GetProfesorByIdAsync(id);
            if (profesor == null) return NotFound();
            return Ok(profesor);
        }

        // POST: api/profesores
        [HttpPost]
        public async Task<ActionResult<Profesor>> Create(Profesor profesor)
        {
            var created = await _service.CreateProfesorAsync(profesor);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/profesores/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Profesor>> Update(int id, Profesor profesor)
        {
            var updated = await _service.UpdateProfesorAsync(id, profesor);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE: api/profesores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteProfesorAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

