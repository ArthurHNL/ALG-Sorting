using ALG.Sorting.Logic.Extensions;
using System.Collections.Generic;

namespace ALG.Sorting.Logic.Abstractions
{
    /// <summary>
    /// Represents a sortable list.
    /// </summary>
    public abstract class AbstractSortableList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSortableList"/> class.
        /// </summary>
        /// <param name="isRandom">A value indicating whether the list should be shuffled when created.</param>
        /// <param name="content">The content of the list.</param>
        public AbstractSortableList(bool isRandom, params int[] content)
        {
            this.Contents = new List<int>(content);

            if (isRandom)
                this.Contents.Shuffle();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSortableList"/> with the given <paramref name="capacity"/>.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public AbstractSortableList(int capacity)
        {
            this.Contents = new List<int>(new int[capacity]);
        }

        /// <summary>
        /// Gets the list containing the values.
        /// </summary>
        private List<int> Contents { get; }

        /// <summary>
        /// Gets or sets the element at <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The value at <paramref name="index"/>.</returns>
        public int this[int index]
        {
            get => this.Contents[index];
            set => this.Contents[index] = value;
        }
        
        /// <summary>
        /// Gets the number of elements in this <see cref="AbstractSortableList"/>.
        /// </summary>
        public int Count => this.Contents.Count;

        /// <summary>
        /// Appends an item to the end of this <see cref="AbstractSortableList"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Add(int value) => this.Contents.Add(value);

        /// <summary>
        /// Removes the item at the given index.
        /// </summary>
        /// <param name="index">The index.</param>
        public void DeleteAt(int index) => this.Contents.RemoveAt(index);

        /// <summary>
        /// Gets the first index of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The index, or when <paramref name="value"/> could not be found, -1.</returns>
        public int IndexOf(int value) => this.Contents.IndexOf(value);

        /// <summary>
        /// Sorts the list using the mergesort algorithm.
        /// </summary>
        public abstract void MergeSort();
    }
}
