using Force.DeepCloner;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.Theory
{
    public class IntervalService : IIntervalService
    {
        private readonly List<Interval> intervals = new List<Interval>()
        {
            new Interval { DistanceInSemiTones = 0, Type = Intervals.Tonic, Title = "tonic", Symbol = "1"},
            new Interval { DistanceInSemiTones = 1, Type = Intervals.MinorSecond,  Title = "minor second", Symbol = "b2"},
            new Interval { DistanceInSemiTones = 2, Type = Intervals.MajorSecond,  Title = "major second", Symbol = "2"},
            new Interval { DistanceInSemiTones = 3, Type = Intervals.MinorThird,  Title = "minor third", Symbol = "b3"},
            new Interval { DistanceInSemiTones = 4, Type = Intervals.MajorThird,  Title = "major third", Symbol = "3"},
            new Interval { DistanceInSemiTones = 5, Type = Intervals.PerfectFourth,  Title = "perfect fourth", Symbol = "4"},
            new Interval { DistanceInSemiTones = 6, Type = Intervals.Tritone,  Title = "tritone", Symbol = "4# / b5"},
            new Interval { DistanceInSemiTones = 7, Type = Intervals.PerfectFifth,  Title = "perfect fifth", Symbol = "5"},
            new Interval { DistanceInSemiTones = 8, Type = Intervals.MinorSixth,  Title = "minor sixth", Symbol = "b6"},
            new Interval { DistanceInSemiTones = 9, Type = Intervals.MajorSixth,  Title = "major sixth", Symbol = "6"},
            new Interval { DistanceInSemiTones = 10,Type = Intervals.MinorSeventh,  Title = "minor seventh", Symbol = "b7"},
            new Interval { DistanceInSemiTones = 11,Type = Intervals.MajorSecond,  Title = "major seventh", Symbol = "7"},
            new Interval { DistanceInSemiTones = 12,Type = Intervals.Octave,  Title = "octave", Symbol = "8"},
        };

        public IList<IInterval> GetIntervals()
        {
            var result = intervals.Select(i => i.DeepClone()).AsEnumerable<IInterval>().ToList();
            return result;
        }
    }
}
