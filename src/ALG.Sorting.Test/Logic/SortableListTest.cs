using ALG.Sorting.Logic;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Xunit;

namespace ALG.Sorting.Test.Logic
{
    /// <summary>
    /// Contains tests for the <see cref="SortableList"/> class.
    /// </summary>
    public class SortableListTest
    {
        private readonly ImmutableList<int> sequence = ImmutableList.Create(1, 2, 3, 4, 5, 6);

        [Fact]
        public void MergeSort_Sort_IsSorted()
        {
            // Arrange
            var shuffledList = new SortableList(isRandom: true, content: sequence.ToArray());

            // Act
            shuffledList.MergeSort();

            // Assert
            // Because the SortedList class does not implement ICollection or IEnumerable, comparison must be done by hand.
            for (var i = 0; i < sequence.Count; i++)
                shuffledList[i].Should().Be(sequence[i], because: "the list should be sorted and the original list was sorted");
        }
    }
}
