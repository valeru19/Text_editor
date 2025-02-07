using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dop1
{
    internal class LinkedList
    {
        public class ChainList
        {
            public class Node
            {
                public int Data
                {
                    set; get;
                }
                public Node Next
                {
                    set; get;
                }
                public Node(int data)
                {
                    Data = data;
                    Next = null;
                }
            }

            Node head = null;
            int count = 0; // pos < cnt if head != null

            public Node Find(int posit)
            {
                if (posit >= count || head == null) return null; //if no el rtrn nthng

                int i = 0;
                Node P = head;

                while (P != null && i < posit)
                {
                    P = P.Next;
                    i++;
                }

                if (i == posit) return P;
                else return null;
            }
            public void Addit(int value)
            {
                if (head == null)
                {
                    head = new Node(value);
                }

                else
                {
                    Node last = Find(count - 1);
                    last.Next = new Node(value);

                }
                count++;
            }
            public void Insert(int value, int posit)
            {
                if (posit == count && posit == 0) Addit(value);

                else if (posit == count) Addit(value);

                else if (posit < count)
                {
                    if (posit == 0)
                    {
                        head = new Node(value) { Next = head };
                        count++;
                    }

                    else
                    {
                        Node prev = Find(posit - 1);
                        Node curr = Find(posit);
                        Node insr = new Node(value) { Next = curr };
                        prev.Next = insr;
                        count++;
                    }
                }
            }
            public void Delete(int posit)
            {
                if (posit < count && posit > 0)
                {
                    Node prev = Find(posit - 1);
                    Node current = prev.Next;
                    if (current.Next != null) prev.Next = current.Next;
                    else prev.Next = null;
                    count--;
                }

                else if (posit == 0 && posit < count)
                {
                    head = head.Next;
                    count--;
                }

                else if (posit == 0 && count == 1)
                {
                    head = null;
                    count--;
                }
            }
            public void Clear()
            {
                head = null;
                count = 0;
            }
            public int Count
            {
                get { return count; }
            }

            public int this[int i]
            {
                get
                {
                    if (i >= count || i < 0) return 0;

                    Node shw = Find(i);
                    return shw.Data;
                }

                set
                {
                    if (i >= count || i < 0) return;

                    Node st = Find(i);
                    st.Data = value;
                }
            }

            public void Show()
            {
                Node cur = head;
                if (cur != null)
                {
                    while (cur.Next != null)
                    {
                        Console.Write($"{cur.Data}; ");
                        cur = cur.Next;
                    }
                    Console.Write($"{cur.Data}. ");
                }
                else Console.WriteLine("Нет элементов в chain листе");
            }
        }
    }
}
