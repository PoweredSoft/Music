using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PoweredSoft.Music.Theory.Test
{
    public class NoteIntervalTests
    {
        [Fact]
        public void IntervalTest()
        {
            var noteService = new NoteService();
            var intervalService = new IntervalService();
            var noteIntervalService = new NoteIntervalService(noteService, intervalService);

            var intervals = noteIntervalService.GetNoteIntervals("A");
            var perfectFifth = intervals.First(t => t.Interval.DistanceInSemiTones == 7);
            Assert.Equal("E", perfectFifth.Note.Name);
            Assert.Equal("A", intervals.Last().Note.Name);
            Assert.Equal(Intervals.Octave, intervals.Last().Interval.Type);
        }
    }
}
