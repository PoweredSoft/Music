using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.Theory.Core
{
    public interface IChordDefinition
    {
        Chords Type { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        List<int> SemiTones { get; set; }
    }
}
