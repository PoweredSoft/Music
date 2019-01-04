using PoweredSoft.Music.Theory.Core;
using System.Collections.Generic;

namespace PoweredSoft.Music.String.Core
{
    public interface IStringInstrument : IInstrument
    {
        int SemiToneCount { get; set; }
        bool HasFrets { get; }

        List<IInstrumentString> Strings { get; set; }
    }
}
