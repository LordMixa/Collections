using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface ISingleLinkedList<T> : ICollection<T>
    {
        T? First { get; }
        T? Last { get; }
        void Add(T data);
        void AddFirst(T data);
        void Insert(int index, T value);
        bool Contains(T data);
        T[] ToArray();
    }
}
