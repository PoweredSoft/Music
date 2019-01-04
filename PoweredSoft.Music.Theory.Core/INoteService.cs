using System.Collections.Generic;
using PoweredSoft.Music.Theory.Core;

namespace PoweredSoft.Music.Theory.Core
{
    public interface INoteService
    {
        INote GetNoteByName(string name);
        IList<INote> GetNotes();
    }
}