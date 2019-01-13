using System.Collections.Generic;
using PoweredSoft.Music.Theory.Core;


namespace PoweredSoft.Music.String.Core
{
    public interface IStringInstrumentChordService
    {
        IList<IStringInstrumentChord> GetChords(IStringInstrument stringInstrument, INote note);
        IStringInstrumentChord GetChord(IStringInstrument stringInstrument, INote note, Chords type);
    }
}