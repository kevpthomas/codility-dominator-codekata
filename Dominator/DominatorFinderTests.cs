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
        
        [Fact]
        public void ThreeValueArrayDifferentValues()
        {
            var aValue = Faker.Random.Int();
            var anotherValue = Faker.Random.IntExcept(except: aValue);
            var sourceArray = new[] {aValue, anotherValue, Faker.Random.IntExcept(except: new [] { aValue, anotherValue})};

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(NoDominator);
        }
        
        [Fact]
        public void ThreeValueArraySameValue()
        {
            var sameValue = Faker.Random.Int();
            var sourceArray = new[] {sameValue, sameValue, sameValue};

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(sameValue);
        }
        
        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(2, 2, 1, 2)]
        [InlineData(2, 1, 2, 2)]
        public void ThreeValueArrayOneValueDifferent(int value1, int value2, int value3, int expected)
        {
            var sourceArray = new[] {value1, value2, value3};

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(expected);
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
