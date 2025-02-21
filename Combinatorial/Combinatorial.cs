using System;

namespace OctavianOrg.Algo
{
    public static class Combinatorial
    {
        /// <summary>
        /// Generate a lexicographic permutation of array. This is based on Algorithm L, section 7.2.1.2 in Knuth's
        /// The Art of Computer Programming Volume A Part 1.
        /// </summary>
        /// <typeparam name="T">
        /// The type, which needs to implement IComparable.
        /// </typeparam>
        /// <param name="arr">
        /// The array to use for generating all permutations. To generate all permutations the array must start
        /// in sorted order, otherwise the next lexicographic permutation will be returned.
        /// </param>
        /// <returns>
        /// True if the next permutation has been generated in arr, false if all permutations have been exhausted.
        /// </returns>
        public static bool Permute<T>(T[] arr) where T : IComparable
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            if (arr.Length < 2)
                return false;

            int j = arr.Length - 2;

            while (arr[j].CompareTo(arr[j + 1]) >= 0)
                if (--j == -1)
                    return false;

            int l = arr.Length - 1;

            while (arr[j].CompareTo(arr[l]) >= 0)
                --l;

            T tmp = arr[j];
            arr[j] = arr[l];
            arr[l] = tmp;

            int k = j + 1;
            l = arr.Length - 1;

            while (k < l)
            {
                tmp = arr[k];
                arr[k] = arr[l];
                arr[l] = tmp;
                ++k;
                --l;
            }

            return true;
        }
    }
}
