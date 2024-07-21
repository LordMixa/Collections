using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Observer
{
    public class ListEventsArgs<T> : EventArgs
    {
        public T? Obj { get; init; }
        public int Index { get; init; }
        public Action Command { get; init; }
    }
}
