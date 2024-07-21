using HillelHWCollectionsLibrary.Interfaces;

namespace HillelHWCollectionsLibrary
{
    public class OwnList<T> : Interfaces.IList<T>
    {
        private T[] objects;
        private int count;
        private int capacity;
        public int Count
        {
            get { return count; }
        }
        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= count) throw new IndexOutOfRangeException();
                return objects[i];
            }
            set
            {
                if (i < 0 || i >= count) throw new IndexOutOfRangeException();
                objects[i] = value;
            }
        }
        public OwnList()
        {
            count = 0;
            capacity = 4;
            objects = new T[capacity];
        }
        public OwnList(int capacity)
        {
            count = 0;
            this.capacity = capacity > 0 ? capacity : 4;
            objects = new T[this.capacity];
        }
        private void CheckAndIncreaseCapacity()
        {
            if (count >= capacity)
            {
                capacity *= 2;
                T[] newObjects = new T[capacity];
                for (int i = 0; i < count; i++)
                {
                    newObjects[i] = objects[i];
                }
                objects = newObjects;
            }
        }
        public virtual void Add(T obj)
        {
            CheckAndIncreaseCapacity();
            objects[count] = obj;
            count++;
        }
        public virtual void Insert(int index, T obj)
        {
            if (index < 0 || index > count) throw new IndexOutOfRangeException();
            CheckAndIncreaseCapacity();
            for (int i = count; i > index; i--)
            {
                objects[i] = objects[i - 1];
            }
            objects[index] = obj;
            count++;
        }
        public virtual void Remove(T obj)
        {
            int index = IndexOf(obj);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }
        public virtual void RemoveAt(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            for (int i = index; i < count - 1; i++)
            {
                objects[i] = objects[i + 1];
            }
            count--;
            objects[count] = default!;
        }
        public void Clear()
        {
            capacity = 4;
            objects = new T[capacity];
            count = 0;
        }
        public bool Contains(T obj)
        {
            return IndexOf(obj) != -1;
        }
        public int IndexOf(T obj)
        {
            for (int i = 0; i < count; i++)
            {
                if (objects[i]!.Equals(obj))
                    return i;
            }
            return -1;
        }
        public T[] ToArray()
        {
            T[] array = new T[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = objects[i];
            }
            return array;
        }
        public void Reverse()
        {
            for (int i = 0; i < count / 2; i++)
            {
                T temp = objects[i];
                objects[i] = objects[count - 1 - i];
                objects[count - 1 - i] = temp;
            }
        }
    }
}
