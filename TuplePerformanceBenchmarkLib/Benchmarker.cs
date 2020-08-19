using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    public static class Benchmarker
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void TimedCall(string name, Action action)
        {
            var start = DateTime.UtcNow;
            action();
            var stop = DateTime.UtcNow;
            double elapsed = (stop - start).TotalSeconds;
            double averageNanos = elapsed / Constants.LoopCount * (1000.0 * 1000.0 * 1000.0);
            Console.WriteLine($"{name,64} : total: {elapsed:F12} s,  average: {averageNanos:N1} ns.");
        }
    }
}
