using System;
using System.Collections.Generic;

public interface IScaleDefinition : IEquatable<IScaleDefinition>, IEquatable<Scales>, IEquatable<string>
{
    Scales Type { get; set; }
    string Title { get; set; }
    string Description { get; set; }
    List<int> DistancePatternInSemiTones { get; set; }
}