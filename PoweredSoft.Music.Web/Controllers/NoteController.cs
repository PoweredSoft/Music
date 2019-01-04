using Microsoft.AspNetCore.Mvc;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoweredSoft.Music.Web.Controllers
{
    [ApiController]
    public class NoteController : Controller
    {
        [HttpGet, Route("[controller]s")]
        public IEnumerable<INote> Get([FromServices] INoteService noteService) => noteService.GetNotes();

        [HttpGet, Route("[controller]s/{name}")]
        public INote Get([FromServices] INoteService noteService, string name) => noteService.GetNoteByName(name);
    }
}
