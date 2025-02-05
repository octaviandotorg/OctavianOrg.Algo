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

using System.Collections.Generic;

namespace OctavianOrg.Algo.QuickSelect
{
    public class HoarePartitionStrategy<T> : IPartitionStrategy<T>
    {
        public int Partition(IList<T> items, int left, int right, int pivot, IComparer<T> comparer)
        {
            // swap pivot item with first item
            T pivotValue = items[pivot];
            items[pivot] = items[left];
            items[left] = pivotValue;

            // left index
            int l = left - 1;

            // right index
            int r = right + 1;

            for (;;)
            {
                // Move the left index to the right at least once and while the element at
                // the left index is less than the pivot.
                do
                {
                    ++l;
                } while (comparer.Compare(items[l], pivotValue) < 0);

                // Move the right index to the left at least once and while the element at
                // the right index is greater than the pivot.
                do
                {
                    --r;
                } while (comparer.Compare(items[r], pivotValue) > 0);

                if (l < r)
                {
                    // Swap the elements at the left and right indices
                    T temp = items[r];
                    items[r] = items[l];
                    items[l] = temp;
                }
                else // If the indices crossed, return.
                    return r;
            }
        }
    }
}
