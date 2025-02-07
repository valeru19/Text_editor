using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class ChainList
    {
        public class ChainList<T> : BaseList<T>
        {
            public class Node
            {
                public T Data { get; set; }
                public Node Next { get; set; }

                public Node(T data)
                {
                    Data = data;
                    Next = null;
                }
            }

            private Node head = null;

            public override void Add(T value)
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

            public override void Insert(T value, int posit)
            {
                if (posit == count && posit == 0) Add(value);

                else if (posit == count) Add(value);

                else if (posit < count)
                {
                    count++;
                    if (posit == 0)
                    {
                        head = new Node(value) { Next = head };
                    }
                    else
                    {
                        Node prev = Find(posit - 1);
                        Node curr = Find(posit);
                        Node insr = new Node(value) { Next = curr };
                        prev.Next = insr;
                    }
                }
            }

            public override void Delete(int posit)
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

            public override void Clear()
            {
                head = null;
                count = 0;
            }

            public override T this[int i]
            {
                get
                {
                    if (i >= count || i < 0) throw new BadIndexException("Index out of range");

                    Node shw = Find(i);
                    return shw.Data;
                }
                set
                {
                    if (i >= count || i < 0) throw new BadIndexException("Index out of range");

                    Node st = Find(i);
                    st.Data = value;
                }
            }

            public override void Show()
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
                else Console.WriteLine("No elements in the ChainList");
            }

            protected override BaseList<T> Dummy()
            {
                return new ChainList<T>();
            }

            public override void Sort()
            {
                if (count == 0 || count == 1) { return; }

                bool swap;
                do
                {
                    swap = false;
                    Node curr = head;
                    for (int i = 0; i < count - 1; i++)
                    {
                        if (((IComparable)curr.Data).CompareTo(curr.Next.Data) < 0)
                        {
                            (curr.Next.Data, curr.Data) = (curr.Data, curr.Next.Data);
                            swap = true;
                        }
                        curr = curr.Next;
                    }
                } while (swap);
            }

            public void SaveToFile(string fileName)
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    Node current = head;
                    while (current != null)
                    {
                        writer.WriteLine(current.Data);
                        current = current.Next;
                    }
                }
            }

            public void LoadFromFile(string fileName)
            {
                Clear();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Add((T)Convert.ChangeType(line, typeof(T)));
                    }
                }
            }

            public event EventHandler ChangeEvent;

            protected virtual void OnChange()
            {
                ChangeEvent?.Invoke(this, EventArgs.Empty);
            }

            public static bool operator ==(ChainList<T> a, ChainList<T> b)
            {
                if (a.Count != b.Count) return false;

                for (int i = 0; i < a.Count; i++)
                {
                    if (!a[i].Equals(b[i])) return false;
                }

                return true;
            }

            public static bool operator !=(ChainList<T> a, ChainList<T> b)
            {
                return !(a == b);
            }

            public static ChainList<T> operator +(ChainList<T> a, ChainList<T> b)
            {
                ChainList<T> result = a.Clone();

                for (int i = 0; i < b.Count; i++)
                {
                    result.Add(b[i]);
                }

                return result;
            }
        }
    }
}
