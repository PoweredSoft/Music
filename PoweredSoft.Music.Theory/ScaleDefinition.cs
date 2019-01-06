using System;
using System.Collections.Generic;

public class ScaleDefinition : IScaleDefinition
{
    public Scales Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<int> DistancePatternInSemiTones { get; set; }

    public bool Equals(IScaleDefinition other) => Equals(other.Type);

    public bool Equals(Scales other) => Type == other;

    public bool Equals(string other) => Title.Equals(other, StringComparison.InvariantCultureIgnoreCase);
}
