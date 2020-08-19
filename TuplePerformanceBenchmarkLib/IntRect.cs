using System;
using System.Collections.Generic;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    public class IntRect
    {
        public int Index { get; }
        public GoodRect Rect { get; }

        public IntRect(int index)
        {
            Index = index;
            Rect = new GoodRect(-index, -index - 1, index + 1, index + 2);
        }

        public void Deconstruct(out int Index, out GoodRect Rect)
        {
            Index = this.Index;
            Rect = this.Rect;
        }

        public Tuple<int, GoodRect> ToTuple()
        {
            return new Tuple<int, GoodRect>(Index, Rect);
        }

        public (int Index, GoodRect Rect) ToValueTuple()
        {
            return (Index, Rect);
        }

        public KeyValuePair<int, GoodRect> ToKeyValuePair()
        {
            return new KeyValuePair<int, GoodRect>(Index, Rect);
        }
    }
}
