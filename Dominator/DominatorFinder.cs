using System;
using System.Linq;

namespace Dominator
{
    public class DominatorFinder
    {
        /*
         * https://app.codility.com/programmers/lessons/8-leader/dominator/
         * dominator is a value that occurs in more than half of the elements in array
         */
        public int FindDominator(int[] sourceArray)
        {
            if (!sourceArray.Any()) return -1;
            var dominatorCutoff = sourceArray.Length / 2;

            var counts = (from i in sourceArray
                group i by i
                into result
                select new {Value = result.Key, Count = result.Count()}).ToList();

            var maxCount = counts.Max(x => x.Count);

            if (maxCount <= dominatorCutoff) return -1;

            var dominatorValue = counts.First(x => x.Count == maxCount).Value;

            return Array.IndexOf(sourceArray, dominatorValue);
        }
    }
}