using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.String.Core.Guitar;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.String
{
    public class GuitarService : IGuitarService
    {
        public GuitarService(INoteService noteService, IFrettedLuteInstrumentService frettedLuteInstrumentService)
        {
            NoteService = noteService;
            FrettedLuteInstrumentService = frettedLuteInstrumentService;
        }

        public INoteService NoteService { get; }
        public IFrettedLuteInstrumentService FrettedLuteInstrumentService { get; }

        public IGuitar StandardTuning(int fretCount = 24)
        {
            var e = NoteService.GetNoteByName("E");
            var a= NoteService.GetNoteByName("A");
            var d = NoteService.GetNoteByName("D");
            var g = NoteService.GetNoteByName("G");
            var b = NoteService.GetNoteByName("B");
            var guitar = FrettedLuteInstrumentService.CreatedInstrumnent<Guitar>(24, e, b, g, d, a, e);
            return guitar;
        }
    }
}
