using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PoweredSoft.Music.String;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;


namespace PoweredSoft.Music.Web.Controllers
{
    [ApiController]
    public class StringInstrumentChordController : Controller
    {
        [HttpGet, Route("api/[controller]s/chords/{stringNotes}/{semiToneCount}/{root}")]
        public IEnumerable<IStringInstrumentChord> Chords(
            [FromServices]INoteService noteService,
            [FromServices]IStringInstrumentService stringInstrumentService,
            [FromServices]IStringInstrumentChordService stringInstrumentChordService,
            string stringNotes, int semiToneCount, string root)
        {
            var sn = stringNotes
                .Split(',')
                .Select(noteName => noteService.GetNoteByName(noteName))
                .ToArray();

            var rootNote = noteService.GetNoteByName(root);
            var instrument = stringInstrumentService.CreateInstrument<StringInstrument>(semiToneCount, sn);
            var ret = stringInstrumentChordService.GetChords(instrument, rootNote);
            return ret;
        }

        [HttpGet, Route("api/[controller]s/chords/{stringNotes}/{semiToneCount}/{root}/{type}")]
        public IStringInstrumentChord Chord(
            [FromServices]INoteService noteService,
            [FromServices]IStringInstrumentService stringInstrumentService,
            [FromServices]IStringInstrumentChordService stringInstrumentChordService,
            string stringNotes, int semiToneCount, string root, Chords type)
        {
            var sn = stringNotes
                .Split(',')
                .Select(noteName => noteService.GetNoteByName(noteName))
                .ToArray();

            var rootNote = noteService.GetNoteByName(root);
            var instrument = stringInstrumentService.CreateInstrument<StringInstrument>(semiToneCount, sn);
            var ret = stringInstrumentChordService.GetChord(instrument, rootNote, type);
            return ret;
        }
    }
}