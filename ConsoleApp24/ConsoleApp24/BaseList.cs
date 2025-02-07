using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    public abstract class BaseList<T> where T : IComparable
    {
        protected int count = 0;
        public int Count { get { return count; } }
        protected abstract BaseList<T> Dummy();
        public abstract void Add(T val);
        public abstract void Delete(int pos);
        public abstract void Insert(T val, int pos);
        public abstract void Clear();
        public abstract T this[int i] { get; set; }
        public abstract void Show();
        public abstract void Sort();
        public abstract void SaveToFile(string fileName);
        public abstract void LoadFromFile(string fileName);

        public event EventHandler ChangeEvent;

        protected virtual void OnChange()
        {
            ChangeEvent?.Invoke(this, EventArgs.Empty);
        }

        public BaseList<T> Clone()
        {
            BaseList<T> clone = Dummy();
            for (int i = 0; i < count; i++)
            {
                clone.Add(this[i]);
            }
            return clone;
        }

        public void Assign(BaseList<T> source)
        {
            Clear();
            for (int i = 0; i < source.Count; i++)
            {
                Add(source[i]);
            }
        }

        public void AssignTo(BaseList<T> destination)
        {
            destination.Assign(this);
        }

        public bool IsEqual(BaseList<T> list)
        {
            if (this.Count != list.Count) return false;

            for (int i = 0; i < this.Count; i++)
            {
                if (!this[i].Equals(list[i])) return false;
            }
            return true;
        }
    }
}
