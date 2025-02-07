using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestArrayList();
            TestChainList();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void TestArrayList()
        {
            Console.WriteLine("Testing ArrayList<int>");
            Console.WriteLine("------------------------");

            ArrayList<int> arrayList = new ArrayList<int>();

            // Добавление элементов
            for (int i = 0; i < 30; i++)
            {
                arrayList.Add(i);
                for (int j = 0; j < 10; j++)
                {
                    arrayList.Add(j);
                }
            }

            // Вывод содержимого
            Console.WriteLine("ArrayList<int> contents:");
            arrayList.PrintList();

            // Поиск элемента
            int index = arrayList.Find(15);
            Console.WriteLine($"Index of 15: {index}");

            // Удаление элемента
            arrayList.Delete(5);
            Console.WriteLine("ArrayList<int> after deleting index 5:");
            arrayList.PrintList();

            // Очистка списка
            arrayList.Clear();
            Console.WriteLine("ArrayList<int> after clearing:");
            arrayList.PrintList();
        }

        static void TestChainList()
        {
            Console.WriteLine("\nTesting ChainList<int>");
            Console.WriteLine("------------------------");

            ChainList<int> chainList = new ChainList<int>();

            // Добавление элементов
            for (int i = 0; i < 30; i++)
            {
                chainList.Add(i);
            }

            // Вывод содержимого
            Console.WriteLine("ChainList<int> contents:");
            chainList.PrintList();

            // Поиск элемента
            int index = chainList.Find(15);
            Console.WriteLine($"Index of 15: {index}");

            // Удаление элемента
            chainList.Delete(5);
            Console.WriteLine("ChainList<int> after deleting index 5:");
            chainList.PrintList();

            // Очистка списка
            chainList.Clear();
            Console.WriteLine("ChainList<int> after clearing:");
            chainList.PrintList();
        }
    }
}
