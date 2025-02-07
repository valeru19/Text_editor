class Program
{
    static void Main(string[] args)
    {
        int limit = int.Parse(Console.ReadLine());

        for (int i = limit * 3; i > limit; i--)
        {
            Console.WriteLine(i);
        }
        Console.ReadLine();
    }
}