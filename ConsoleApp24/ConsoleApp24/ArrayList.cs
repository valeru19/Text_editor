using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class ArrayList
    {
        public class ArrayList<T> : BaseList<T> where T : IComparable
        {
            private T[] array;
            private int size;

            public ArrayList()
            {
                size = 2;
                array = new T[size];
            }

            private void EnsureCapacity()
            {
                if (count == size)
                {
                    size *= 2;
                    Array.Resize(ref array, size);
                }
            }

            public override void Add(T value)
            {
                EnsureCapacity();
                array[count] = value;
                count++;
                OnChange();
            }

            public override void Insert(T value, int pos)
            {
                if (pos < 0 || pos > count) throw new BadIndexException("Index out of range");

                EnsureCapacity();
                for (int i = count; i > pos; i--)
                {
                    array[i] = array[i - 1];
                }
                array[pos] = value;
                count++;
                OnChange();
            }

            public override void Delete(int pos)
            {
                if (pos < 0 || pos >= count) throw new BadIndexException("Index out of range");

                for (int i = pos; i < count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                count--;
                OnChange();
            }

            public override void Clear()
            {
                array = new T[2];
                count = 0;
                size = 2;
                OnChange();
            }

            public override T this[int i]
            {
                get
                {
                    if (i < 0 || i >= count) throw new BadIndexException("Index out of range");
                    return array[i];
                }
                set
                {
                    if (i < 0 || i >= count) throw new BadIndexException("Index out of range");
                    array[i] = value;
                    OnChange();
                }
            }

            public override void Show()
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
            }

            protected override BaseList<T> Dummy()
            {
                return new ArrayList<T>();
            }

            public override void Sort()
            {
                if (count <= 1) return;

                Array.Sort(array, 0, count);
            }

            public void SaveToFile(string fileName)
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteLine(array[i]);
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

            public static bool operator ==(ArrayList<T> a, ArrayList<T> b)
            {
                if (a.Count != b.Count) return false;

                for (int i = 0; i < a.Count; i++)
                {
                    if (!a[i].Equals(b[i])) return false;
                }

                return true;
            }

            public static bool operator !=(ArrayList<T> a, ArrayList<T> b)
            {
                return !(a == b);
            }

            public static ArrayList<T> operator +(ArrayList<T> a, ArrayList<T> b)
            {
                ArrayList<T> result = a.Clone();

                for (int i = 0; i < b.Count; i++)
                {
                    result.Add(b[i]);
                }

                return result;
            }
        }
    }
}
