using PoweredSoft.Music.Theory.Core;
using System.Collections.Generic;

namespace PoweredSoft.Music.String.Core
{
    public interface IInstrumentStringNote
    {
        INote Note { get; set; }
        
        int Position { get; set; }
    }

    public interface IInstrumentString
    {
        int Position {get; set;}
        INote OpenStringNote { get; set; }
        IList<IInstrumentStringNote> StringNotes { get; set; }
    }
}
