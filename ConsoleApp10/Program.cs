using System;
public class DynamicList
{
    private int[] buffer; // Создаем список
    private int count; // переменная для определения кол-ва элементов в списке

    public DynamicList()
    {
        buffer = new int[10]; 
        count = 0;
    }

    // Метод для добавления элемента в список
    public void Add(int item)
    {
        if (count == buffer.Length)
        {
            Resize(buffer.Length * 2);
        }
        buffer[count++] = item;
    }

    // Метод для изменения размера буфера
    private void Resize(int newSize)
    {
        int[] newBuffer = new int[newSize];
        for (int i = 0; i < count; i++) 
        {
            newBuffer[i] = buffer[i];
        }
        buffer = newBuffer;
    }

    public void RemoveDuplicates()
    {
        for(int i = 0; i < count - 1; i++) 
        {
            for (int j = i + 1; j < count; j++)
            {
                if (buffer[i] == buffer[j]) 
                {
                    Delite(j);
                    j--; //После удаления уменьшили индекс, чтобы не пропустить следующий элемент
                }
            }
        }
    }

    // Метод для вставки элемента на указанную позицию
    public void Insert(int item, int pos)
    {
        if(pos > count || pos < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Позиция вне диапазона списка");
        }
        if(count == buffer.Length)
        {
            Resize(buffer.Length * 2);
        }
        // Сдвигаем элементы на одну позицию вправо, начиная с конца списка
        for(int i = count; i > pos; i--)
        {
            buffer[i] = buffer[i - 1];
        }

        buffer[pos] = item;
        count++;
    }

    // Метод для удаления элемента с указанной позиции
    public void Delite(int index)
    {
        if(index < 0 ||  index >= count)
        {
            return;
        }
        for(int i = index; i < count; i++)
        {
            buffer[i] = buffer[i + 1];
        }
        buffer[count - 1] = 0; // Обнуляем последний элемент после сдвига
        count--;
    }

    // Метод для очискти списка
     public void Clear()
    {
        buffer[10] = 0; // Реинициализация с начальным размером
        count = 0;
    }

    // Свойство для получения количества элементов в списке
    public int Count
    {
        get { return count; }
    }

    // Индексатор для доступа к элементам списка
    public int this[int i]
    {
        get
        {
            if(i >= count || i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Индекс вне диапазона списка");

            }
            return buffer[i];
        }
        set
        {
            if(i >= count || i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Индекс вне диапазона списка");
            }
            buffer[i] = value;
        }
    }

    // Метод для вывода элементов списка
    public void Printer()
    {
        for(int i = 0; i < count; i++)
        {
            Console.WriteLine(buffer[i] + " ");
        }
        Console.WriteLine();
    }
}

public class LinkedList
{
    private class Node
    {
        public int Data; // Данные хранятся в узле
        public Node Next; // Ссылка на следующий узел в списке

        public Node(int data)
        {
            Data = data;
            Next = null; // По умолчанию следующий узел не установлен
        }
    }

    private Node head; // Голова списка, первый узел
    private int count; // Кол-во узлов в списке

    public LinkedList()
    {
        head = null;
        count = 0;
    }

    public void Add(int data)
    {
        if (head == null)
        {
            head= new Node(data); // Создание головы списка, если она отсутствует 
        }
        else
        {
            Node current = head;
            while(current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(data); // Добавление нового узла в конец списка
        }
        count++;
    }
    // Метод get return 0
    // Если метод set, то просто игнорируем
    public int this[int index]
    {
        get
        {
            Node current = head;
            for(int i = 0; i < index; i++)
            {
                if (current != null)
                {
                    current = current.Next;
                }
                else
                {
                    // throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне диапазона списка");
                }
            }
            return current.Data;
               
        }
        set
        {
            Node current = head;
            for(int i = 0; i < index; i++)
            {
                if(current != null)
                {
                    current = current.Next;
                }
                else
                {
                    return;
                }
            }
            if(current != null)
            {
                current.Data = value;
            }
            else
            {
                return;
            }
        }
    }

}