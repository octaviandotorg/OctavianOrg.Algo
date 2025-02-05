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
    public class LomutoPartitionStrategy<T> : IPartitionStrategy<T>
    {      
        public int Partition(IList<T> items, int left, int right, int pivot, IComparer<T> comparer)
        {
            T pivotValue = items[pivot];
            items[pivot] = items[right];
            items[right] = pivotValue;

            int result = left;

            for (int i = left; i < right; ++i)
            {
                if (comparer.Compare(items[i], pivotValue) < 0)
                {
                    T tmp = items[result];
                    items[result] = items[i];
                    items[i] = tmp;
                    ++result;
                }
            }

            T temp = items[right];
            items[right] = items[result];
            items[result] = temp;

            return result;
        }
    }
}
