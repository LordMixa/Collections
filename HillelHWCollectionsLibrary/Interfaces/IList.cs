using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface IList:ICollection
    {
        object this[int i] { get; set; }
        void Add(object item);
        void Insert(int index, object obj);
        void Remove(object obj);
        void RemoveAt(int index);
        bool Contains(object obj);
        int IndexOf(object obj);
        object[] ToArray();
        void Reverse();
    }
}
