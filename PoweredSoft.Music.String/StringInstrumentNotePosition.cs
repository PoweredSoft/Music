using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.String
{
    public class StringInstrumentNotePosition : IStringInstrumentNotePosition
    {
        public int StringPosition { get; set; }
        public int StringNotePosition { get; set; }
        public INote Note { get; set; }

        public override string ToString()
        {
            return $"{Note.Name} {StringPosition}x{StringNotePosition}";
        }
    }
}