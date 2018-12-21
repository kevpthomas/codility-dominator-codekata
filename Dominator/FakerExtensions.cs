using System.Linq;
using Bogus;

namespace Dominator
{
    public static class FakerExtensions
    {
        public static int IntExcept(this Randomizer randomizer, int min = int.MinValue, int max = int.MaxValue, params int[] except)
        {
            var value = randomizer.Int(min, max);

            while (except.Contains(value))
            {
                value = randomizer.Int(min, max);
            }

            return value;
        }
    }
}