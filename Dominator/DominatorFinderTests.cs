using System.Linq;
using Shouldly;
using Xunit;

namespace Dominator
{
    public class DominatorFinderTests : UnitTestBase<DominatorFinder>
    {
        [Fact]
        public void EmptyArray()
        {
            var sourceArray = new int[0];
            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(-1);
        }

        [Fact]
        public void SingleValueArray()
        {
            var sourceArray = new[] {Faker.Random.Int()};

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(sourceArray.First());
        }

        /*
         * https://app.codility.com/programmers/lessons/8-leader/dominator/
         * dominator is a value that occurs in more than half of the elements in array
         *
         * array can be length 0 to 100,000
         * values in array can be int.Min to int.Max
         *
         * -1 if array has no dominator (interestingly, the dominator could legitimately be the value -1)
         * -1 if array is empty
         * the value at index 0 if array has length of 1
         * for array of length 2, the value at either index if both are the same, otherwise -1
         *
         * the dominant value if there is one
         */
    }

    public class DominatorFinder
    {
        public int FindDominator(int[] sourceArray)
        {
            if (!sourceArray.Any()) return -1;

            return sourceArray[0];
        }
    }
}
