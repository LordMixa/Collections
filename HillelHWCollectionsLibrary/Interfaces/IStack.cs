using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface IStack : ICollection
    {
        void Push(object item);
        object Pop();
        bool Contains(object item);
        object Peek();
        object[] ToArray();
    }
}
