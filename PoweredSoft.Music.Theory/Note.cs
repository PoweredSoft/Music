using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class Note : INote
    {
        public string Name { get; set; }
        public bool IsNatural { get; set; }
        public string AlternativeName { get; set; }

        public bool Equals(INote other) => Equals(other?.Name);

        public bool Equals(string other) => Name.Equals(other, StringComparison.InvariantCultureIgnoreCase) || true == AlternativeName?.Equals(other, StringComparison.InvariantCultureIgnoreCase);

        public override string ToString() => $"{Name} {AlternativeName}".TrimEnd();
    }
}
