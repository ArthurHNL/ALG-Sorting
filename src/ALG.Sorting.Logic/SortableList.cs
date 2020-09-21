using ALG.Sorting.Logic.Abstractions;
using System;

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
            throw new NotImplementedException();
        }
    }
}
