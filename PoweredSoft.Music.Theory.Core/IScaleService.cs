using System.Collections.Generic;
using PoweredSoft.Music.Theory.Core;

public interface IScaleService
{
    IList<IScaleDefinition> GetDefinitions();
    IList<IScale> GetScales(string note);
    IList<IScale> GetScales(INote note);
    IScale GetScale(string note, Scales type);
    IScale GetScale(INote note, Scales type);
}
