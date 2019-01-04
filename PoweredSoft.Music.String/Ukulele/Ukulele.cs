using PoweredSoft.Music.String.Core.Ukulele;

namespace PoweredSoft.Music.String
{
    public class Ukulele : StringInstrument, IUkulele
    {
        public override string Name => "Ukulele";

        public override bool HasFrets => true;
    }
}
