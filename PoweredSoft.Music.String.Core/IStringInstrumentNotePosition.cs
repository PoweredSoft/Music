using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.String.Core
{
    public interface IStringInstrumentNotePosition
    {
        int StringPosition { get; set; }
        int StringNotePosition { get; set; }
        INote Note { get; set; }
    }
}