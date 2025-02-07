using System;

namespace MyLists
{
    class Program
    {
        private static int dynamicBadIndexExceptionCount = 0;
        private static int dynamicBadFileExceptionCount = 0;
        private static int linkedBadIndexExceptionCount = 0;
        private static int linkedBadFileExceptionCount = 0;
        static void Main(string[] args)
        {
            BaseList<string> dynamicList = new DynamicList<string>();
            BaseList<string> linkedList = new LinkedList<string>();

            // Добавление элементов
            Console.WriteLine("--- ТЕСТИРОВКА ADD --- \n");
            dynamicList.Add("one");
            dynamicList.Add("two");
            dynamicList.Add("three");

            linkedList.Add("one");
            linkedList.Add("two");
            linkedList.Add("three");

            Console.WriteLine("Список DynamicList после добавления элементов:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после добавления элементов:");
            linkedList.Print();
            Console.WriteLine();

            // Вставка элемента
            Console.WriteLine("--- ТЕСТИРОВКА Insert ---\n");
            dynamicList.Insert(1, "number");
            linkedList.Insert(1, "number");

            Console.WriteLine("Список DynamicList после вставки элемента:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после вставки элемента:");
            linkedList.Print();
            Console.WriteLine();

            // Удаление элемента
            Console.WriteLine("--- ТЕСТИРОВКА Delete ---\n");
            dynamicList.Delete(2);
            linkedList.Delete(2);

            Console.WriteLine("Список DynamicList после удаления элемента:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после удаления элемента:");
            linkedList.Print();
            Console.WriteLine();

            // Очистка списков
            Console.WriteLine("--- ТЕСТИРОВКА Clear ---\n");
            dynamicList.Clear();
            linkedList.Clear();

            Console.WriteLine("Список DynamicList после очистки:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после очистки:");
            linkedList.Print();
            Console.WriteLine();

            // Проверка на равенство списков
            dynamicList.Add("one");
            dynamicList.Add("two");
            dynamicList.Add("three");

            linkedList.Add("one");
            linkedList.Add("two");
            linkedList.Add("three");

            // Сравниваем списки снова
            Console.WriteLine("--- ТЕСТИРОВКА СРАВНЕНИЯ ---\n");
            Console.WriteLine("Сравнение списков с помощью оператора == после добавления элементов во второй список:");
            Console.WriteLine(dynamicList == linkedList); // Ожидается true
            Console.WriteLine(dynamicList != linkedList); // Ожидается false
            Console.WriteLine();

            Console.WriteLine("--- ТЕСТИРОВКА IsEqual ---\n");
            bool areListsEqual = dynamicList.IsEqual(linkedList);
            Console.WriteLine($"Списки {(areListsEqual ? "одинаковы" : "различны")}.");
            Console.WriteLine();


            Console.WriteLine("--- ТЕСТИРОВКА CHANGE ---\n");

            Console.WriteLine($"Количество изменений DynamicList: {dynamicList.ChangeCount}");
            Console.WriteLine($"Количество изменений LinkedList: {linkedList.ChangeCount}");

            Console.WriteLine();

            // Проверка метода Assign
            Console.WriteLine("--- ТЕСТИРОВКА Assign ---\n");
            BaseList<string> assignedList = new DynamicList<string>();

            assignedList.Add("four");
            assignedList.Add("four");

            Console.WriteLine("Исходный список dynamicList:");
            dynamicList.Print();
            Console.WriteLine("Исходный список assignedList:");
            assignedList.Print();

            dynamicList.Assign(assignedList);

            Console.WriteLine("Список DynamicList после применения метода Assign:");
            dynamicList.Print();
            Console.WriteLine("Список AssignedList после применения метода Assign:");
            assignedList.Print();
            Console.WriteLine();

            // Проверка метода AssignTo
            Console.WriteLine("--- ТЕСТИРОВКА AssignTo ---\n");
            dynamicList.Add("four");
            BaseList<string> assignedToList = new DynamicList<string>();

            assignedToList.Add("number");
            assignedToList.Add("figure");

            Console.WriteLine("Список DynamicList после применения метода Assign:");
            dynamicList.Print();
            Console.WriteLine("Список AssignedToList после применения метода Assign:");
            assignedToList.Print();

            dynamicList.AssignTo(assignedToList);
            Console.WriteLine();

            Console.WriteLine("Список DynamicList после применения метода AssignTo:");
            dynamicList.Print();
            Console.WriteLine("Список AssignedToList после применения метода AssignTo:");
            assignedToList.Print();
            Console.WriteLine();

            // Тестирование методов SaveToFile и LoadFromFile
            Console.WriteLine("--- ТЕСТИРОВКА SaveToFile и LoadFromFile ---\n");

            string dynamicListFile = "dynamicList.txt";
            string linkedListFile = "linkedList.txt";

            dynamicList.SaveToFile(dynamicListFile);
            linkedList.SaveToFile(linkedListFile);

            dynamicList.Clear();
            linkedList.Clear();

            dynamicList.LoadFromFile(dynamicListFile);
            linkedList.LoadFromFile(linkedListFile);

            Console.WriteLine("Список DynamicList после загрузки из файла:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после загрузки из файла:");
            linkedList.Print();
            Console.WriteLine();

            // Тестирование метода ForEach
            Console.WriteLine("--- ТЕСТИРОВКА ForEach ---\n");

            dynamicList.Add("one");
            dynamicList.Add("two");
            dynamicList.Add("three");

            linkedList.Add("one");
            linkedList.Add("two");
            linkedList.Add("three");

            dynamicList.ForEach(item => Console.WriteLine(item));
            Console.WriteLine();

            linkedList.ForEach(item => Console.WriteLine(item));
            Console.WriteLine();


            // Объединяем списки
            Console.WriteLine("--- ТЕСТИРОВКА оператора '+' ---\n");
            BaseList<string> mergedList = dynamicList + linkedList;

            // Выводим объединенный список
            Console.WriteLine("Объединенный список:");
            mergedList.Print();


            Console.WriteLine("--- ТЕСТИРОВКА метода Sort() ---\n");
            BaseList<int> numbers = new DynamicList<int>();
            numbers.Add(5);
            numbers.Add(2);
            numbers.Add(8);
            numbers.Add(1);

            Console.WriteLine("Исходный список чисел:");
            numbers.Print();

            numbers.Sort();

            Console.WriteLine("Список чисел после сортировки:");
            numbers.Print();

            BaseList<string> strings = new DynamicList<string>();
            strings.Add("one");
            strings.Add("two");
            strings.Add("three");
            strings.Add("number");

            Console.WriteLine("Исходный список строк:");
            strings.Print();

            strings.Sort();

            Console.WriteLine("Список строк после сортировки:");
            strings.Print();


            Console.WriteLine("--- ТЕСТИРОВКА метода AddRange() ---");
            BaseList<int> TestNumbers = new DynamicList<int>();
            TestNumbers.AddRange(1, 2, 3, 4, 5);
            TestNumbers.Print();



            Console.WriteLine("--- ВЫЗОВ МЕТОДА ТЕСТИРОВКИ ---");
            TestPerformance();
        }

