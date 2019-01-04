using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class Chord : IChord
    {
        public INote Key { get; set; }
        public IChordDefinition ChordDefinition { get; set; }
        public IList<INote> Notes { get; set; }
        public bool Equals(IChord other) => ChordDefinition.Equals(other.ChordDefinition) && Key.Equals(other.Key);

        public override string ToString()
        {
            return $"{Key} {ChordDefinition}";
        }
    }
}
