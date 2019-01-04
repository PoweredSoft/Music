using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.String.Core
{
    public interface IStringInstrumentService
    {
        T CreateInstrument<T>(int semiToneCount, params INote[] openStrings) 
            where T : IStringInstrument, new();

        IInstrumentString CreateString(INote openStringNote, int semiToneCount);
    }
}
