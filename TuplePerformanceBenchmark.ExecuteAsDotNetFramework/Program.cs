using System;
using System.Runtime.CompilerServices;

namespace TuplePerformanceBenchmark.ExecuteAsDotNetFramework
{
    using TuplePerformanceBenchmarkLib;

    /// <summary>
    /// 
    /// 
    /// <para>
    /// Original ideas and acknowledgements:<br/>
    /// 1 ... [[ https://gist.github.com/ljw1004/61bc96700d0b03c17cf83dbb51437a69 ]]
    /// </para>
    /// </summary>
    /// 
    public static class Program
    {
        public static readonly Lazy<Random> _lzRandom = new Lazy<Random>(() => new Random());
        public static Random Random => _lzRandom.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void Main(string[] args)
        {
            // To warm up properly, we run all tests multiple times.
            const int repeatCount = 3;
            for (int k = 0; k < repeatCount; ++k)
            {
                new BenchmarkExecuter(typeof(IntRectTupleTests)).Execute();
                new BenchmarkExecuter(typeof(IntRectValueTupleTests)).Execute();
                new BenchmarkExecuter(typeof(IntRectKeyValuePairTests)).Execute();
            }
        }
    }
}
