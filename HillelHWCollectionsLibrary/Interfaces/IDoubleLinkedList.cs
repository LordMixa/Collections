using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface IDoubleLinkedList<T> : ICollection<T>
    {
        T? First { get; }
        T? Last { get; }
        void Add(T data);
        void AddFirst(T data);
        void Insert(int index, T value);
        void Remove(T data);
        void RemoveFirst();
        void RemoveLast();
        bool Contains(T data);
        T[] ToArray();
    }
}
