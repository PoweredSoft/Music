using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PoweredSoft.Music.Theory.Test
{
    public class ChordTests
    {
        [Fact]
        public void AMajorChord()
        {
            var noteService = new NoteService();
            var intervalService = new IntervalService();
            var noteIntervalService = new NoteIntervalService(noteService, intervalService);
            var chordService = new ChordService(noteIntervalService, noteService);
            var aMajorChord = chordService.GetChord("A", Core.Chords.Major);
            Assert.NotNull(aMajorChord);
            Assert.Equal("A", aMajorChord.Key.Name);

            // notes.
            Assert.Equal("A", aMajorChord.Notes[0].Name);
            Assert.Equal("C#", aMajorChord.Notes[1].Name);
            Assert.Equal("E", aMajorChord.Notes[2].Name);
        }
    }
}
