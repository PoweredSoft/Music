using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.String
{
    public class FrettedString : IFrettedString
    {
        public List<IFret> Frets { get; set; }
        public INote OpenStringNote { get; set; }
    }
}
