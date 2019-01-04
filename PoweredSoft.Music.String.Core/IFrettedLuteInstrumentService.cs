using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.String.Core
{
    public interface IFrettedLuteInstrumentService
    {
        T CreatedInstrumnent<T>(int fretCount, params INote[] openStrings) 
            where T : IFrettedLuteInstrument, new();
    }
}
