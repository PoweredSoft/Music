using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.String.Core.Guitar
{
    public interface IGuitarService
    {
        IGuitar StandardTuning(int fretCount = 24);
    }
}
