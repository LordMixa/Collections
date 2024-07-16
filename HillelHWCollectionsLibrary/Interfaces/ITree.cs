using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface ITree<T> : ICollection<T>
    {
        void Add(T item);
        bool Contains(T item);
        T[] ToArray();
    }
}
