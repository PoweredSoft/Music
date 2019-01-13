using System.Collections.Generic;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;


namespace PoweredSoft.Music.String.Core
{
    public interface IStringInstrumentChord
    {
        IChord Chord { get; set; }
        IList<IStringInstrumentChordPossibility> ChordPossibilities { get; set; } 
    }
}