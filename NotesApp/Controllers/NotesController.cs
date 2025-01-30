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
      

    }
}
