using System.Collections.Generic;
using PoweredSoft.Music.Theory.Core;

public interface IScale
{
    INote Key { get; set; }
    IScaleDefinition ScaleDefinition { get; set; }
    IList<INote> Notes { get; set; }
}