using PoweredSoft.Music.String.Core.Guitar;
using System;
using System.Linq;
using System.Text;

namespace PoweredSoft.Music.String
{
    public class Guitar : StringInstrument, IGuitar
    {
        public override string Name => "Guitar";

        public override bool HasFrets => true;
    }
}
