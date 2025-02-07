using System;

namespace LAB_3_ev
{
    class Program
    {
        static void Main(string[] args)
        {
            TestArrayList();
            TestChainList();

            Console.ReadLine(); // Чтобы консольное приложение не закрывалось сразу после выполнения
        }

        static void TestArrayList()
        {
            Console.WriteLine("=== Тестирование класса ArrayList ===");

            // Создание объекта ArrayList
            ArrayList arrayList = new ArrayList();

            // Тестирование метода Add
            Console.WriteLine("\nДобавление элементов в ArrayList:");
            for (int i = 1; i <= 100; i++)
            {
                arrayList.Add(i);
            }
            Console.WriteLine("Элементы ArrayList после добавления:");
            arrayList.Show();

            // Тестирование метода Insert
            Console.WriteLine("\nВставка элемента в ArrayList:");
            arrayList.Insert(100, 2); // Вставляем элемент со значением 100 на позицию 2
            Console.WriteLine("Элементы ArrayList после вставки:");
            arrayList.Show();

            // Тестирование метода Delete
            Console.WriteLine("\nУдаление элемента из ArrayList:");
            arrayList.Delete(3); // Удаляем элемент на позиции 3
            Console.WriteLine("Элементы ArrayList после удаления:");
            arrayList.Show();

            // Тестирование метода Clear
            Console.WriteLine("\nОчистка ArrayList:");
            arrayList.Clear();
            Console.WriteLine("Элементы ArrayList после очистки:");
            arrayList.Show();

            // Тестирование метода Assign
            Console.WriteLine("\nТестирование метода Assign для ArrayList:");
            ArrayList sourceArrayList = new ArrayList();
            for (int i = 1; i <= 50; i++)
            {
                sourceArrayList.Add(i);
            }
            arrayList.Assign(sourceArrayList);
            Console.WriteLine("Элементы ArrayList после Assign:");
            arrayList.Show();

            // Тестирование метода AssignTo
            Console.WriteLine("\nТестирование метода AssignTo для ArrayList:");
            ArrayList destArrayList = new ArrayList();
            arrayList.AssignTo(destArrayList);
            Console.WriteLine("Элементы destArrayList после AssignTo:");
            destArrayList.Show();

            // Тестирование метода Reverse
            /*Console.WriteLine("\nТестирование метода Reverse для ArrayList:");
            arrayList.Reverse();
            Console.WriteLine("Элементы ArrayList после Reverse:");
            arrayList.Show();*/

            // Тестирование метода Sort
            Console.WriteLine("\nТестирование метода Sort для ArrayList:");
            arrayList.Sort();
            Console.WriteLine("Элементы ArrayList после Sort:");
            arrayList.Show();

            // Тестирование метода Print
            Console.WriteLine("\nТестирование метода Print для ArrayList:");
            arrayList.Print();

            // Тестирование метода IsEqual
            Console.WriteLine("\nТестирование метода IsEqual для ArrayList:");
            Console.WriteLine("Сравнение arrayList и sourceArrayList: " + arrayList.IsEqual(sourceArrayList));
            Console.WriteLine("Сравнение arrayList и destArrayList: " + arrayList.IsEqual(destArrayList));
        }

        static void TestChainList()
        {
            Console.WriteLine("\n\n=== Тестирование класса ChainList ===");

            // Создание объекта ChainList
            ChainList chainList = new ChainList();

            // Тестирование метода Add
            Console.WriteLine("\nДобавление элементов в ChainList:");
            for (int i = 1; i <= 100; i++)
            {
                chainList.Add(i);
            }
            Console.WriteLine("Элементы ChainList после добавления:");
            chainList.Show();

            // Тестирование метода Insert
            Console.WriteLine("\nВставка элемента в ChainList:");
            chainList.Insert(100, 2); // Вставляем элемент со значением 100 на позицию 2
            Console.WriteLine("Элементы ChainList после вставки:");
            chainList.Show();

            // Тестирование метода Delete
            Console.WriteLine("\nУдаление элемента из ChainList:");
            chainList.Delete(3); // Удаляем элемент на позиции 3
            Console.WriteLine("Элементы ChainList после удаления:");
            chainList.Show();

            // Тестирование метода Clear
            Console.WriteLine("\nОчистка ChainList:");
            chainList.Clear();
            Console.WriteLine("Элементы ChainList после очистки:");
            chainList.Show();

            // Тестирование метода Assign
            Console.WriteLine("\nТестирование метода Assign для ChainList:");
            ChainList sourceChainList = new ChainList();
            for (int i = 1; i <= 50; i++)
            {
                sourceChainList.Add(i);
            }
            chainList.Assign(sourceChainList);
            Console.WriteLine("Элементы ChainList после Assign:");
            chainList.Show();

            // Тестирование метода AssignTo
            Console.WriteLine("\nТестирование метода AssignTo для ChainList:");
            ChainList destChainList = new ChainList();
            chainList.AssignTo(destChainList);
            Console.WriteLine("Элементы destChainList после AssignTo:");
            destChainList.Show();

            // Тестирование метода Reverse
            /*Console.WriteLine("\nТестирование метода Reverse для ChainList:");
            chainList.Reverse();
            Console.WriteLine("Элементы ChainList после Reverse:");
            chainList.Show();*/

            // Тестирование метода Sort
            Console.WriteLine("\nТестирование метода Sort для ChainList:");
            chainList.Sort();
            Console.WriteLine("Элементы ChainList после Sort:");
            chainList.Show();

            // Тестирование метода IsEqual
            Console.WriteLine("\nТестирование метода IsEqual для ChainList:");
            Console.WriteLine("Сравнение chainList и sourceChainList: " + chainList.IsEqual(sourceChainList));
            Console.WriteLine("Сравнение chainList и destChainList: " + chainList.IsEqual(destChainList));

            // Тестирование метода FindFast
            Console.WriteLine("\nТестирование метода FindFast для ChainList:");
            Console.WriteLine("Элемент на позиции 2: " + chainList.FindFast(2).Data);

            // Тестирование метода Find
            Console.WriteLine("\nТестирование метода Find для ChainList:");
            Console.WriteLine("Элемент на позиции 2: " + chainList.Find(2).Data);
        }
    }
}
