using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.LinqTasksHW
{
    public static class LinqExtensions
    {
        private class FilterEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerable<T> collection;
            private readonly Predicate<T> predicate;

            public FilterEnumerable(IEnumerable<T> collection, Predicate<T> predicate)
            {
                this.collection = collection;
                this.predicate = predicate;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new FilterEnumerator<T>(collection, predicate);
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class FilterEnumerator<T> : IEnumerator<T>
        {
            private IEnumerator<T> collection;
            private Predicate<T> predicate;

            public FilterEnumerator(IEnumerable<T> collection, Predicate<T> predicate)
            {
                this.collection = collection.GetEnumerator();
                this.predicate = predicate;
            }

            public T Current => collection.Current;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool result = false;
                do
                {
                    result = collection.MoveNext();
                }
                while (result && !predicate(Current));
                return result;
            }

            public void Reset()
            {
            }
        }
        public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count)
        {
            foreach (T item in collection)
            {
                count--;
                if (count >= 0)
                    yield return item;
                else
                    yield break;
            }
        }
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            bool yielding = false;

            foreach (T item in collection)
            {
                if (!yielding && !predicate(item))
                {
                    yielding = true;
                }

                if (!yielding)
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> collection, int skips)
        {
            foreach (T item in collection)
            {
                if (skips > 0)
                    skips--;
                else
                    yield return item;
            }
        }
        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            bool yielding = false;

            foreach (T item in collection)
            {
                if (!yielding && !predicate(item))
                {
                    yielding = true;
                }

                if (yielding)
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            return new FilterEnumerable<T>(collection, predicate);
        }
        public static T First<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (T item in collection)
            {
                if (predicate(item))
                    return item;
            }
            throw new ArgumentNullException();
        }
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (T item in collection)
            {
                if (predicate(item))
                    return item;
            }
            return default!;
        }
        public static T LastOrDefault<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            T result = default!;
            foreach (T item in collection)
            {
                if (predicate(item))
                    result = item;
            }
            return result;
        }
        public static T Last<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            T result = default!;
            bool isValue = false;
            foreach (T item in collection)
            {
                if (predicate(item))
                {
                    isValue = true;
                    result = item;
                }
            }
            if (isValue)
                return result;
            else
                throw new ArgumentNullException();
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> selector)
        {
            foreach (TSource item in collection)
            {
                yield return selector(item);
            }
        }
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (TSource item in collection)
            {
                foreach (TResult subItem in selector(item))
                {
                    yield return subItem;
                }
            }
        }
        public static bool All<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            bool check = true;
            foreach (T item in collection)
            {
                if (!predicate(item))
                    check = false;
            }
            if (check)
                return true;
            else
                return false;
        }
        public static bool Any<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                return true;
            }
            return false;
        }
        public static bool Any<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }
        public static List<T> ToListLinq<T>(this IEnumerable<T> collection)
        {
            return collection.ToList();
        }
        public static T[] ToArrayLinq<T>(this IEnumerable<T> collection)
        {
            return collection.ToArray();
        }
    }
}
