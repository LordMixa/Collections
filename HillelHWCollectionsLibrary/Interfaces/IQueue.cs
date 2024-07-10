using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface IQueue : ICollection
    {
        void Enqueue(object item);
        object Dequeue();
        bool Contains(object item);
        object Peek();
        object[] ToArray();
    }
}
