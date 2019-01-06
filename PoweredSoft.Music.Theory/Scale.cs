using System.Collections.Generic;
using PoweredSoft.Music.Theory.Core;

public class Scale : IScale
{
    public INote Key { get; set; }
    public IScaleDefinition ScaleDefinition { get; set; }
    public IList<INote> Notes { get; set; }
}
