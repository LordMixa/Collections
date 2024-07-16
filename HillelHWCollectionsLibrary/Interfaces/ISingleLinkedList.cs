using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface ISingleLinkedList : ICollection
    {
        object? First { get; }
        object? Last { get; }
        void Add(object data);
        void AddFirst(object data);
        void Insert(int index, object value);
        bool Contains(object data);
        object[] ToArray();
    }
}
