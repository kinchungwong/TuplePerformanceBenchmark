using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    public class IntRectKeyValuePairTests
        : KeyValuePairTests<int, GoodRect>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public IntRectKeyValuePairTests()
        {
            Get = ThisGetMethod;
            Sink = ThisSinkMethod;
            ListSink = ThisListSinkMethod;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KeyValuePair<int, GoodRect> ThisGetMethod(int index)
        {
            return new IntRect(index).ToKeyValuePair();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ThisSinkMethod(KeyValuePair<int, GoodRect> tup)
        {
            Long += (tup.Key + tup.Value.X + tup.Value.Y + tup.Value.Width + tup.Value.Height);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ThisListSinkMethod(List<KeyValuePair<int, GoodRect>> list)
        {
            ListResult = list;
            Long += list.Count;
        }
    }
}
