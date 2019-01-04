using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.Theory.Core
{
    public interface INote : IEquatable<INote>, IEquatable<string>
    {
        string Name { get; set; }
        bool IsNatural { get; set; }
        string AlternativeName { get; set; }
    }
}
