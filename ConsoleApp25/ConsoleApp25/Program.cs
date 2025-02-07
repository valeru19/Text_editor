using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            TestArrayList();
            TestChainList();

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }

        static void TestArrayList()
        {
            ArrayList<int> arrayList = new ArrayList<int>();
            arrayList.event_Change += () => Console.WriteLine("ArrayList изменился");

            Console.WriteLine("Тестируем ArrayList:");

            // Добавление элементов
            for (int i = 1; i <= 30000; i++)
            {
                arrayList.Add(i);
            }
            PrintList(arrayList);

            // Вставка элемента
            arrayList.Insert(10, 99);
            Console.WriteLine("После вставки 99 на позицию 10:");
            PrintList(arrayList);

            // Удаление элемента
            arrayList.Delete(10);
            Console.WriteLine("После удаления элемента на позиции 10:");
            PrintList(arrayList);

            // Поиск элемента
            int index = arrayList.Find(15);
            Console.WriteLine($"Элемент 15 найден на позиции: {index}");

            // Сохранение в файл
            arrayList.SaveToFile("arraylist.txt");
            Console.WriteLine("Список сохранен в файл arraylist.txt");

            // Очистка списка
            arrayList.Clear();
            Console.WriteLine("После очистки:");
            PrintList(arrayList);

            // Загрузка из файла
            arrayList.LoadFromFile("arraylist.txt");
            Console.WriteLine("После загрузки из файла:");
            PrintList(arrayList);

            // Измерение времени поиска
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            arrayList.Find(28424);
            stopwatch.Stop();
            Console.WriteLine($"Время поиска элемента 25 в ArrayList: {stopwatch.ElapsedTicks} тиков");

            Console.WriteLine();
        }

        static void TestChainList()
        {
            ChainList<int> chainList = new ChainList<int>();
            chainList.event_Change += () => Console.WriteLine("ChainList изменился");

            Console.WriteLine("Тестируем ChainList:");

            // Добавление элементов
            for (int i = 1; i <= 30; i++)
            {
                chainList.Add(i);
            }
            chainList.PrintList();

            // Вставка элемента
            chainList.Insert(10, 99);
            Console.WriteLine("После вставки 99 на позицию 10:");
            chainList.PrintList();

            // Удаление элемента
            chainList.Delete(10);
            Console.WriteLine("После удаления элемента на позиции 10:");
            chainList.PrintList();

            // Поиск элемента
            int index = chainList.Find(15);
            Console.WriteLine($"Элемент 15 найден на позиции: {index}");

            // Сохранение в файл
            chainList.SaveToFile("chainlist.txt");
            Console.WriteLine("Список сохранен в файл chainlist.txt");

            // Очистка списка
            chainList.Clear();
            Console.WriteLine("После очистки:");
            chainList.PrintList();

            // Загрузка из файла
            chainList.LoadFromFile("chainlist.txt");
            Console.WriteLine("После загрузки из файла:");
            chainList.PrintList();

            // Измерение времени быстрого поиска
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            chainList.FindFast(25);
            stopwatch.Stop();
            Console.WriteLine($"Время быстрого поиска элемента 25 в ChainList: {stopwatch.ElapsedTicks} тиков");

            Console.WriteLine();
        }

        static void PrintList<T>(BaseList<T> list) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }

    public class BadIndexException : Exception
    {
        public BadIndexException(string message) : base(message) { }
    }

    public class BadFileException : Exception
    {
        public BadFileException(string message) : base(message) { }
    }

    public abstract class BaseList<T> where T : IComparable<T>
    {
        public delegate void ChangeHandler();
        public event ChangeHandler event_Change;

        protected void OnChange()
        {
            event_Change?.Invoke();
        }

        public abstract void Add(T item);
        public abstract void Insert(int index, T item);
        public abstract void Delete(int index);
        public abstract int Find(T item);
        public abstract void SaveToFile(string fileName);
        public abstract void LoadFromFile(string fileName);
        public abstract void Clear();
        public abstract T this[int index] { get; set; }
        public abstract int Count { get; }
    }

    public class ArrayList<T> : BaseList<T> where T : IComparable<T>
    {
        private List<T> list = new List<T>();

        public override void Add(T item)
        {
            list.Add(item);
            OnChange();
        }

        public override void Insert(int index, T item)
        {
            if (index < 0 || index > list.Count)
                throw new BadIndexException("Неверный индекс");
            list.Insert(index, item);
            OnChange();
        }

        public override void Delete(int index)
        {
            if (index < 0 || index >= list.Count)
                throw new BadIndexException("Неверный индекс");
            list.RemoveAt(index);
            OnChange();
        }

        public override int Find(T item)
        {
            return list.IndexOf(item);
        }

        public override void SaveToFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (T item in list)
                {
                    sw.WriteLine(item.ToString());
                }
            }
            OnChange();
        }

        public override void LoadFromFile(string fileName)
        {
            list.Clear();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add((T)Convert.ChangeType(line, typeof(T)));
                }
            }
            OnChange();
        }

        public override void Clear()
        {
            list.Clear();
            OnChange();
        }

        public override T this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Count)
                    throw new BadIndexException("Неверный индекс");
                return list[index];
            }
            set
            {
                if (index < 0 || index >= list.Count)
                    throw new BadIndexException("Неверный индекс");
                list[index] = value;
                OnChange();
            }
        }

        public override int Count => list.Count;
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    public class ChainList<T> : BaseList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private List<Node<T>> anchors; // Список якорей для быстрого поиска
        private const int AnchorInterval = 10; // Интервал между якорями

        public ChainList()
        {
            head = null;
            tail = null;
            anchors = new List<Node<T>>();
        }

        public override void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }

            if (Count % AnchorInterval == 0)
            {
                anchors.Add(newNode);
            }

            OnChange();
        }

        public override void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new BadIndexException("Неверный индекс");

            Node<T> newNode = new Node<T>(item);

            if (index == 0)
            {
                newNode.Next = head;
                if (head != null) head.Prev = newNode;
                head = newNode;
                if (tail == null) tail = newNode;
            }
            else if (index == Count)
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }

            anchors.Clear();
            Node<T> temp = head;
            for (int i = 0; temp != null; i++, temp = temp.Next)
            {
                if (i % AnchorInterval == 0)
                {
                    anchors.Add(temp);
                }
            }

            OnChange();
        }

        public override void Delete(int index)
        {
            if (index < 0 || index >= Count)
                throw new BadIndexException("Неверный индекс");

            if (index == 0)
            {
                head = head.Next;
                if (head != null) head.Prev = null;
                if (head == null) tail = null;
            }
            else if (index == Count - 1)
            {
                tail = tail.Prev;
                if (tail != null) tail.Next = null;
                if (tail == null) head = null;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }

            anchors.Clear();
            Node<T> temp = head;
            for (int i = 0; temp != null; i++, temp = temp.Next)
            {
                if (i % AnchorInterval == 0)
                {
                    anchors.Add(temp);
                }
            }

            OnChange();
        }

        public override int Find(T item)
        {
            Node<T> current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.CompareTo(item) == 0)
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public int FindFast(T item)
        {
            if (head == null) return -1;

            // Поиск ближайшего якоря
            int startIndex = 0;
            Node<T> current = head;

            for (int i = 0; i < anchors.Count; i++)
            {
                if (anchors[i].Data.CompareTo(item) == 0)
                {
                    return i * AnchorInterval;
                }
                else if (anchors[i].Data.CompareTo(item) > 0)
                {
                    startIndex = i * AnchorInterval;
                    current = anchors[i];
                    break;
                }
            }

            // Если якоря не найдены, ищем дальше
            while (current != null)
            {
                if (current.Data.CompareTo(item) == 0)
                {
                    return startIndex;
                }
                current = current.Next;
                startIndex++;
            }

            return -1;
        }

        public override void SaveToFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                Node<T> current = head;
                while (current != null)
                {
                    sw.WriteLine(current.Data.ToString());
                    current = current.Next;
                }
            }
            OnChange();
        }

        public override void LoadFromFile(string fileName)
        {
            Clear();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Add((T)Convert.ChangeType(line, typeof(T)));
                }
            }
            OnChange();
        }

        public override void Clear()
        {
            head = null;
            tail = null;
            anchors.Clear();
            OnChange();
        }

        public override T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new BadIndexException("Неверный индекс");
                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new BadIndexException("Неверный индекс");
                Node<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Data = value;
                OnChange();
            }
        }

        public override int Count
        {
            get
            {
                int count = 0;
                Node<T> current = head;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        public void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
