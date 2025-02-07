using System;
using System.Collections;

public class ArrList
{
    int[] buf = null;
    int count = 0;

    public void Add(int a)
    {
        // Если массив не инициализирован, создаем его с начальным размером 1
        if (buf == null)
        {
            buf = new int[1];
        }

        if (count == buf.Length)
        {
            Expand();
        }
        buf[count++] = a;
    }

    public void Insert(int a, int pos)
    {
        if (pos < 0 || pos > count)
        {
            // throw new IndexOutOfRangeException("Позиция вставки вне допустимого диапазона.");
            return;
        }

        if (buf == null)
        {
            buf = new int[4];
        }
        if (count == buf.Length)
        {
            Expand();
        }

        // Сдвигаем элементы после позиции вставки вправо
        for (int i = count; i > pos; i--)
        {
            buf[i] = buf[i - 1];
        }
        buf[pos] = a;
        count++;
    }

    public void Delete(int pos)
    {
        if (pos < 0 || pos >= count)
        {
            throw new IndexOutOfRangeException("Позиция удаления вне допустимого диапазона.");
        }

        // Сдвигаем элементы после позиции удаления влево
        for (int i = pos; i < count - 1; i++)
        {
            buf[i] = buf[i + 1];
        }
        count--;
    }

    public void Clear()
    {
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public int this[int i] // проверку если индекс не коректен
    {
        get { return buf[i]; }
        set { buf[i] = value; }
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(buf[i] + " ");
        }
        Console.WriteLine();
    }

    void Expand()
    {

        if (buf == null)
        {
            buf = new int[1];
            return;
        }
        if (count < buf.Length)
        {
            return;
        }
        int newSize = buf.Length * 2;
        int[] newBuf = new int[newSize];
        Array.Copy(buf, newBuf, buf.Length);
        buf = newBuf;
    }
}
public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }
    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
    }
}

public class ChainList
{
    Node head = null;
    int count = 0;

    public void Add(int data)
    {
        if (head == null)
        {
            head = new Node(data);
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(data);
        }
        count++;
    }

    public void Insert(int data, int pos)
    {
        if (pos < 0 || pos > count)
        {
            throw new IndexOutOfRangeException("Позиция вставки вне допустимого диапазона.");
        }

        if (pos == 0)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < pos - 1; i++)
            {
                current = current.Next;
            }
            Node newNode = new Node(data);
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        count++;
    }

    public void Delete(int pos)
    {
        if (pos < 0 || pos >= count)
        {
            throw new IndexOutOfRangeException("Позиция удаления вне допустимого диапазона.");
        }

        if (pos == 0)
        {
            head = head.Next;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < pos - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
        count--;
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
            if (i < 0 || i >= count)
            {
                throw new IndexOutOfRangeException("Индекс вне допустимого диапазона.");
            }

            Node current = head;
            for (int j = 0; j < i; j++)
            {
                current = current.Next;
            }
            return current.Data;
        }
        set
        {
            if (i < 0 || i >= count)
            {
                throw new IndexOutOfRangeException("Индекс вне допустимого диапазона.");
            }

            Node current = head;
            for (int j = 0; j < i; j++)
            {
                current = current.Next;
            }
            current.Data = value;
        }
    }

    public void Print()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

// class Program1
// {
//     static void Main(string[] args)
//     {
//         ArrList arrList = new ArrList();
//         arrList.Add(1);
//         arrList.Add(2);
//         arrList.Add(3);
//         arrList.Print();
//         arrList.Insert(5, 0);
//         arrList.Print();
//         arrList.Delete(2);
//         arrList.Print();
//         Console.WriteLine("Количество элементов в ArrList: " + arrList.Count);
//         arrList.Clear();

//         ChainList chainList = new ChainList();
//         chainList.Add(5);
//         chainList.Add(15);
//         chainList.Add(25);
//         chainList.Print();
//         chainList.Insert(10, 1);
//         chainList.Print();
//         chainList.Delete(2);
//         chainList.Print();
//         Console.WriteLine("Количество элементов в ChainList: " + chainList.Count);
//          chainList.Clear();
//     }
// }

class Testing
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        // Генерируем и выводим 10 случайных чисел
        for (int i = 0; i < 5000; i++)
        {
            int randomNumber = rand.Next(0, 3); // от 0 до 2
            if (randomNumber == 0)
            {

                int randomNumberAdd = rand.Next(0, 1000);
                arrList.Add(randomNumberAdd);
                chainList.Add(randomNumberAdd);
            }
            if (randomNumber == 1)
            {

            }
        }
    }
}