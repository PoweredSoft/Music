using Microsoft.AspNetCore.Mvc;
using PoweredSoft.Music.String;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.String.Core.Ukulele;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoweredSoft.Music.Web.Controllers
{
    [ApiController]
    public class UkuleleController : Controller
    {
        [HttpGet, Route("api/[controller]/StandardTuning")]
        public IUkulele StandardTuning([FromServices]IUkuleleService s) => s.StandardGCEATuning();

        [HttpGet, Route("api/[controller]/StandardTuning/{fretCount}")]
        public IUkulele StandardTuning([FromServices]IUkuleleService s, int fretCount) => s.StandardGCEATuning(fretCount);

        [HttpGet, Route("api/[controller]/SweeterADFSharpBTuning")]
        public IUkulele SweeterADFSharpBTuning([FromServices]IUkuleleService s) => s.SweeterADFSharpBTuning();

        [HttpGet, Route("api/[controller]/SweeterADFSharpBTuning/{fretCount}")]
        public IUkulele SweeterADFSharpBTuning([FromServices]IUkuleleService s, int fretCount) => s.SweeterADFSharpBTuning(fretCount);

        [HttpGet, Route("api/[controller]/LargerBodyDGBETuning")]
        public IUkulele LargerBodyDGBETuning([FromServices]IUkuleleService s) => s.LargerBodyDGBETuning();

        [HttpGet, Route("api/[controller]/LargerBodyDGBETuning/{fretCount}")]
        public IUkulele LargerBodyDGBETuning([FromServices]IUkuleleService s, int fretCount) => s.LargerBodyDGBETuning(fretCount);

        [HttpGet, Route("api/[controller]/Custom/{fretCount}/{notes}")]
        public IUkulele Custom([FromServices]IStringInstrumentService flus,
            [FromServices]INoteService noteService, int fretCount, string notes)
        {
            var splittedNotes = notes.Split(',');
            var openStrings = splittedNotes.Select(n => noteService.GetNoteByName(n)).ToArray();
            var guitar = flus.CreateInstrument<Ukulele>(fretCount, openStrings);
            return guitar;
        }
    }
}
