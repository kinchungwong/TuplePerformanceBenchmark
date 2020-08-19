using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    public class IntRectTupleTests
        : TupleTests<int, GoodRect>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public IntRectTupleTests()
        {
            Get = ThisGetMethod;
            Sink = ThisSinkMethod;
            ListSink = ThisListSinkMethod;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Tuple<int, GoodRect> ThisGetMethod(int index)
        {
            return new IntRect(index).ToTuple();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ThisSinkMethod(Tuple<int, GoodRect> tup)
        {
            Long += (tup.Item1 + tup.Item2.X + tup.Item2.Y + tup.Item2.Width + tup.Item2.Height);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ThisListSinkMethod(List<Tuple<int, GoodRect>> list)
        {
            ListResult = list;
            Long += list.Count;
        }
    }
}
