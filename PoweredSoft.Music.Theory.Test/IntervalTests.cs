using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PoweredSoft.Music.Theory.Test
{
    public class IntervalTests
    {
        [Fact]
        public void GetIntervals()
        {
            var intervalService = new IntervalService();
            var intervals = intervalService.GetIntervals();
            Assert.Equal(13, intervals.Count());

            var perfectFifth = intervals.First(i => i.Symbol == "5");
            Assert.Equal(7, perfectFifth.DistanceInSemiTones);
        }
    }
}
