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

        public static Dictionary<T, int> GetInstanceCount<T>(this IEnumerable<T> collection) where T : notnull
        {
            Dictionary<T, int> keyCount = [];
            foreach (T item in collection)
            {
                keyCount[item] = keyCount.GetValueOrDefault(item) + 1;
            }

            return keyCount;
        }
    }
}
