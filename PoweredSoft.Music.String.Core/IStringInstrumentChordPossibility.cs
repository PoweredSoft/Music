using System.Collections.Generic;

namespace PoweredSoft.Music.String.Core
{
    public interface IStringInstrumentChordPossibility
    {
        IList<IStringInstrumentNotePosition> NotePositions { get; set; }
    }
}