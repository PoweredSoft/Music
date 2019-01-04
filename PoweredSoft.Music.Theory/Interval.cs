using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class Interval : IInterval
    {
        public int DistanceInSemiTones { get; set; }
        public Intervals Type { get; set; }
        public string Title { get; set; }
        public string Symbol { get; set; }

        public bool Equals(Intervals other) => other == Type;

        public bool Equals(int other) => other == DistanceInSemiTones;

        public bool Equals(string other) 
            => Title.Equals(other, StringComparison.InvariantCultureIgnoreCase) || Symbol.Equals(other, StringComparison.InvariantCultureIgnoreCase);

        public bool Equals(IInterval other) => Equals(other.Type);

        public override string ToString() => $"{Title} | {Symbol} | Distance in semi tones: {DistanceInSemiTones}";
    }
}
