using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.String
{
    public class InstrumentString : IInstrumentString
    {
        public INote OpenStringNote { get; set; }

        public IList<INote> Notes { get; set; }
    }
}
