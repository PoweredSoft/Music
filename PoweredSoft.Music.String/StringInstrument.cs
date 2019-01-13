using PoweredSoft.Music.String.Core;
using System.Collections.Generic;
using System.Linq;

namespace PoweredSoft.Music.String
{
    public class StringInstrument : IStringInstrument
    {
        public virtual string Name => "String Intrument";

        public int SemiToneCount { get; set; }

        public virtual bool HasFrets => true;

        public List<IInstrumentString> Strings { get; set; }
    }
}
