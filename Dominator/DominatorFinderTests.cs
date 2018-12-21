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
        
        [Theory]
        [InlineData(3, 4, 3, 2, 3, -1, 3, 3, 3)]
        public void EightValueArrayExample(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int expected)
        {
            var sourceArray = new[] {value1, value2, value3, value4, value5, value6, value7, value8};

            var dominator = TestInstance.FindDominator(sourceArray);

            dominator.ShouldBe(expected);
        }
    }
}
