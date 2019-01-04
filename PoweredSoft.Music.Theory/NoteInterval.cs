using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class NoteInterval : INoteInterval
    {
        public INote Note { get; set; }
        public IInterval Interval { get; set; }

        public bool Equals(INoteInterval other) => Note.Equals(other.Note) && Interval.Equals(other.Interval);

        public override string ToString() => $"{Note} - {Interval}";
    }
}
