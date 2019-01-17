using System;
using System.Collections.Generic;
using System.Linq;
using PoweredSoft.Music.String.Core;

namespace PoweredSoft.Music.String
{
    public class StringInstrumentChordPossibility : IStringInstrumentChordPossibility 
    {
        public IList<IStringInstrumentNotePosition> NotePositions { get; set; }

        public bool Equals(IStringInstrumentChordPossibility other)
        {
            return other.NotePositions.All(t => NotePositions.Any(t2 => t2.Equals(t)));
        }
    }
}