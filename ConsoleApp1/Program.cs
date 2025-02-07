class ArrList
{
    int[] buf = null;
    int count = 0;

    public void Add(int a)
    {
        //Если массив не инициализирован,создаем его с размером 1
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

    }
    void Expand()
    {

    }
}

class ChainList()
{
    class Node
    {
        public int Data { set; get; }
        public Node Next { set; get; }
        public Node(int data, Node next)
        {
            this.Data = data;
            this.Next = null;
        }
        
    }

    Node head = null;
    int count = 0;
    Node Find(int pos)
    {
        if (pos >= count) return null;
        int i = 0;
        Node p = head;
        while (p != null && i < pos)
        {
            p = p.Next;
            i++;
        }
        if (i == pos) return p;
        else return null;
    }
}