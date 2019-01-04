using System.Collections.Generic;

namespace PoweredSoft.Music.String.Core
{
    public interface IFrettedLuteInstrument : ILuteInstrument
    { 
        int FretCount { get; set; }
        List<IFrettedString> FrettedStrings { get; set; }
    }
}
