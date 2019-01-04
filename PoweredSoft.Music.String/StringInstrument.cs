using PoweredSoft.Music.String.Core;
using System.Collections.Generic;
using System.Linq;

namespace PoweredSoft.Music.String
{
    public abstract class StringInstrument : IStringInstrument
    {
        public abstract string Name { get; }

        public int SemiToneCount { get; set; }

        public abstract bool HasFrets { get; }

        public List<IInstrumentString> Strings { get; set; }
    }
}
