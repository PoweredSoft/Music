using Microsoft.AspNetCore.Mvc;
using PoweredSoft.Music.Theory;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoweredSoft.Music.Web.Controllers
{
    [ApiController]
    public class NoteIntervalController : Controller
    {
        [HttpGet, Route("api/[controller]s/{note}")]
        public IEnumerable<INoteInterval> Get([FromServices]INoteIntervalService noteIntervalService, string note)
            => noteIntervalService.GetNoteIntervals(note);
    }
}
