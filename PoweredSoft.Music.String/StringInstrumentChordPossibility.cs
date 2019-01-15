using System.Collections.Generic;
using PoweredSoft.Music.String.Core;

namespace PoweredSoft.Music.String
{
    public class StringInstrumentChordPossibility : IStringInstrumentChordPossibility
    {
        public IList<IStringInstrumentNotePosition> NotePositions { get; set; }
    }
}