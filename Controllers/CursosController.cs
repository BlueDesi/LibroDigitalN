using LibroDigital.Models;
using LibroDigital.Services;
using LibroDigital.Services.Cursos;
using Microsoft.AspNetCore.Mvc;

namespace LibroDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : Controller
    {
        private readonly ICursoService _service;

        public CursosController(ICursoService service)
        {
            _service = service;
        }

        // GET: api/cursos
        [HttpGet]
        public async Task<ActionResult<List<Curso>>> GetAll()
        {
            var estudiantes = await _service.GetAllCursosAsync();
            return Ok(estudiantes);
        }

        // GET: api/cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetById(int id)
        {
            var curso = await _service.GetCursoByIdAsync(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        // POST: api/cursos
        [HttpPost]
        public async Task<ActionResult<Curso>> Create(Curso curso)
        {
            try
            {
                var created = await _service.CreateCursoAsync(curso);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cursos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Curso>> Update(int id, Curso curso)
        {
            var updated = await _service.UpdateCursoAsync(id, curso);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE: api/cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteCursoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}

