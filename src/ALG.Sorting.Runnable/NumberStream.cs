using System.Collections.Generic;

namespace ALG.Sorting.Runnable
{
    /// <summary>
    /// Contains helper methods to get a stream of numbers.
    /// </summary>
    public static class NumberStream
    {
        /// <summary>
        /// Gets a stream of non-negative incrementing integers.
        /// </summary>
        /// <returns>A stream of non-negative incrementing integers. </returns>
        public static IEnumerable<int> GetIncrementingIntegerStream()
        {
            var n = 0;

            while (n < int.MaxValue)
                yield return n++;
        }
    }
}
