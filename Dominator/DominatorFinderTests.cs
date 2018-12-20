using System;
using Shouldly;
using Xbehave;
using Xunit;

namespace Dominator
{
    public class DominatorFinderTests : UnitTestBase<DominatorFinder>
    {
        [Scenario]
        public void EmptyArray()
        {
            var sourceArray = new int[0];
            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(-1);
        }

        /*
         * https://app.codility.com/programmers/lessons/8-leader/dominator/
         * dominator is a value that occurs in more than half of the elements in array
         *
         * array can be length 0 to 100,000
         * values in array can be int.Min to int.Max
         *
         * -1 if array has no dominator (interestingly, the dominator could legitimately be the value -1)
         * the dominant value if there is one
         */
    }

    public class DominatorFinder
    {
        public int FindDominator(int[] sourceArray)
        {
            return -1;
        }
    }
}
