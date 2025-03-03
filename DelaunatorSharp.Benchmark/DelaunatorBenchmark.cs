using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DelaunatorSharp.Benchmark
{
    [SimpleJob(RunStrategy.ColdStart, warmupCount:10, iterationCount: 10)]
    [HtmlExporter]
    public class DelaunatorBenchmark
    {
        private Distribution distribution = new Distribution();
        private Vector2[] points;

        [Params(100000, 1000000)]
        public int Count;

        [ParamsAllValues]
        public Distribution.Type Type { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            points = distribution.GetPoints(Type, Count).ToArray();
        }

        [Benchmark]
        public Delaunator Delaunator()
        {
            return new Delaunator(points);
        }
    }
}
