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
                Console.WriteLine($"{e.NameOperation} operation with event. {e.Obj} added");
            else if(e.NameOperation == "Insert")
                Console.WriteLine($"{e.NameOperation} operation with event. {e.Obj} added on {e.Index} index");
            else if (e.NameOperation == "Remove")
                Console.WriteLine($"{e.NameOperation} operation with event. {e.Obj} removed");
            else if (e.NameOperation == "RemoveAt")
                Console.WriteLine($"{e.NameOperation} operation with event. On {e.Index} index removed");
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
