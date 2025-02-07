using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    public class ChainList<T> : BaseList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;
        private List<Node<T>> anchors;

        // Новый уровень списка
        private Dictionary<Node<T>, ChainList<T>> levels;

        public ChainList()
        {
            head = null;
            tail = null;
            count = 0;
            anchors = new List<Node<T>>();
            levels = new Dictionary<Node<T>, ChainList<T>>();
        }

        public override void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }

            if (count % 20 == 0)
            {
                anchors.Add(node);
            }

            levels[node] = new ChainList<T>(); // Инициализация нового уровня для нового узла

            count++;
            OnChange();
        }

        public override void Insert(int index, T item)
        {
            if (index < 0 || index > count)
                throw new BadIndexException();

            Node<T> node = new Node<T>(item);

            if (index == 0)
            {
                node.Next = head;
                if (head != null)
                    head.Previous = node;
                head = node;
                if (count == 0)
                    tail = node;
            }
            else if (index == count)
            {
                node.Previous = tail;
                if (tail != null)
                    tail.Next = node;
                tail = node;
            }
            else
            {
                Node<T> current = GetNodeAt(index);

                node.Next = current;
                node.Previous = current.Previous;
                current.Previous.Next = node;
                current.Previous = node;
            }

            if (index % 20 == 0)
            {
                anchors.Insert(index / 20, node);
            }

            levels[node] = new ChainList<T>(); // Инициализация нового уровня для вставленного узла

            count++;
            OnChange();
        }

        public override void Delete(int index)
        {
            if (index < 0 || index >= count)
                throw new BadIndexException();

            Node<T> toDelete = GetNodeAt(index);

            if (toDelete.Previous != null)
            {
                toDelete.Previous.Next = toDelete.Next;
            }
            else
            {
                head = toDelete.Next;
            }

            if (toDelete.Next != null)
            {
                toDelete.Next.Previous = toDelete.Previous;
            }
            else
            {
                tail = toDelete.Previous;
            }

            if (index % 20 == 0)
            {
                anchors.RemoveAt(index / 20);
            }

            levels.Remove(toDelete); // Удаление уровня для удаленного узла

            count++;
            OnChange();
        }

        public override void Clear()
        {
            head = null;
            tail = null;
            count = 0;
            anchors.Clear();
            levels.Clear();
            OnChange();
        }

        public override int Find(T item)
        {
            Node<T> current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.CompareTo(item) == 0)
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public override T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new BadIndexException();

                return GetNodeAt(index).Data;
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new BadIndexException();

                GetNodeAt(index).Data = value;
                OnChange();
            }
        }

        public override int Count => count;

        public int FindFast(T item)
        {
            if (head == null) return -1;

            int startIndex = 0;
            Node<T> current = head;

            // Поиск ближайшего якоря
            for (int i = 0; i < anchors.Count; i++)
            {
                if (anchors[i].Data.CompareTo(item) == 0)
                {
                    return i * 20;
                }
                else if (anchors[i].Data.CompareTo(item) > 0)
                {
                    startIndex = i * 20;
                    current = anchors[i];
                    break;
                }
            }

            // Линейный поиск от найденного якоря
            for (int i = startIndex; i < count && current != null; i++)
            {
                if (current.Data.CompareTo(item) == 0)
                {
                    return i;
                }
                current = current.Next;
            }

            return -1;
        }

        private Node<T> GetNodeAt(int index)
        {
            if (index < 0 || index >= count)
                throw new BadIndexException();

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public override void SaveToFile(string fileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                Node<T> current = head;
                while (current != null)
                {
                    file.WriteLine(current.Data);
                    current = current.Next;
                }
            }
        }

        public override void LoadFromFile(string fileName)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                Clear();
                foreach (string line in lines)
                {
                    Add((T)Convert.ChangeType(line, typeof(T)));
                }
            }
            catch (Exception ex)
            {
                throw new BadFileException(ex.Message);
            }
        }

        public override void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                if (levels.ContainsKey(current) && levels[current] != null)
                {
                    Console.Write("[");
                    levels[current].PrintList();
                    Console.Write("]");
                }
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void AddLevel()
        {
            Node<T> current = head;
            while (current != null)
            {
                levels[current] = new ChainList<T>();
                current = current.Next;
            }
        }
    }
}
