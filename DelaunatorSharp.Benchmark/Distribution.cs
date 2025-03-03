using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DelaunatorSharp.Benchmark
{
    public class Distribution
    {
        private Random random = new Random();
        public enum Type { Uniform, Gaussian, Grid };

        public IEnumerable<Vector2> GetPoints(Type type, int count)
        {
            switch (type)
            {
                case Type.Uniform: return Uniform(count);
                case Type.Gaussian: return Gaussian(count);
                case Type.Grid: return Grid(count);
            }

            return Enumerable.Empty<Vector2>();
        }

        public IEnumerable<Vector2> Uniform(int count)
        {
            for (var i = 0; i < count; i++)
                yield return new Vector2((float)random.NextDouble() * MathF.Pow(10, 3), (float)random.NextDouble() * MathF.Pow(10, 3));
        }

        public IEnumerable<Vector2> Grid(int count)
        {
            var size = Math.Sqrt(count);
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    yield return new Vector2(i, j);
        }
        public IEnumerable<Vector2> Gaussian(int count)
        {
            for (var i = 0; i < count; i++)
                yield return new Vector2(PseudoNormal() * MathF.Pow(10, 3), PseudoNormal() * MathF.Pow(10, 3));
        }

        private float PseudoNormal()
        {
            var v = (float)(random.NextDouble() + random.NextDouble() + random.NextDouble() + random.NextDouble() + random.NextDouble() + random.NextDouble());
            return MathF.Min(0.5f * (v - 3) / 3, 1);
        }
    }

}
