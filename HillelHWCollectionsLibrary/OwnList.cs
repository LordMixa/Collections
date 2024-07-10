using HillelHWCollectionsLibrary.Interfaces;

namespace HillelHWCollectionsLibrary
{
    public class OwnList : IList
    {
        private object[] objects;
        private int count;
        private int capacity;
        public int Count
        {
            get { return count; }
        }
        public object this[int i]
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
            objects = new object[capacity];
        }
        public OwnList(int capacity)
        {
            count = 0;
            this.capacity = capacity > 0 ? capacity : 4;
            objects = new object[this.capacity];
        }
        private void CheckAndIncreaseCapacity()
        {
            if (count >= capacity)
            {
                capacity *= 2;
                object[] newObjects = new object[capacity];
                for (int i = 0; i < count; i++)
                {
                    newObjects[i] = objects[i];
                }
                objects = newObjects;
            }
        }
        public void Add(object obj)
        {
            CheckAndIncreaseCapacity();
            objects[count] = obj;
            count++;
        }
        public void Insert(int index, object obj)
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
        public void Remove(object obj)
        {
            int index = IndexOf(obj);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            for (int i = index; i < count - 1; i++)
            {
                objects[i] = objects[i + 1];
            }
            count--;
            objects[count] = null!;
        }
        public void Clear()
        {
            capacity = 4;
            objects = new object[capacity];
            count = 0;
        }
        public bool Contains(object obj)
        {
            return IndexOf(obj) != -1;
        }
        public int IndexOf(object obj)
        {
            for (int i = 0; i < count; i++)
            {
                if (objects[i].Equals(obj))
                    return i;
            }
            return -1;
        }
        public object[] ToArray()
        {
            object[] array = new object[count];
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
                object temp = objects[i];
                objects[i] = objects[count - 1 - i];
                objects[count - 1 - i] = temp;
            }
        }
    }
}
