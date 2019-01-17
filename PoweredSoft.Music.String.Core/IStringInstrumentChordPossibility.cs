using System;
using System.Collections.Generic;

namespace PoweredSoft.Music.String.Core
{
    public interface IStringInstrumentChordPossibility : IEquatable<IStringInstrumentChordPossibility>
    {
        IList<IStringInstrumentNotePosition> NotePositions { get; set; }
    }
}