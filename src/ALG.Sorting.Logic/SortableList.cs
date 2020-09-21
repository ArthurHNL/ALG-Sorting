using ALG.Sorting.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ALG.Sorting.Logic
{
    /// <summary>
    /// Represents a sortable list.
    /// </summary>
    public class SortableList : AbstractSortableList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSortableList"/> class.
        /// </summary>
        /// <param name="isRandom">A value indicating whether the list should be shuffled when created.</param>
        /// <param name="content">The contents.</param>
        public SortableList(bool isRandom, params int[] content) : base(isRandom, content)
        {
        }

        /// <inheritdoc />
        public override void MergeSort()
        {
            var list = new List<int>(this.Count);

            for (var i = 0; i < this.Count; i++)
            {
                list.Add(this[i]);
            }

            var sorted = SortableList.MergeSort(list);

            for (var i = 0; i < this.Count; i++)
            {
                this[i] = sorted[i];
            }
        }

        private static List<int> MergeSort(List<int> list)
            => list.Count switch
            {
                var x when x <= 1 => list,
                _ => SortableList.MergeSortMoreThenOneElement(list),
            };

        private static List<int> MergeSortMoreThenOneElement(List<int> list)
        {
            var (left, right) = SortableList.DivideList(list);
            var leftSorted = SortableList.MergeSort(left);
            var rightSorted = SortableList.MergeSort(right);
            return Merge(leftSorted, rightSorted);
        }

        private static (List<int> left, List<int> right) DivideList(List<int> list)
        {
            var capacityLeft = Convert.ToInt32(Math.Floor(list.Count / 2d));
            var capacityRight = Convert.ToInt32(Math.Ceiling(list.Count / 2d));
            var middleIndex = list.Count / 2;
            var left = new List<int>(capacityLeft);
            var right = new List<int>(capacityRight);

            for (var i = 0; i < middleIndex; i++)
            {
                left.Add(list[i]);
            }

            for (var i = middleIndex; i < list.Count; i++)
            {
                right.Add(list[i]);
            }

            return (left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            var capacity = left.Count + right.Count;
            var result = new List<int>(capacity);

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return result;
        }
    }
}
