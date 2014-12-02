using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransitionRegistry.Helpers
{
    public static class ComparableHelper
    {
        public static T Max<T>(T first, T second)
        {
            if (Comparer<T>.Default.Compare(first, second) > 0)
                return first;
            return second;
        }

        public static T Min<T>(T first, T second)
        {
            if (Comparer<T>.Default.Compare(first, second) > 0)
                return first;
            return second;
        }

        public static T Max<T>(params T[] list)
        {
            T max = list[0];
            for (int i = 1; i < list.Length; i++)
            {
                max = ComparableHelper.Max(max, list[i]);
            }
            return max;
        }

        public static T Min<T>(params T[] list)
        {
            T min = list[0];
            for (int i = 1; i < list.Length; i++)
            {
                min = ComparableHelper.Min(min, list[i]);
            }
            return min;
        }
    }
}