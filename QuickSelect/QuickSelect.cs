/*
MIT No Attribution

Copyright 2025

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;

namespace OctavianOrg.Algo.QuickSelect
{
    public class QuickSelect<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly IPartitionStrategy<T> _partitioner;
        private readonly Random _rand;

        /// <summary>
        /// Construct a QuickSelect object with a default comparer and <see cref="HoarePartitionStrategy{T}"/> partitioner.
        /// </summary>
        public QuickSelect() : this(Comparer<T>.Default, new HoarePartitionStrategy<T>()) { }

        /// <summary>
        /// Construct a QuickSelect object with supplied comparer and <see cref="HoarePartitionStrategy{T}"/> partitioner.
        /// </summary>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        public QuickSelect(IComparer<T> comparer) : this(comparer, new HoarePartitionStrategy<T>()) { }

        /// <summary>
        /// Construct a QuickSelect object with a default comparer and supplied partitioner.
        /// </summary>
        /// <param name="partitioner">
        /// The partitioner.
        /// </param>
        public QuickSelect(IPartitionStrategy<T> partitioner) : this(Comparer<T>.Default, partitioner) { }

        /// <summary>
        /// Construct a QuickSelect object with the supplied comparer and partitioner.
        /// </summary>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        /// <param name="partitioner">
        /// The partitioner.
        /// </param>
        public QuickSelect(IComparer<T> comparer, IPartitionStrategy<T> partitioner)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            if (partitioner == null)
                throw new ArgumentNullException(nameof(partitioner));

            _comparer = comparer;
            _partitioner = partitioner;
            _rand = new Random();
        }

        /// <summary>
        /// Partition the supplied array to select k items based on the supplied comparer. The Kth item will be at offset k-1, while offsets
        /// 0 to k-1 will be the topK or leastK items.
        /// </summary>
        /// <param name="items">
        /// The items for selection. This is modified in-place.
        /// </param>
        /// <param name="k">
        /// The top/least number of items to select.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if items in null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if k<1 or k>items.Count.
        /// </exception>
        public void SelectK(IList<T> items, int k)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (k < 1)
                throw new ArgumentOutOfRangeException("The k parameter must be > 0 AND less than the length of the supplied array.");

            if (k > items.Count)
                throw new ArgumentOutOfRangeException("The k parameter must be > 0 AND less than or equal to the length of the supplied array.");

            if (k == items.Count)
                return;

            k = k - 1;
            int left = 0;
            int right = items.Count - 1;

            while (true)
            {
                if (left == right)
                    return;

                int pivot = _rand.Next(left, right + 1);
                int partResult = _partitioner.Partition(items, left, right, pivot, _comparer);

                // Note that Hoare and Lomuto partitioning results have different meanings. This check works for both.
                if (k <= partResult)
                    right = partResult;
                else
                    left = partResult + 1;
            }
        }
    }
}
