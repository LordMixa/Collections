using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface ICollection<T> : IEnumerable<T>
    {
        int Count { get; }
        void Clear();
    }
}