        public static void TestPerformance()
        {
            Random random = new Random();

            BaseList<string> dynamicList = new DynamicList<string>();
            BaseList<string> linkedList = new LinkedList<string>();

            for (int i = 0; i < 10; i++)
            {
                int operation = random.Next(5); // Выбор операции
                string value = "Value" + random.Next(100); // Случайное значение
                int index = random.Next(1, 100); // Случайный индекс

                try
                {
                    switch (operation)
                    {
                        case 0:
                            dynamicList.Add(value);
                            linkedList.Add(value);
                            break;
                        case 1:
                            dynamicList.Insert(index % dynamicList.Count, value);
                            linkedList.Insert(index % linkedList.Count, value);
                            break;
                        case 2:
                            dynamicList.Delete(index);
                            linkedList.Delete(index);
                            break;
                        case 3:
                            dynamicList.Clear();
                            linkedList.Clear();
                            break;
                        case 4:
                            // Создаем несуществующий файл для вызова исключения BadFileException
                            dynamicList.LoadFromFile("nonexistent_file");
                            linkedList.LoadFromFile("nonexistent_file");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                    CountExceptions(dynamicList, e); // Учет исключений для динамического списка
                    CountExceptions(linkedList, e); // Учет исключений для связанного списка
                }
            }

            Console.WriteLine(dynamicList.Count == linkedList.Count);

            // Проверка на равенство списков
            bool areListsEqual = dynamicList.IsEqual(linkedList);
            Console.WriteLine($"Списки {(areListsEqual ? "одинаковы" : "различны")}.");
            Console.WriteLine("Тестирование завершено.");
            Console.WriteLine($"Количетсво изменений в динамик лист: {dynamicList.ChangeCount}");
            Console.WriteLine($"Количество изменений в линкед лист: {linkedList.ChangeCount}");

            Console.WriteLine("Количество срабатываний исключения BadIndexException для динамического списка: " + dynamicBadIndexExceptionCount);
            Console.WriteLine("Количество срабатываний исключения BadFileException для динамического списка: " + dynamicBadFileExceptionCount);
            Console.WriteLine("Количество срабатываний исключения BadIndexException для связанного списка: " + linkedBadIndexExceptionCount);
            Console.WriteLine("Количество срабатываний исключения BadFileException для связанного списка: " + linkedBadFileExceptionCount);
        }
        public static void CountExceptions<T>(BaseList<T> list, Exception ex) where T : IComparable<T>
        {
            if (ex is BadIndexException)
            {
                if (list is DynamicList<T>)
                {
                    dynamicBadIndexExceptionCount++;
                }
                else if (list is LinkedList<T>)
                {
                    linkedBadIndexExceptionCount++;
                }
            }
            else if (ex is BadFileException)
            {
                if (list is DynamicList<T>)
                {
                    dynamicBadFileExceptionCount++;
                }
                else if (list is LinkedList<T>)
                {
                    linkedBadFileExceptionCount++;
                }
            }
        }


    }
}
