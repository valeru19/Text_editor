using System;

// Класс Node представляет узел в двусвязном списке
class Node
{
    public int Data;    // Данные, хранящиеся в узле
    public Node Next;   // Ссылка на следующий узел в списке
    public Node Prev;   // Ссылка на предыдущий узел в списке

    // Конструктор для инициализации нового узла с заданными данными
    public Node(int data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

// Класс DoublyLinkedList представляет двусвязный список
class DoublyLinkedList
{
    private Node Head;  // Ссылка на первый узел в списке
    private Node Tail;  // Ссылка на последний узел в списке
    private Node[] Index;   // Массив для хранения ссылок на все узлы в списке

    public int Count { get; private set; }   // Свойство для получения количества узлов в списке

    // Конструктор для инициализации пустого двусвязного списка
    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
        Index = new Node[0];
        Count = 0;
    }

    // Метод для добавления нового элемента в конец списка
    public void Add(int data)
    {
        Node newNode = new Node(data); // Создается новый узел newNode с переданными данными data
        // Проверяется, пуст ли список (т.е. Head == null). Если это так, то устанавливаются Head и Tail на новый узел newNode
        if (Head == null) 
        {
            Head = newNode;
            Tail = newNode;
        }
        // Если список не пуст, то текущий Tail списка (последний узел) указывает на новый узел newNode
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode; // Обновляется связь предыдущего Tail с новым узлом newNode
        }
        Array.Resize(ref Index, Index.Length + 1); // Массив Index расширяется на 1, так как добавлен новый элемент
        Index[Index.Length - 1] = newNode; // newNode добавляется в Index на последнюю позицию 
        Count++;
    }

    // Выполняет бинарный поиск элемента в массиве Index, который содержит ссылки на все узлы списка
    public Node BinarySearch(int target)
    {
        // Сначала определяются два указателя: left, указывающий на начало массива (индекс 0), и right, указывающий на конец массива
        int left = 0;
        int right = Index.Length - 1;

        while (left <= right) // Процесс продолжается, пока левая граница не станет больше правой. Если искомый элемент не найден, возвращается null
        {
            int mid = left + (right - left) / 2; // Происходит сужение диапазона поиска путем вычисления середины диапазона с помощью переменной mid = left + (right - left) / 2
            if (Index[mid].Data == target) // Проверяется значение элемента по индексу mid
                return Index[mid]; // Возвращается ссылка на узел с этим значением.
            else if (Index[mid].Data < target)
                left = mid + 1; // Обновляется левая граница диапазона поиска: left = mid + 1
            else
                right = mid - 1;
        }
        return null;
    }

    // Метод для изменения значения элемента по индексу
    public void Set(int index, int newValue)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException("Index out of range.");

        Node current = Head;
        for (int i = 0; i < index; i++)
            current = current.Next;

        current.Data = newValue;
    }

    // Метод для вставки нового элемента по индексу
    public void Insert(int index, int data)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException("Index out of range.");

        if (index == 0) // Проверяется, является ли index равным 0
        {
            Node newNode = new Node(data); // Создается новый узел newNode с переданными данными data
            newNode.Next = Head; // Происходит обновление ссылок: newNode.Next указывает на текущую голову списка (Head)
            if (Head != null) // Если список не пуст (Head != null)
                Head.Prev = newNode; // Обновляется ссылка Head.Prev, указывающая на newNode
            Head = newNode; // Head обновляется, чтобы указывать на newNode
            if (Tail == null) // Если Tail пуст (список был пустым
                Tail = newNode; // Tail тоже обновляется, чтобы указывать на newNode
            Index = new Node[++Count]; // Затем массив Index расширяется на 1, так как добавлен новый элемент
            Index[0] = newNode; // newNode добавляется в Index на позицию 0 (первый элемент)
            return;
        }
        // Если index равен Count, означает, что элемент должен быть добавлен в конец списка
        if (index == Count)
        {
            // В этом случае вызывается метод Add(data), который добавляет новый элемент в конец списка   
            Add(data);
            return;
        }

        Node current = Head;
        // Если index не равен 0 или Count, то происходит итерация до узла, расположенного перед позицией вставки
        for (int i = 0; i < index - 1; i++)
            current = current.Next;

        Node node = new Node(data); // Устанавливаются связи нового узла node с соседними узлами
        node.Next = current.Next; // node.Next устанавливается на следующий узел после текущего (current.Next)
        node.Prev = current; // node.Prev устанавливается на текущий узел (current)
        // Обновляются ссылки соседних узлов на новый узел
        current.Next.Prev = node; 
        current.Next = node;

        Array.Resize(ref Index, Index.Length + 1);
        for (int i = Count - 1; i > index; i--)
            Index[i] = Index[i - 1];
        Index[index] = node;
        Count++;
    }

    // Метод для удаления элемента по индексу
    public void Delete(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException("Index out of range.");
        // Если index равен 0, то удаляемый элемент находится в начале списка
        if (index == 0)
        {
            Head = Head.Next; // Происходит обновление Head, чтобы он указывал на следующий за текущим первый элемент
            // Если Head не равен null, то обновляется связь предыдущего Head на null
            if (Head != null) 
                Head.Prev = null;
            Index = new Node[--Count]; // Затем массив Index уменьшается на 1, так как элемент удален из списка
            Array.Copy(Index, 1, Index, 0, Count);
            return;
        }
        // Если index не равен 0, то происходит итерация до узла, расположенного перед удаляемым элементом
        Node current = Head;
        for (int i = 0; i < index - 1; i++)

            current = current.Next;
        // Ссылка current.Next(следующего за текущим узла) обновляется, чтобы указывать на узел после удаляемого элемента
        current.Next = current.Next.Next;
        if (current.Next != null)
            current.Next.Prev = current;

        Array.Copy(Index, index + 1, Index, index, Count - index - 1);
        Array.Resize(ref Index, --Count);
    }

    // Метод для очистки списка
    public void Clear()
    {
        Head = null;
        Tail = null;
        Index = new Node[0];
        Count = 0;
    }

    // Метод для изменения размера массива Index
    public void Resize(int newSize)
    {
        Array.Resize(ref Index, newSize);
    }

    // Метод для печати списка
    public void Print()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // Индексатор для доступа к элементу списка по индексу
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("Index out of range.");

            Node current = Head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Data;
        }
        set
        {
            Set(index, value);
        }
    }
}

// Класс Program содержит метод Main, который является точкой входа в программу
class Program
{
    // Главный метод программы
    static void Main(string[] args)
    {
        DoublyLinkedList list = new DoublyLinkedList();   // Создание нового двусвязного списка
        list.Add(1);   // Добавление элементов в список
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);

        list.Print(); // Вывод списка на экран

        list.Insert(1, 9); // Вставка нового элемента по индексу
        list.Print(); // Вывод списка на экран

        list.Delete(3); // Удаление элемента по индексу
        list.Print(); // Вывод списка на экран

        list[2] = 35; // Изменение значения элемента по индексу
        list.Print(); // Вывод списка на экран

        Console.WriteLine("Element at index 3: " + list[3]); // Вывод значения элемента по индексу

        Console.WriteLine("Count: " + list.Count); // Вывод количества элементов в списке

        list.Clear(); // Очистка списка
        list.Print(); // Вывод списка на экран

        Console.WriteLine("Count after clearing: " + list.Count); // Вывод количества элементов в списке после очистки
    }
}
