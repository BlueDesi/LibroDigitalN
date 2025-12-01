using LibroDigital.Models;
using LibroDigital.Services.EstudiantesCursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibroDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesCursosController : ControllerBase
    {
        private readonly IEstudianteCursoService _service;

        public EstudiantesCursosController(IEstudianteCursoService service)
        {
            _service = service;
        }

        // GET: api/EstudiantesCursos
        [HttpGet]
        public async Task<ActionResult<List<EstudianteCurso>>> GetAll()
        {
            var lista = await _service.GetAllEstudiantesCursosAsync();
            return Ok(lista);
        }

        // GET: api/EstudiantesCursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteCurso>> GetById(int id)
        {
            var ec = await _service.GetEstudiantesCursosByIdAsync(id);
            if (ec == null) return NotFound();
            return Ok(ec);
        }

        // POST: api/EstudiantesCursos
        [HttpPost]
        public async Task<ActionResult<EstudianteCurso>> Create(EstudianteCurso estudianteCurso)
        {
            try
            {
                var created = await _service.CreateEstudianteCursoAsync(estudianteCurso);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/EstudiantesCursos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EstudianteCurso>> Update(int id, EstudianteCurso estudianteCurso)
        {
            try
            {
                var updated = await _service.UpdateEstudianteCursoAsync(id, estudianteCurso);
                if (updated == null) return NotFound();
                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/EstudiantesCursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteEstudianteCursoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("profesor/{profesorId}")]
        public async Task<IActionResult> GetByProfesor(int profesorId)
        {
            var resultado = await _service.GetEstudiantesCursosByProfesorAsync(profesorId);

            if (resultado == null || resultado.Count == 0)
                return NotFound($"No hay estudiantes inscriptos para el profesor {profesorId}");

            return Ok(resultado);
        }
      
        [HttpGet("curso/{cursoId}")]
        public async Task<ActionResult<List<EstudianteCurso>>> GetByCurso(int cursoId)
        {
            var lista = await _service.GetEstudiantesPorCursoAsync(cursoId);
            return Ok(lista);
        }



    }
}

