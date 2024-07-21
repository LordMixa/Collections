using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.Observer
{
    public class ObsList<T> : OwnList<T>
    {
        private void OnChanges(Action action, T? obj, int index = -1)
        {
            ListEventsArgs<T> args = new ListEventsArgs<T> { Command = action, Index = index, Obj = obj };
            if (action == Action.Add)
                Console.WriteLine($"{args.Command} operation with event. {args.Obj} added");
            else if (action == Action.Insert)
                Console.WriteLine($"{args.Command} operation with event. {args.Obj} added on {args.Index} index");
            else if (action == Action.Remove)
                Console.WriteLine($"{args.Command} operation with event. {args.Obj} removed");
            else if (action == Action.RemoveAt)
                Console.WriteLine($"{args.Command} operation with event. On {args.Index} index removed");
            Changes?.Invoke(this, args);
        }
        public override void Add(T obj)
        {
            base.Add(obj);
            OnChanges(Action.Add, obj);
        }

        public override void Insert(int index, T obj)
        {
            base.Insert(index, obj);
            OnChanges(Action.Insert, obj, index);
        }

        public override void Remove(T obj)
        {
            base.Remove(obj);
            OnChanges(Action.Remove, obj);
        }

        public override void RemoveAt(int index)
        {
            base.RemoveAt(index);
            OnChanges(Action.RemoveAt, default, index);
        }

        public EventHandler<EventArgs>? Changes;
    }
}
