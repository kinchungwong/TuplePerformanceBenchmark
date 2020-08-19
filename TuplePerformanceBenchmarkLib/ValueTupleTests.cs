using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    public class ValueTupleTests<T1, T2>
    {
        public Func<int, ValueTuple<T1, T2>> Get { get; set; }

        public Action<ValueTuple<T1, T2>> Sink { get; set; }

        public Action<List<ValueTuple<T1, T2>>> ListSink { get; set; }

        public List<ValueTuple<T1, T2>> ListResult { get; set; }

        public long Long { get; set; }

        public void HashCodeSink(int hashCode)
        {
            Long += hashCode;
        }

        public ValueTuple<T1, T2> ItemToFind => Get(Constants.LoopCount - 1);

        public Action ThisPassTo => () => PassTo(Get, Sink);

        public Action ThisReturnFrom => () => ReturnFrom(Get, Sink);

        public Action ThisPassBetween => () => PassBetween(Get, Sink);

        public Action ThisFillListValue => () => FillListValue(Get, ListSink);

        public Action ThisFillListGen => () => FillListGen(Get, ListSink);

        public Action ThisCopyList => () => CopyList(ListResult, ListSink);

        public Action ThisForEachGetHashCode => () => ForEachGetHashCode(ListResult, HashCodeSink);

        public Action ThisFindAndCall => () => FindAndCall(ListResult, ItemToFind, Sink);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PassTo(Func<int, ValueTuple<T1, T2>> func, Action<ValueTuple<T1, T2>> action)
        {
            ValueTuple<T1, T2> value = func(Constants.LoopCount - 1);
            for (int k = 0; k < Constants.LoopCount; ++k)
            {
                action(value);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ReturnFrom(Func<int, ValueTuple<T1, T2>> func, Action<ValueTuple<T1, T2>> action)
        {
            ValueTuple<T1, T2> value = default;
            for (int k = 0; k < Constants.LoopCount; ++k)
            {
                value = func(k);
            }
            // The next line is to ensure the value is not eliminated.
            action(value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void PassBetween(Func<int, ValueTuple<T1, T2>> func, Action<ValueTuple<T1, T2>> action)
        {
            for (int k = 0; k < Constants.LoopCount; ++k)
            {
                action(func(k));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void FillListValue(Func<int, ValueTuple<T1, T2>> func, Action<List<ValueTuple<T1, T2>>> action)
        {
            ValueTuple<T1, T2> value = func(Constants.LoopCount - 1);
            List<ValueTuple<T1, T2>> list = new List<ValueTuple<T1, T2>>(capacity: Constants.LoopCount);
            for (int k = 0; k < Constants.LoopCount; ++k)
            {
                list.Add(value);
            }
            // The next line is to ensure the list is not eliminated.
            action(list);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void FillListGen(Func<int, ValueTuple<T1, T2>> func, Action<List<ValueTuple<T1, T2>>> action)
        {
            List<ValueTuple<T1, T2>> list = new List<ValueTuple<T1, T2>>(capacity: Constants.LoopCount);
            for (int k = 0; k < Constants.LoopCount; ++k)
            {
                list.Add(func(k));
            }
            // The next line is to ensure the list is not eliminated.
            action(list);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CopyList(List<ValueTuple<T1, T2>> list, Action<List<ValueTuple<T1, T2>>> action)
        {
            List<ValueTuple<T1, T2>> list2 = new List<ValueTuple<T1, T2>>(capacity: list.Count);
            foreach (var tup in list)
            {
                list2.Add(tup);
            }
            // The next line is to ensure the list is not eliminated.
            action(list2);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ForEachGetHashCode(List<ValueTuple<T1, T2>> list, Action<int> action)
        {
            foreach (var tup in list)
            {
                action(tup.GetHashCode());
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void FindAndCall(List<ValueTuple<T1, T2>> list, ValueTuple<T1, T2> target, Action<ValueTuple<T1, T2>> callIfEqual)
        {
            foreach (var tup in list)
            {
                if (tup.Equals(target))
                {
                    callIfEqual(tup);
                }
            }
        }
    }
}
