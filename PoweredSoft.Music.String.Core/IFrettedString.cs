using System.Collections.Generic;

namespace PoweredSoft.Music.String.Core
{
    public interface IFrettedString : IInstrumentString
    {
        List<IFret> Frets { get; set; }
    }
}
