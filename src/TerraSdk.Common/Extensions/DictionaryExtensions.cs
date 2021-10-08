using System.Collections.Generic;

namespace TerraSdk.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue TryGetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TKey: notnull
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            return default!;
        }
    }
}