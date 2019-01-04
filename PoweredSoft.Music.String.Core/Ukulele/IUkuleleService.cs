using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.String.Core.Ukulele
{
    public interface IUkuleleService
    {
        IUkulele StandardGCEATuning(int fretCount = 15);
        IUkulele SweeterADFSharpBTuning(int fretCount = 15);
        IUkulele LargerBodyDGBETuning(int fretCount = 20);
    }
}
