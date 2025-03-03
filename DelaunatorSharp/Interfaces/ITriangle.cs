using System.Collections.Generic;
using System.Numerics;

namespace DelaunatorSharp
{
    public interface ITriangle
    {
        IEnumerable<Vector2> Points { get; }
        int Index { get; }
    }
}
