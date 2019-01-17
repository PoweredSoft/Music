using Microsoft.AspNetCore.Mvc;
using PoweredSoft.Music.String;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoweredSoft.Music.Web.Controllers
{
    [ApiController]
    public class StringInstrumentController : Controller
    {
        [HttpGet, Route("api/[controller]s/custom/{notes}/{semiToneCount}/{name}")]
        public IStringInstrument Custom([FromServices]IStringInstrumentService service, [FromServices]INoteService noteService,
            string notes, int semiToneCount, string name)
        {
            var realNotes = notes.Split(',').Select(t => noteService.GetNoteByName(t)).ToArray();
            var instrument = service.CreateInstrument<StringInstrument>(semiToneCount, realNotes);
            instrument.Name = name;
            return instrument;
        }
    }
}
