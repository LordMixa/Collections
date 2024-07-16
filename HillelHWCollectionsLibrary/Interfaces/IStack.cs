using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface IStack<T> : ICollection<T>
    {
        void Push(T item);
        T Pop();
        bool Contains(T item);
        T Peek();
        T[] ToArray();
    }
}
