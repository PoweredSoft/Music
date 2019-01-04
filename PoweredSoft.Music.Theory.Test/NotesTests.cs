using PoweredSoft.Music.Theory.Core;
using System;
using System.Linq;
using Xunit;

namespace PoweredSoft.Music.Theory.Test
{
    public class NoteTests
    {
        [Fact]
        public void GetNotes()
        {
            var noteService = new NoteService();
            var notes = noteService.GetNotes();
            Assert.Equal(12, notes.Count());
        }

        [Fact]
        public void GetNote()
        {
            var noteService = new NoteService();
            var noteA = noteService.GetNoteByName("a");
            var noteA2 = noteService.GetNoteByName("A");
            Assert.NotNull(noteA);
            Assert.NotNull(noteA2);
            Assert.Equal(noteA, noteA2);
        }
    }
}
