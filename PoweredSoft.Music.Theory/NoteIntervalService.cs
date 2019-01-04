using Force.DeepCloner;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class NoteIntervalService : INoteIntervalService
    {
        public NoteIntervalService(INoteService noteService, IIntervalService intervalService)
        {
            NoteService = noteService;
            IntervalService = intervalService;
        }

        protected INoteService NoteService { get; }
        protected IIntervalService IntervalService { get; }

        public IList<INoteInterval> GetNoteIntervals(string name)
        {
            var note = NoteService.GetNoteByName(name);
            if (note == null)
                return new List<INoteInterval>();

            return GetNoteIntervals(note);
        }

        public IList<INoteInterval> GetNoteIntervals(INote note)
        {
            var intervals = this.IntervalService.GetIntervals();
            var notes = this.NoteService.GetNotes();
            var ret = intervals.Aggregate(new List<INoteInterval>(), (prev, interval) =>
            {
                var previous = prev.LastOrDefault();
                var intervalNote = previous == null ? note.DeepClone() : GetNextNote(notes, previous.Note);
                prev.Add(new NoteInterval
                {
                    Note = intervalNote,
                    Interval = interval
                });
                return prev;
            });

            return ret;
        }

        private INote GetNextNote(IList<INote> notes, INote note)
        {
            var indexOf = notes.IndexOf(note); ;
            if (indexOf + 1 < notes.Count)
                return notes[indexOf + 1];
            return notes[0];
        }

        public INote NextNote(IList<INote> notes, INote note, int semiTones = 1)
        {
            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Count == 0)
                throw new ArgumentException("must supply a valid notes list", nameof(notes));

            if (note == null)
                throw new ArgumentNullException(nameof(note));

            if (semiTones <= 0)
                throw new ArgumentException("Must be 1 or larget", nameof(semiTones));

            INote ret = note;
            for(var i = 0; i < semiTones; i++)
                ret = GetNextNote(notes, ret);

            return ret;
        }
    }
}
