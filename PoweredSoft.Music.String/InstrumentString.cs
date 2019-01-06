using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.String
{
    public class InstrumentString : IInstrumentString
    {
        public int Position { get; set; }
        public INote OpenStringNote { get; set; }
        public IList<IInstrumentStringNote> StringNotes { get; set; }
    }
}
