using ALG.Sorting.Logic.Abstractions;
using FluentAssertions;
using System;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace ALG.Sorting.Test.Logic.Abstractions
{
    /// <summary>
    /// Contains tests for <see cref="AbstractSortableList"/>.
    /// </summary>
    public class AbstractSortableListTest
    {
        private readonly ImmutableList<int> sequence = ImmutableList.Create(1, 2, 3, 4, 5, 6);

        [Fact]
        public void Index_ValidIndex_ReturnsExpectedValue()
        {
            // Arrange
            var list = new TestableList(isRandom: false, content: sequence.ToArray());

            // Act & Assert
            for (var i = 0; i < sequence.Count; i++)
            {
                list[i].Should().Be(sequence[i], because: "this is the value at the index of the original sequence and the list was not shuffled");
            }
        }

        [Fact]
        public void Index_Set_Get_ReturnsSetValue()
        {
            // Arrange
            var value = 2;
            var size = 10;
            var list = new TestableList(capacity: size);
            var index = 2;

            // Act
            list[index] = value;

            // Assert
            list[index].Should().Be(value, because: "this is the value that the value was set to");
        }

        [Fact]
        public void Count_Get_ReturnsCount()
        {
            // Arrange
            var list = new TestableList(isRandom: true, this.sequence.ToArray());

            // Act & Assert
            list.Count.Should().Be(sequence.Count, because: "this is the count of the sequence passed on construction");
        }

        [Fact]
        public void Add_Add_AppendsToBottom()
        {
            // Arrange
            var list = new TestableList(isRandom: false, this.sequence.ToArray());
            var value = 348;
            var indexOfAddedItem = sequence.Count; // Append after sequence so index of added item should be count of the index.

            // Act
            list.Add(value);

            // Assert
            list[indexOfAddedItem].Should().Be(value, because: "this was the added value");
        }

        [Fact]
        public void DeleteAt_Delete_RemovesItem()
        {
            // Arrange
            var list = new TestableList(isRandom: false, this.sequence.ToArray());
            var index = this.sequence.Count / 2;
            var deletedValue = this.sequence[index];

            // Act
            list.DeleteAt(index);

            // Assert
            list[index].Should().NotBe(deletedValue, because: "this item was deleted");
        }

        [Fact]
        public void IndexOf_Get_ReturnsCorrectIndex()
        {
            // Arrange
            var list = new TestableList(isRandom: false, this.sequence.ToArray());
            var index = this.sequence.Count / 2;
            var value = this.sequence[index];

            // Act & Assert
            list.IndexOf(value).Should().Be(index, because: "this was the index of the value when passed to the constructor");
        }

        [Fact]
        public void MergeSortOfStub_Sort_ThrowsNotImplementedException()
        {
            // Arrange
            var list = new TestableList(isRandom: false, this.sequence.ToArray());

            // Act & Assert
            list.Invoking(l => l.MergeSort()).Should().Throw<NotImplementedException>();
        }

        private class TestableList : AbstractSortableList
        {
            public TestableList(bool isRandom, params int[] content) : base(isRandom, content)
            { 
            }

            public TestableList(int capacity) : base(capacity)
            {
            }

            public override void MergeSort()
            {
                throw new NotImplementedException();
            }
        }
    }
}
