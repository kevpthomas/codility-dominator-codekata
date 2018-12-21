using System.Linq;
using Shouldly;
using Xunit;

namespace Dominator
{
    public class DominatorFinderTests : UnitTestBase<DominatorFinder>
    {
        private const int NoDominator = -1;

        [Fact]
        public void EmptyArray()
        {
            var sourceArray = new int[0];

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(NoDominator);
        }

        [Fact]
        public void SingleValueArray()
        {
            var sourceArray = new[] {Faker.Random.Int()};

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(sourceArray.First());
        }

        [Fact]
        public void TwoValueArrayDifferentValue()
        {
            var aValue = Faker.Random.Int();
            var sourceArray = new[] {aValue, Faker.Random.IntExcept(except: aValue)};

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(NoDominator);
        }

        [Fact]
        public void TwoValueArraySameValue()
        {
            var sameValue = Faker.Random.Int();
            var sourceArray = new[] { sameValue, sameValue };

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(sameValue);
        }

        /*
         * https://app.codility.com/programmers/lessons/8-leader/dominator/
         * dominator is a value that occurs in more than half of the elements in array
         *
         * array can be length 0 to 100,000
         * values in array can be int.Min to int.Max
         *
         * -1 if array has no dominator (interestingly, the dominator could legitimately be the value -1)
         *
         * the dominant value if there is one
         */
    }

    public class DominatorFinder
    {
        public int FindDominator(int[] sourceArray)
        {
            if (!sourceArray.Any()) return -1;

            if (sourceArray.Length == 2 && sourceArray[0] != sourceArray[1]) return -1;

            return sourceArray[0];
        }
    }
}
