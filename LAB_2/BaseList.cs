using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2
{
    public abstract class BaseList
    {
        protected int count = 0;
        protected abstract BaseList Dummy();
        public int Count { get { return count; } }
        public abstract void Add(int val);
        /*public abstract void Reverse();*/
        public abstract void Delete(int pos);
        public abstract void Insert(int val, int pos);
        public abstract void Clear();
        public abstract int this[int i] { set; get; }
        public abstract void Show();
        public void Reverse() 
        {
            BaseList clone = this.Clone();

            {
                for(int i = this.Count; i >= 0; i--) 
                {
                    clone[Count - i] = this[i];
                }
                this.Assign(clone);
                
            }
        }

        public void Assign(BaseList source)
        {
            Clear();
            for (int i = 0; i < source.Count; i++) Add(source[i]);
        }
        public void AssignTo(BaseList dest)
        {
            dest.Assign(this);
        }
        public BaseList Clone()
        {
            BaseList clone = Dummy();
            clone.Assign(this);
            return clone;
        }
        public virtual void Sort()
        {
            if (this.Count == 0 || this.Count == 1) { return; }

            int pstn = 0;
            while (pstn < this.Count - 1)
            {
                if (this[pstn] >= this[pstn + 1])
                {
                    pstn++;
                }

                else
                {
                    (this[pstn + 1], this[pstn]) = (this[pstn], this[pstn + 1]);

                    if (pstn > 0) pstn--;
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(this[i] + " ");
            }
            Console.WriteLine();
        }
        public bool IsEqual(BaseList list)
        {
            if (this.Count > 0)
            {
                for (int i = 0; i <= this.Count; i++)
                {
                    if (this[i] != list[i]) return false;
                }
                return true;
            }
            else if (this.Count == 0) return true;
            else return false;
        }

    }
}
