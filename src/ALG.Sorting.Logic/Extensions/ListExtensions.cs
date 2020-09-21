using System;
using System.Collections.Generic;

namespace ALG.Sorting.Logic.Extensions
{
    /// <summary>
    /// Contains extension methods for <see cref="List{T}"/>.
    /// </summary>
    internal static class ListExtensions
    {
        /// <summary>
        /// Shuffles the given <paramref name="list"/>.
        /// </summary>
        /// <typeparam name="T">The type of element in <paramref name="list"/>.</typeparam>
        /// <param name="list">The name of the list.</param>
        public static void Shuffle<T>(this List<T> list)
        {
            var rnd = new Random();
            if (list is null) throw new ArgumentNullException(nameof(list));

            var n = list.Count;

            while(n > 1)
            {
                var k = rnd.Next(n--);
                T val = list[k];
                list[k] = list[n];
                list[n] = val;
            }
        }
    }
}
