using PoweredSoft.Music.String.Core.Guitar;
using System;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.String
{
    public class Guitar : FrettedLuteInstrument, IGuitar
    {
        public override string Name => "Guitar";
    }
}
