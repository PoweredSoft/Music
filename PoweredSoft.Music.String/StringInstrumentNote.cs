using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.String
{
    public class StringInstrumentNote : IInstrumentStringNote
    {
        public INote Note {get; set; }
        public int Position { get; set; }
    }
}
