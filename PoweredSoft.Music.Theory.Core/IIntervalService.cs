using System.Collections.Generic;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.Theory
{
    public interface IIntervalService
    {
        IList<IInterval> GetIntervals();
    }
}