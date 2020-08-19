using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    public class BenchmarkExecuter
    {
        public static readonly string Banner1 = new string('#', 120);
        public static readonly string Banner2 = new string('=', 120);
        public static readonly string Banner3 = new string('-', 120);
        public static readonly string Banner4 = new string('.', 120);

        public Type TestClassType { get; }

        public dynamic Tests { get; set; }

        public string ApplicationName
        {
            get
            {
                var maybeApplicationName = Assembly.GetEntryAssembly()
                    ?.GetName()
                    ?.FullName;
                return maybeApplicationName ?? "Unknown";
            }
        }

        public string RuntimeFrameworkName
        {
            get
            {
                var maybeFrameworkName = Assembly.GetEntryAssembly()
                    ?.GetCustomAttribute<TargetFrameworkAttribute>()
                    ?.FrameworkName;
                return maybeFrameworkName ?? "Unknown";
            }
        }

        public BenchmarkExecuter(Type testClassType)
        {
            TestClassType = testClassType;
            Tests = Activator.CreateInstance(testClassType);
        }

        public void Execute()
        {
            Console.WriteLine(Banner2);
            Console.WriteLine($"Application Name: {ApplicationName}");
            Console.WriteLine($"Runtime Framework Name: {RuntimeFrameworkName}");
            Console.WriteLine(Banner3);
            Console.WriteLine($"Test class: {TestClassType.Name}");
            Console.WriteLine($"(Fully qualified name: {TestClassType.FullName})");
            Console.WriteLine(Banner4);

            Benchmarker.TimedCall("PassTo", Tests.ThisPassTo);

            Benchmarker.TimedCall("ReturnFrom", Tests.ThisReturnFrom);

            Benchmarker.TimedCall("PassBetween", Tests.ThisPassBetween);

            Benchmarker.TimedCall("FillListValue", Tests.ThisFillListValue);

            Benchmarker.TimedCall("FillListGen", Tests.ThisFillListGen);

            Benchmarker.TimedCall("CopyList", Tests.ThisCopyList);

            Benchmarker.TimedCall("ForEachGetHashCode", Tests.ThisForEachGetHashCode);

            Benchmarker.TimedCall("FindAndCall", Tests.ThisFindAndCall);

            Console.WriteLine(Banner4);
            Console.WriteLine($"(This value can be ignored: {Tests.Long})");
            Console.WriteLine($"(This value can be ignored: {Tests.ListResult?.Count ?? -1})");
            Console.WriteLine(Banner2);
        }
    }
}
