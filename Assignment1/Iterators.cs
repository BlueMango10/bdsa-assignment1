using System;
using System.Collections.Generic;

namespace Assignment1
{
    public static class Iterators
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            throw new NotImplementedException();
            // For each stream
            // For each element
            // Yield return element
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            throw new NotImplementedException();
            // for each item in items
            // if predicate(item)
            //     yield return item
        }
    }
}
