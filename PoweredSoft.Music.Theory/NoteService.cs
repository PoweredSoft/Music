using Force.DeepCloner;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _notes = new List<Note>
        {
            new Note {
                Name = "A",
                IsNatural = true,
            },
            new Note {
                Name = "A#",
                AlternativeName = "Bb",
                IsNatural = false,
            },
            new Note {
                Name = "B",
                IsNatural = true,
            },
            new Note {
                Name = "C",
                IsNatural = true,
            },
            new Note {
                Name = "C#",
                AlternativeName = "Db",
                IsNatural = false,
            },
            new Note {
                Name = "D",
                IsNatural = true,
            },
            new Note {
                Name = "D#",
                AlternativeName = "Eb",
                IsNatural = false,
            },
            new Note {
                Name = "E",
                IsNatural = true,
            },
            new Note {
                Name = "F",
                IsNatural = true,
            },
            new Note {
                Name = "F#",
                AlternativeName = "Gb",
                IsNatural = false,
            },
            new Note {
                Name = "G",
                IsNatural = true,
            },
            new Note {
                Name = "G#",
                AlternativeName = "Ab",
                IsNatural = false
            }
        };

        public IList<INote> GetNotes()
        {
            return _notes.Select(n => n.DeepClone()).AsQueryable<INote>().ToList();
        }

        public INote GetNoteByName(string name)
        {
            var note = _notes.FirstOrDefault(t => t.Equals(name));
            if (note == null)
                return null;

            return note.DeepClone();
        }
    }
}
