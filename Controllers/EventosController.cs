using LibroDigital.Models;
using LibroDigital.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibroDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {


        private readonly IEventoService _service;

        public EventosController(IEventoService service)
        {
            _service = service;
        }

        // GET: api/eventos
        [HttpGet]
        public async Task<ActionResult<List<Evento>>> GetAll()
        {
            var eventos = await _service.GetAllEventosAsync();
            return Ok(eventos);
        }

        // GET: api/eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetById(int id)
        {
            var estudiante = await _service.GetEventosByIdAsync(id);
            if (estudiante == null) return NotFound();
            return Ok(estudiante);
        }

        // POST: api/eventos
        [HttpPost]
        public async Task<ActionResult<Estudiante>> Create(Evento evento)
        {
            var created = await _service.CreateEventoAsync(evento);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/eventos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Evento>> Update(int id, Evento evento)
        {
            var updated = await _service.UpdateEventoAsync(id, evento);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE: api/eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteEventoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }


}

