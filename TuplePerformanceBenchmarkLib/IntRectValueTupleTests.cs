using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    public class IntRectValueTupleTests
        : ValueTupleTests<int, GoodRect>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public IntRectValueTupleTests()
        {
            Get = ThisGetMethod;
            Sink = ThisSinkMethod;
            ListSink = ThisListSinkMethod;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTuple<int, GoodRect> ThisGetMethod(int index)
        {
            return new IntRect(index).ToValueTuple();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ThisSinkMethod(ValueTuple<int, GoodRect> tup)
        {
            Long += (tup.Item1 + tup.Item2.X + tup.Item2.Y + tup.Item2.Width + tup.Item2.Height);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ThisListSinkMethod(List<ValueTuple<int, GoodRect>> list)
        {
            ListResult = list;
            Long += list.Count;
        }
    }
}
