using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Interfaces
{
    public interface ITree : ICollection
    {
        void Add(int item);
        bool Contains(int item);
        int[] ToArray();
    }
}
