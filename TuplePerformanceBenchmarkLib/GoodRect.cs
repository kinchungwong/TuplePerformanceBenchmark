using System;
using System.Collections.Generic;
using System.Text;

namespace TuplePerformanceBenchmarkLib
{
    /// <summary>
    /// A simple rectangle, with Equals and GetHashCode.
    /// </summary>
    public struct GoodRect
        : IEquatable<GoodRect>
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public GoodRect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case GoodRect other:
                    return Equals(other);
                default:
                    return false;
            }
        }

        public bool Equals(GoodRect other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }

        public override int GetHashCode()
        {
            // ======
            // https://lemire.me/blog/2018/08/15/fast-strongly-universal-64-bit-hashing-everywhere/
            // ======
            const uint Mask16 = 65535u;
            unchecked
            {
                ulong value = (ulong)(X & Mask16) | ((ulong)(Y & Mask16) << 16) |
                    ((ulong)(Width & Mask16) << 32) | ((ulong)(Height & Mask16) << 48);
                value ^= value >> 33;
                value *= 0xff51afd7ed558ccdL;
                value ^= value >> 33;
                value *= 0xc4ceb9fe1a85ec53L;
                value ^= value >> 33;
                return (int)(uint)value;
            }
        }
    }
}
