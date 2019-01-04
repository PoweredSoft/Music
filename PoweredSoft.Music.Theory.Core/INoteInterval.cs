using System;

namespace PoweredSoft.Music.Theory.Core
{
    public interface INoteInterval : IEquatable<INoteInterval>
    {
        INote Note { get; set; }
        IInterval Interval { get; set; }
    }
}
