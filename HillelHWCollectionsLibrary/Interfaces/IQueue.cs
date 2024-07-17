using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface IQueue<T> : ICollection<T>
    {
        void Enqueue(T item);
        T Dequeue();
        bool Contains(T item);
        T Peek();
        T[] ToArray();
    }
}
