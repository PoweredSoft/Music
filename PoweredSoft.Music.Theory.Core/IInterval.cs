using System;

namespace PoweredSoft.Music.Theory.Core
{
    public interface IInterval : IEquatable<Intervals>, IEquatable<int>, IEquatable<string>, IEquatable<IInterval>
    {
        int DistanceInSemiTones { get; set; }
        string Title { get; set; }
        Intervals Type { get; set; }
        string Symbol { get; set; }
    }
}
