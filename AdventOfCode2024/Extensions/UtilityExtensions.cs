namespace AdventOfCode2024.Extensions
{
    public static class UtilityExtensions
    {
        /// <summary>
        /// Gets a index/value tuple of the items in a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IEnumerable<(int Index, T Value)> Enumerate<T>(this IEnumerable<T> collection)
        {
            return collection.Select((i, index) => (index, i));
        }

        /// <summary>
        /// Gets a dictionary of how many times each value appears in a collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static Dictionary<T, int> GetInstanceCount<T>(this IEnumerable<T> collection) where T : notnull
        {
            Dictionary<T, int> keyCount = [];
            foreach (T item in collection)
            {
                keyCount[item] = keyCount.GetValueOrDefault(item) + 1;
            }

            return keyCount;
        }

        /// <summary>
        /// Converts a string to an int.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
    }
}
