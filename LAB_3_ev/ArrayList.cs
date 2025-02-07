using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3_ev
{
    public class ArrayList: BaseList
    {
        int[] buf;
        int size = 1;

        public ArrayList()
        {
            buf = new int[size];
        }

        private void Expand()
        {
            size *= 2;
            Array.Resize(ref buf, size);
        }

        public override void Add(int value)
        {
            if(count >= size) { Expand(); }
            buf[count] = value;
            count++;
        }

        public override void Clear()
        {
            for(int i = 0; i < count; i++)
            {
                buf[i] = 0;
            }
            count = 0;
        }

        public override void Delete(int pos)
        {
            if (pos < count)
            {
                for (int i = pos; i < count - 1; i++)
                {
                    buf[i] = buf[i + 1];
                }
                count--;
            }
            else if(pos == count - 1 && count > 0)
            {
                buf[pos] = 0;
                count--;
            }
        }

        public override void Insert(int value, int pos)
        {
            if(pos == count && pos == 0) Add(value);
            else if (pos == count) Add(value);
            else if (pos < count)
            {
                count++;
                if(count >= size) Expand();
                for(int i = count - 1; i != pos; i--)
                {
                    buf[i] = buf[i - 1];
                }
                buf[pos] = value;
            }
        }

        public override int this[int i]
        {
            get
            {
                if (i >= count || i < 0) return 0;
                return buf[i];
            }

            set
            {
                if(i >= count || i < 0) return;
                buf[i] = value;
            }
        }

        public override void Show()
        {
            if (count >= 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == count - 1) Console.Write($"{buf[i]}. ");
                    else Console.Write($"{buf[i]}, ");
                }
            }
            else Console.WriteLine("Нет значений в ArrayList");
        }

        protected override BaseList Dummy()
        {
            return new ArrayList();
        }
    }
}
