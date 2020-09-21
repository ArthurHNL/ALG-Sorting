using ALG.Sorting.Logic;
using System;
using System.Linq;

namespace ALG.Sorting.Runnable
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var numbers = NumberStream.GetIncrementingIntegerStream().Take(10).ToArray();

            var list = new SortableList(true, numbers);

            Console.WriteLine("Before sorting:");
            PrintList(list);
            Console.WriteLine();

            list.MergeSort();

            Console.WriteLine("After sorting:");
            PrintList(list);
        }

        private static void PrintList(SortableList list)
        {
            for (var i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }
    }
}
