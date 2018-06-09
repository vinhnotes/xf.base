using System;
using System.Collections;
using System.Collections.Generic;

namespace BaseProject.Commons.Extensions
{
    public static class CollectionExtension
    {
        public static void Push<T>(this IList<T> collection, T data)
        {
            if (data != null)
            {
                collection.Add(data);
            }
        }

        public static T Peek<T>(this IList<T> collection)
        {
            if (collection.Count > 0)
            {
                var t = collection[collection.Count - 1];
                return t;
            }
            return default(T);
        }

        public static T Pop<T>(this IList<T> collection)
        {
            if (collection.Count > 0)
            {
                var t = collection[collection.Count - 1];
                collection.RemoveAt(collection.Count - 1);
                return t;
            }
            return default(T);
        }

        public static T ElementAtOrDefault<T>(this IList<T> collection, int index)
        {
            if (index >= 0 && index < collection.Count)
            {
                return collection[index];
            }
            return default(T);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Add<T>(this ICollection<T> collection, ICollection data)
        {
            if (data != null)
            {
                foreach (T item in data)
                {
                    collection.Add(item);
                }
            }

        }

    }
}
