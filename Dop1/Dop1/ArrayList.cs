using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dop1
{
    internal class ArrayList
    {
        class ArrayList
        {
            int cnt = 0; // pos < cnt if cnt != 0
            int[] buf = null;
            int size = 1;

            public ArrayList()
            {
                buf = new int[size];
            }

            private void Expd()
            {
                size *= 2;
                Array.Resize(ref buf, size);
            }

            public void Add(int val)
            {
                if (cnt >= size) { Expd(); }
                buf[cnt] = val;
                cnt++;

            }
            public void Ins(int val, int pos)
            {
                if (pos == cnt && pos == 0) Add(val);

                else if (pos == cnt) Add(val);

                else if (pos < cnt)
                {
                    cnt++;
                    if (cnt >= size) Expd();

                    for (int i = cnt - 1; i != pos; i--)
                    {
                        buf[i] = buf[i - 1];
                    }
                    buf[pos] = val;
                }
            }
            public void Del(int pos)
            {
                if (pos < cnt)
                {
                    for (int i = pos; i < cnt - 1; i++)
                    {
                        buf[i] = buf[i + 1];
                    }
                    cnt--;
                }

                else if (pos == cnt - 1 && cnt > 0)
                {
                    buf[pos] = 0;
                    cnt--;
                }
            }

            public void Clr()
            {
                for (int i = 0; i < cnt; i++)
                {
                    buf[i] = 0;
                }
                cnt = 0;
            }

            public int Count
            {
                get { return cnt; }
            }

            public int this[int i]
            {
                get
                {
                    if (i >= cnt || i < 0) return 0;

                    return buf[i];
                }

                set
                {
                    if (i >= cnt || i < 0) return;

                    buf[i] = value;
                }
            }

            public void Shw()
            {
                if (cnt >= 0)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (i == cnt - 1) Console.Write($"{buf[i]}. ");
                        else Console.Write($"{buf[i]}, ");
                    }
                }
                else Console.WriteLine("Нет элементов в array листе");
            }
        }
    }
}
