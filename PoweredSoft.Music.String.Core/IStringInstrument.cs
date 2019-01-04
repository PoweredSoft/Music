using PoweredSoft.Music.Theory.Core;
using System.Collections.Generic;

namespace PoweredSoft.Music.String.Core
{
    public interface IStringInstrument : IInstrument
    {
        IEnumerable<IInstrumentString> Strings { get; }
    }
}
