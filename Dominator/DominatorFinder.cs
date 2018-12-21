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

            var counts = (from i in sourceArray
                group i by i
                into result
                select new {Value = result.Key, Count = result.Count()}).ToList();

            var maxCount = counts.Max(x => x.Count);

            return maxCount == 1 && maxCount != sourceArray.Length
                ? -1 
                : counts.First(x => x.Count == maxCount).Value;
        }
    }
}