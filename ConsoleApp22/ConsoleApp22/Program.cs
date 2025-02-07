using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = 1000;
            int searchIterations = 1000;
            Random random = new Random();

            // Initialize and populate ArrayList
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < numberOfElements; i++)
            {
                arrayList.Add(i);
            }

            // Initialize and populate ChainList
            ChainList chainList = new ChainList();
            for (int i = 0; i < numberOfElements; i++)
            {
                chainList.Add(i);
            }

            // ArrayList search test
            Stopwatch stopwatchArrayList = new Stopwatch();
            stopwatchArrayList.Start();
            for (int i = 0; i < searchIterations; i++)
            {
                int pos = random.Next(numberOfElements);
                int value = arrayList[pos];
            }
            stopwatchArrayList.Stop();
            Console.WriteLine($"ArrayList search time: {stopwatchArrayList.ElapsedMilliseconds} ms");

            // ChainList regular search test
            Stopwatch stopwatchChainListRegular = new Stopwatch();
            stopwatchChainListRegular.Start();
            for (int i = 0; i < searchIterations; i++)
            {
                int pos = random.Next(numberOfElements);
                int value = chainList[pos];
            }
            stopwatchChainListRegular.Stop();
            Console.WriteLine($"ChainList regular search time: {stopwatchChainListRegular.ElapsedMilliseconds} ms");

            // ChainList fast search test
            Stopwatch stopwatchChainListFast = new Stopwatch();
            stopwatchChainListFast.Start();
            for (int i = 0; i < searchIterations; i++)
            {
                int pos = random.Next(numberOfElements);
                ChainList.Node node = chainList.FindFast(pos);
                //int value = node.Data;
            }
            stopwatchChainListFast.Stop();
            Console.WriteLine($"ChainList fast search time: {stopwatchChainListFast.ElapsedMilliseconds} ms");
        }
    }

    internal class ChainList
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(int data, Node next = null, Node prev = null)
            {
                Data = data;
                Next = next;
                Prev = prev;
            }
        }

        private Node head = null;
        private int count = 0;
        private Node[] skipNodes;

        public ChainList()
        {
            skipNodes = new Node[100]; // Инициализация массива ссылок на каждые 20 узлов
        }

        public void Add(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                if (count % 20 == 0) skipNodes[count / 20] = head;
            }
            else
            {
                Node lastNode = Find(count - 1);
                Node newNode = new Node(data, null, lastNode);
                lastNode.Next = newNode;
                if (count % 20 == 0) skipNodes[count / 20] = newNode;
            }
            count++;
        }

        public int this[int i]
        {
            get
            {
                Node node = Find(i);
                if (node == null)
                {
                    System.Environment.Exit(0);
                    return 0;
                }
                return node.Data;
            }
        }

        private Node Find(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                return null;
            }

            int skipIndex = pos / 20;
            Node p = skipNodes[skipIndex];

            if (p == null)
            {
                p = head;
                for (int i = 0; i < skipIndex * 20; i++)
                {
                    p = p.Next;
                }
                skipNodes[skipIndex] = p;
            }

            int localPos = pos % 20;
            for (int i = 0; i < localPos; i++)
            {
                p = p.Next;
            }

            return p;
        }

        public Node FindFast(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                return null;
            }

            int skipIndex = pos / 20;
            Node p = skipNodes[skipIndex];

            int localPos = pos % 20;
            int direction = localPos > 10 ? -1 : 1;

            if (direction == 1)
            {
                for (int i = 0; i < localPos; i++)
                {
                    p = p.Next;
                }
            }/*
            else
            {
                p = skipNodes[skipIndex + 1];
                for (int i = 0; i < (20 - localPos); i++)
                {
                    p = p.Prev;
                }
            }*/

            return p;
        }
    }

    internal class ArrayList
    {
        private int[] array;
        private int count;

        public ArrayList()
        {
            array = new int[0];
            count = 0;
        }

        public void Add(int a)
        {
            EnsureCapacity();
            array[count] = a;
            count++;
        }

        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    System.Environment.Exit(0);
                    return 0;
                }

                return array[i];
            }
        }

        private void EnsureCapacity()
        {
            if (count == array.Length)
            {
                int[] temp;
                if (array.Length == 0)
                {
                    temp = new int[2];
                }
                else
                {
                    temp = new int[array.Length * 2];
                }
                for (int i = 0; i < array.Length; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }
        }
    }
}
