using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3_ev
{
    public class ChainList : BaseList
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(int data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        private Node head = null;
        private List<Node> nodeArray = new List<Node>(); // Динамический список ссылок на каждый двадцатый узел

        public ChainList()
        {
        }

        private void UpdateReferenceNodes()
        {
            nodeArray.Clear();
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (index % 20 == 0)
                {
                    nodeArray.Add(current);
                }
                current = current.Next;
                index++;
            }
        }

        private Node Find(int posit)
        {
            if (posit >= count || head == null) return null; // Если позиция за пределами списка или список пуст, возвращаем null

            int blockIndex = posit / 20;
            Node current = blockIndex < nodeArray.Count ? nodeArray[blockIndex] : head;
            int currentIndex = blockIndex * 20;

            while (current != null && currentIndex < posit)
            {
                current = current.Next;
                currentIndex++;
            }

            return current;
        }

        public override Node FindFast(int posit)
        {
            if (posit >= count || head == null) return null;

            int blockIndex = posit / 20;
            Node current = blockIndex < nodeArray.Count ? nodeArray[blockIndex] : head;
            int currentIndex = blockIndex * 20;

            if (posit >= currentIndex)
            {
                while (current != null && currentIndex < posit)
                {
                    current = current.Next;
                    currentIndex++;
                }
            }
            else
            {
                while (current != null && currentIndex > posit)
                {
                    current = current.Prev;
                    currentIndex--;
                }
            }

            return current;
        }

        public override void Add(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                nodeArray.Add(head);
            }
            else
            {
                Node last = Find(count - 1);
                Node newNode = new Node(value);
                last.Next = newNode;
                newNode.Prev = last;

                if (count % 20 == 0)
                {
                    nodeArray.Add(newNode);
                }
            }
            count++;
        }

        public override void Insert(int value, int posit)
        {
            if (posit == count)
            {
                Add(value);
                return;
            }
            else if (posit < count)
            {
                Node newNode = new Node(value);
                Node current = FindFast(posit);

                if (current == head)
                {
                    newNode.Next = current;
                    current.Prev = newNode;
                    head = newNode;
                }
                else
                {
                    Node prev = current.Prev;
                    newNode.Next = current;
                    newNode.Prev = prev;
                    prev.Next = newNode;
                    current.Prev = newNode;
                }

                if (posit % 20 == 0)
                {
                    UpdateReferenceNodes();
                }

                count++;
            }
        }

        public override void Delete(int posit)
        {
            if (posit < count && posit > 0)
            {
                Node prev = Find(posit - 1);
                Node current = prev.Next;
                prev.Next = current.Next;
                if (current.Next != null)
                {
                    current.Next.Prev = prev;
                }
                count--;
                UpdateReferenceNodes();
            }
            else if (posit == 0 && posit < count)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
                count--;
                UpdateReferenceNodes();
            }
            else if (posit == 0 && count == 1)
            {
                head = null;
                count--;
                UpdateReferenceNodes();
            }
        }

        public override void Clear()
        {
            head = null;
            count = 0;
            nodeArray.Clear();
        }

        public override int this[int i]
        {
            get
            {
                if (i >= count || i < 0) return 0;

                Node node = FindFast(i);
                return node.Data;
            }
            set
            {
                if (i >= count || i < 0) return;

                Node node = FindFast(i);
                node.Data = value;
            }
        }

        public override void Show()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        protected override BaseList Dummy()
        {
            return new ChainList();
        }

        public override void Sort()
        {
            if (count <= 1) return;

            bool swapped;
            do
            {
                swapped = false;
                Node current = head;
                while (current != null && current.Next != null)
                {
                    if (current.Data > current.Next.Data)
                    {
                        int temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }
    }
}
