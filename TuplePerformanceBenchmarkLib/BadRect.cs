using System;
using System.Collections.Generic;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    /// <summary>
    /// A simple rectangle, without Equals and GetHashCode.
    /// </summary>
    public struct BadRect
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public BadRect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
