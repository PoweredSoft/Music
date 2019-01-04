using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class ChordDefinition : IChordDefinition
    {
        public Chords Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> SemiTones { get; set; }

        public bool Equals(IChordDefinition other) => Equals(other.Type);

        public bool Equals(Chords other) => Type == other;

        public bool Equals(string other) => Title.Equals(other, StringComparison.InvariantCultureIgnoreCase);

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
