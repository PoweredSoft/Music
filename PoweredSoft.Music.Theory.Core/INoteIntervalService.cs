using System.Collections.Generic;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.Theory
{
    public interface INoteIntervalService
    {
        IList<INoteInterval> GetNoteIntervals(INote note);
        IList<INoteInterval> GetNoteIntervals(string name);
        INote NextNote(IList<INote> notes, INote note, int semiTones = 1);
    }
}