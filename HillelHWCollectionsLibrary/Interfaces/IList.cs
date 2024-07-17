using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface IList<T>:ICollection<T>
    {
        T this[int i] { get; set; }
        void Add(T item);
        void Insert(int index, T obj);
        void Remove(T obj);
        void RemoveAt(int index);
        bool Contains(T obj);
        int IndexOf(T obj);
        T[] ToArray();
        void Reverse();
    }
}
