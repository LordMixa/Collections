using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary
{
    public class ObsList<T> : OwnList<T>
    {
        public event EventHandler<EventArgs>? Changes;
        public event EventHandler<EventArgs>? ItemAdded;
        public event EventHandler<EventArgs>? ItemInserted;
        public event EventHandler<EventArgs>? ItemRemoved;
        protected virtual void OnChanges(ListEventsArgs<T> e)
        {
            if(e.NameOperation=="Add")
                Console.WriteLine("Add operation with event");
            else if(e.NameOperation == "Insert")
                Console.WriteLine("Insert operation with event");
            else if (e.NameOperation == "Remove")
                Console.WriteLine("Remove operation with event");
            else if (e.NameOperation == "RemoveAt")
                Console.WriteLine("RemoveAt operation with event");
            Changes?.Invoke(this, e);
        }
        public override void Add(T obj)
        {
            base.Add(obj);
            OnChanges(new ListEventsArgs<T> { Obj = obj, NameOperation = MethodBase.GetCurrentMethod()?.Name });
        }

        public override void Insert(int index, T obj)
        {
            base.Insert(index, obj);
            OnChanges(new ListEventsArgs<T> { Obj = obj, Index = index, NameOperation = MethodBase.GetCurrentMethod()?.Name });
        }

        public override void Remove(T obj)
        {
            base.Remove(obj);
            OnChanges(new ListEventsArgs<T> { Obj = obj, NameOperation = MethodBase.GetCurrentMethod()?.Name });
        }

        public override void RemoveAt(int index)
        {
            base.RemoveAt(index);
            OnChanges(new ListEventsArgs<T> { Index = index, NameOperation = MethodBase.GetCurrentMethod()?.Name });
        }
    }
}
