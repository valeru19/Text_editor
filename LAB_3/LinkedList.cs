using System;

namespace MyLists
{
    public class LinkedList<T> : BaseList<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private int count;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public override int Count => count;

        public override void Add(T item)
        {
            if (head == null)
            {
                head = new Node(item);
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(item);
            }
            count++;
            OnChange(EventArgs.Empty); //1
        }

        public override void Insert(int pos, T item)
        {
            if (pos < 0 || pos > count)
            {
                throw new BadIndexException("Position is out of range");
            }

            Node newNode = new Node(item);

            if (pos == 0)
            {
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
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            count++;
            OnChange(EventArgs.Empty); //2
        }

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                throw new BadIndexException("Position is out of range");
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
            OnChange(EventArgs.Empty); //3
        }

        public override void Clear()
        {
            head = null;
            count = 0;
            OnChange(EventArgs.Empty); //4
        }

        public override T this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
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
                    throw new BadIndexException("Index is out of range");
                }

                Node current = head;
                for (int j = 0; j < i; j++)
                {
                    current = current.Next;
                }
                current.Data = value;
                OnChange(EventArgs.Empty); //5
            }
        }

        protected override BaseList<T> CloneInternal()
        {
            LinkedList<T> clone = new LinkedList<T>();
            Node current = head;
            Node cloneCurrent = null;
            while (current != null)
            {
                if (clone.head == null)
                {
                    clone.head = new Node(current.Data);
                    cloneCurrent = clone.head;
                }
                else
                {
                    cloneCurrent.Next = new Node(current.Data);
                    cloneCurrent = cloneCurrent.Next;
                }
                current = current.Next;
            }
            clone.count = count;
            return clone;
        }
    }
}