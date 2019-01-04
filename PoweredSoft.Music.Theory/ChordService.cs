using Force.DeepCloner;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class ChordService : IChordService
    {
        public ChordService(INoteIntervalService noteIntervalService, INoteService noteService)
        {
            NoteIntervalService = noteIntervalService;
            NoteService = noteService;
        }

        private readonly List<ChordDefinition> definitions = new List<ChordDefinition>
        {
            new ChordDefinition
            {
                Type = Chords.Major,
                Title = "Major",
                Description = "Major chords sound happy and simple.",
                SemiTones = new List<int> {0, 4, 7}
            },
            new ChordDefinition
            {
                Type = Chords.Minor,
                Title = "Minor",
                Description = "Minor chords are considered to be sad, or ‘serious.’",
                SemiTones = new List<int> {0, 3, 7},
            },
            new ChordDefinition
            {
                Type = Chords.Fifth,
                Title = "Power Chords (Fifth Chord)",
                Description = "Often played by amplified guitars",
                SemiTones = new List<int> {0, 7}
            },
            new ChordDefinition
            {
                Type = Chords.Deminished,
                Title = "Diminished",
                Description = "Diminished Chords sound tense and unpleasant.",
                SemiTones = new List<int> {0, 3, 6}
            },
            new ChordDefinition
            {
                Type = Chords.MajorSeventh,
                Title = "Major Seventh",
                Description = "Major seventh chords are considered to be thoughtful, soft (Jazzy)",
                SemiTones = new List<int> {0, 4, 7, 11}
            },
            new ChordDefinition
            {
                Type = Chords.MinorSeventh,
                Title = "Minor Seventh",
                Description = "Minor seventh chords are considered to be moody, or contemplative",
                SemiTones = new List<int> {0, 3, 7, 10}
            },
            new ChordDefinition
            {
                Type = Chords.DominantSeventh,
                Title = "Dominant Seventh",
                Description = "Dominant seventh chords are considered to be strong and restless (jazz and blues, as well as jazz inspired r&b, hip hop, & EDM.)",
                SemiTones = new List<int> {0, 4, 7, 10}
            },
            new ChordDefinition
            {
                Type = Chords.Sus2,
                Title = "Sus2",
                Description = "Sus2 Chords sound bright and nervous.",
                SemiTones = new List<int> {0, 2, 7}
            },
            new ChordDefinition
            {
                Type = Chords.Sus4,
                Title = "Sus4",
                Description = "Sus4 Chords, like Sus2 chords, sound bright and nervous.",
                SemiTones = new List<int> {0, 5, 7}
            },
            new ChordDefinition
            {
                Type = Chords.Augmented,
                Title = "Augmented",
                Description = "Augmented chords sound anxious and suspenseful.",
                SemiTones = new List<int> {0, 4, 8}
            },
            new ChordDefinition
            {
                Type = Chords.DominantNinth,
                Title = "Dominant Ninth",
                Description = "common in jazz, funk, and R&B",
                SemiTones = new List<int> {0, 4, 7, 10, 14}
            },
            new ChordDefinition
            {
                Type = Chords.MajorEleventh,
                Title = "Major Eleventh",
                Description = "common in jazz, funk, and R&B",
                SemiTones = new List<int> {0, 4, 7, 11, 14, 17}
            }
        };

        protected INoteIntervalService NoteIntervalService { get; }
        protected INoteService NoteService { get; }

        public IList<IChordDefinition> GetDefinitions()
        {
            return definitions.Select(d => d.DeepClone()).AsEnumerable<IChordDefinition>().ToList();
        }

        public IChord GetChord(string name, Chords type)
        {
            var note = NoteService.GetNoteByName(name);
            return GetChord(note, type);
        }

        public IChord GetChord(string name, string title)
        {
            var note = NoteService.GetNoteByName(name);
            return GetChord(note, title);
        }

        public IChord GetChord(string name, IChordDefinition definition)
        {
            var note = NoteService.GetNoteByName(name);
            return GetChord(note, definition);
        }

        public IChord GetChord(INote note, Chords type)
        {
            var definition = definitions.FirstOrDefault(d => d.Equals(type));
            if (definition == null)
                throw new ArgumentException($"the type {type} is not a supported chord", nameof(type));

            var ret = GetChord(note, definition);
            return ret;
        }

        public IChord GetChord(INote note, IChordDefinition definition)
        {
            var noteIntervals = NoteIntervalService.GetNoteIntervals(note);
            var notes = definition.SemiTones.Select(st =>
            {
                var safe = SafeSemiTone(st);
                var interval = noteIntervals.First(ni => ni.Interval.DistanceInSemiTones == safe);
                return interval.Note.DeepClone();
            }).ToList();

            return new Chord
            {
                Key = note.DeepClone(),
                ChordDefinition = definition.DeepClone(),
                Notes = notes
            };
        }

        public IChord GetChord(INote note, string title)
        {
            var definition = definitions.FirstOrDefault(d => d.Equals(title));
            if (definition == null)
                throw new ArgumentException($"{title} is not a supported chord", nameof(title));

            var ret = GetChord(note, definition);
            return ret;
        }

        public IList<IChord> GetChords(string name)
        {
            var note = NoteService.GetNoteByName(name);
            return GetChords(note);
        }

        public IList<IChord> GetChords(INote note)
        {
            var chords = definitions.Select(d => GetChord(note, d)).ToList();
            return chords;
        }

        protected int SafeSemiTone(int semiTone)
        {
            return semiTone <= 12 ? semiTone : semiTone-12;
        }

        public IList<IChord> ReverseSearch(IEnumerable<string> notes)
        {
            var realNotes = notes.Select(noteName => this.NoteService.GetNoteByName(noteName)).ToList();
            var ret = ReverseSearch(realNotes);
            return ret;            
        }

        public IList<IChord> ReverseSearch(IEnumerable<INote> notes)
        {
            var possibleChords = notes.SelectMany(note => GetChords(note)).ToList();
            var ret = possibleChords
                .Where(chord => notes.All(n => chord.Notes.Any(cn => cn.Equals(n))))
                .ToList();

            return ret;
        }
    }
}
