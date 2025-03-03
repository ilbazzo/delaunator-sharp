using System.Collections.Generic;
using System.Numerics;

namespace DelaunatorSharp
{
    public interface IVoronoiCell
    {
        Vector2[] Points { get; }
        int Index { get; }
    }
}
