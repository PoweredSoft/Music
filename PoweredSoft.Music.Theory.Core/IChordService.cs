using System.Collections.Generic;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.Theory
{
    public interface IChordService
    {
        IChord GetChord(INote note, IChordDefinition definition);
        IChord GetChord(INote note, Chords type);
        IChord GetChord(INote note, string title);
        IChord GetChord(string name, IChordDefinition definition);
        IChord GetChord(string name, Chords type);
        IChord GetChord(string name, string title);
        IList<IChord> GetChords(INote note);
        IList<IChord> GetChords(string name);
        IList<IChordDefinition> GetDefinitions();
    }
}