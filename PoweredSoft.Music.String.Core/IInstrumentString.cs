using PoweredSoft.Music.Theory.Core;
using System.Collections.Generic;

namespace PoweredSoft.Music.String.Core
{
    public interface IInstrumentString
    {
        INote OpenStringNote { get; set; }
        IList<INote> Notes { get; set; }
    }
}
