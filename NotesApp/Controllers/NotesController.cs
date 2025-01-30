using Microsoft.AspNetCore.Mvc;
using NotesAppAPI.Models;
using NotesAppAPI.Services;

namespace NotesAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesService _notesService;

        public NotesController(NotesService notesService) =>
            _notesService = notesService;

        [HttpGet]
        public async Task<List<Note>> Get() =>
            await _notesService.GetAsync();
      

    }
            [HttpGet("{id}")]
        public async Task<ActionResult<Note>> Get(string id)
        {
            var note = await _notesService.GetByIdAsync(id);

            if (note is null)
                return NotFound();

            return note;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Note newNote)
        {
            // Validate the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return a bad request if validation fails
            }

            await _notesService.CreateAsync(newNote);
            return CreatedAtAction(nameof(Get), new { id = newNote.Id }, newNote);
        }

}
