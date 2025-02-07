class ArrayList()
{
    int[] buf = null;
    int count = 0;

    public void Add(int a)
    {
        //Если массив не иницализирован, то задаем ему начально значение 1
        if(buf == null)
        {
            buf = new int[1];
        }
        if(count == buf.Length)
        {
            Expand();
        }
        buf[count++] = a;
    }
    void Expand()
    {

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

