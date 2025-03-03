using System.Numerics;

namespace DelaunatorSharp
{
    public interface IEdge
    {
        Vector2 P { get; }
        Vector2 Q { get; }
        int Index { get; }
    }
}
