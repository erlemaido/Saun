using System;

namespace Aids.Reflection {
    public static class Sort 
    {

        public static void Upwards<T>(ref T min, ref T max) where T : IComparable 
        {
            if (min.CompareTo(max) <= 0) return;
            var d = min;
            min = max;
            max = d;
        }
    }
}
