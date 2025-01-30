using Microsoft.AspNetCore.Mvc;
using NotesAppAPI.Models;
using NotesAppAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesService _notesService;

        public NotesController(NotesService notesService) =>
            _notesService = notesService;

        // GET: api/notes
        [HttpGet]
        public async Task<ActionResult<List<Note>>> Get()
        {
            try
            {
                var notes = await _notesService.GetAsync();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/notes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> Get(string id)
        {
            try
            {
                var note = await _notesService.GetByIdAsync(id);

                if (note is null)
                    return NotFound($"Note with ID '{id}' not found.");

                return Ok(note);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/notes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Note newNote)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _notesService.CreateAsync(newNote);
                return CreatedAtAction(nameof(Get), new { id = newNote.Id }, newNote);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
