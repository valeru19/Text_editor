using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_2
{
    public class ArrList : BaseList
    {
        int[] buf;
        int size = 1;

        public ArrList()
        {
            buf = new int[size];
        }

        private void Expd()
        {
            size *= 2;
            Array.Resize(ref buf, size);
        }

        public override void Add(int val)
        {
            if (count >= size) { Expd(); }
            buf[count] = val;
            count++;

        }
        /*public override void Reverse()
        {
            for(int i = count; i >= 0; i--)
            {
                Console.WriteLine(i);
            }
        }*/
        public override void Insert(int val, int pos)
        {
            if (pos == count && pos == 0) Add(val);

            else if (pos == count) Add(val);

            else if (pos < count)
            {
                count++;
                if (count >= size) Expd();

                for (int i = count - 1; i != pos; i--)
                {
                    buf[i] = buf[i - 1];
                }
                buf[pos] = val;
            }
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

            else if (pos == count - 1 && count > 0)
            {
                buf[pos] = 0;
                count--;
            }
        }

        public override void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                buf[i] = 0;
            }
            count = 0;
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
                if (i >= count || i < 0) return;

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
            else Console.WriteLine("Нет элементов в array листе");
        }
        protected override BaseList Dummy()
        {
            return new ArrList();
        }
    }
}
