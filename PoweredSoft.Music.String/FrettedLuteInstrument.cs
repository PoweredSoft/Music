using PoweredSoft.Music.String.Core;
using System.Collections.Generic;
using System.Linq;

namespace PoweredSoft.Music.String
{
    public abstract class FrettedLuteInstrument : IFrettedLuteInstrument
    {
        public abstract string Name { get; }

        public List<IFrettedString> FrettedStrings { get; set; }

        public IEnumerable<IInstrumentString> Strings => FrettedStrings.AsEnumerable<IInstrumentString>();

        public int FretCount { get; set; }
    }
}
