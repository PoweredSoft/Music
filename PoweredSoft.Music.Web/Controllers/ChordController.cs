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
    public class ChordController : Controller
    {
        [HttpGet, Route("/api/[controller]s/{note}")]
        public IEnumerable<IChord> GetAllChords([FromServices]IChordService chordService, string note) => chordService.GetChords(note);

        [HttpGet, Route("/api/[controller]s/{note}/{type}")]
        public IChord GetChord([FromServices]IChordService chordService, string note, Chords type) => chordService.GetChord(note, type);
    }
}
