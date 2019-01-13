using System.Collections.Generic;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.String
{
    public class StringInstrumentChord : IStringInstrumentChord
    {
        public IChord Chord { get; set; }
        public IList<IStringInstrumentChordPossibility> ChordPossibilities { get; set; }
    }
}