using System;
using System.Collections.Generic;

namespace PoweredSoft.Music.Theory.Core
{
    public interface IChord : IEquatable<IChord>
    {
        INote Key { get; set; }
        IChordDefinition ChordDefinition { get; set; }
        IList<INote> Notes { get; set; }
    }
}
