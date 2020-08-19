using System;
using System.Collections.Generic;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    public class StringPair
    {
        public int Seed { get; }
        public string Item1 => Seed.ToString("N");
        public string Item2 => Seed.ToString("E");

        public StringPair(int seed)
        {
            Seed = seed;
        }

        public void Deconstruct(out string Item1, out string Item2)
        {
            Item1 = this.Item1;
            Item2 = this.Item2;
        }

        public Tuple<string, string> ToTuple()
        {
            return new Tuple<string, string>(Item1, Item2);
        }

        public (string Item1, string Item2) ToValueTuple()
        {
            return (Item1, Item2);
        }

        public KeyValuePair<string, string> ToKeyValuePair()
        {
            return new KeyValuePair<string, string>(Item1, Item2);
        }
    }
}
