using System;

namespace MyLists
{
    public class DynamicList<T> : BaseList<T> where T : IComparable<T>
    {
        private T[] buffer;
        private int count;

        public DynamicList()
        {
            buffer = new T[4];
            count = 0;
        }

        public override int Count => count;

        public override void Add(T item)
        {
            if (count == buffer.Length)
            {
                Resize(buffer.Length * 2);
            }
            buffer[count++] = item;
            OnChange(EventArgs.Empty); //1
        }

        public override void Insert(int pos, T item)
        {
            if (pos < 0 || pos > count)
            {
                throw new BadIndexException("Position is out of range");
            }

            if (count == buffer.Length)
            {
                Resize(buffer.Length * 2);
            }

            for (int i = count; i > pos; i--)
            {
                buffer[i] = buffer[i - 1];
            }

            buffer[pos] = item;
            count++;
            OnChange(EventArgs.Empty); //2
        }

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                throw new BadIndexException("Position is out of range");
            }

            for (int i = pos; i < count - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }

            count--;
            OnChange(EventArgs.Empty); //3
        }

        public override void Clear()
        {
            buffer = new T[4];
            count = 0;
            OnChange(EventArgs.Empty); //4
        }

        public override T this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
                }
                return buffer[i];
            }
            set
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
                }
                buffer[i] = value;
                OnChange(EventArgs.Empty); //5
            }
        }

        protected override BaseList<T> CloneInternal()
        {
            DynamicList<T> clone = new DynamicList<T>();
            clone.buffer = new T[buffer.Length];
            Array.Copy(buffer, clone.buffer, count);
            clone.count = count;
            return clone;
        }

        private void Resize(int newSize)
        {
            T[] newBuffer = new T[newSize];
            Array.Copy(buffer, newBuffer, count);
            buffer = newBuffer;
        }


    }
}