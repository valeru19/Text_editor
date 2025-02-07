using LAB_2;

internal class Test
{
    static void Main(string[] args)
    {

        BaseList abstr = new ArrList();
        BaseList chain = new ChainList();

        Random rnd = new();

        int iter = 100;

        for (int i = 0; i < iter; i++)
        {
            int ops = rnd.Next(5);
            int value = rnd.Next(100);
            int pos = rnd.Next(2000);

            switch (ops)
            {
                case 0:

                    abstr.Add(value);
                    chain.Add(value);
                    break;

                case 1:

                    abstr.Delete(pos);
                    chain.Delete(pos);
                    break;

                case 2:

                    abstr.Insert(value, pos);
                    chain.Insert(value, pos);

                    break;

                /*case 3:
                    //Console.WriteLine("clr");
                    abstr.Clear();
                    chain.Clear();
                    break;*/

                case 4:

                    abstr[pos] = value;
                    chain[pos] = value;
                    break;
            }
        }

        abstr.Sort();
        chain.Sort();

        if (abstr.IsEqual(chain)) Console.WriteLine("1 Good");
        else Console.WriteLine("Error");

        for (int i = 0; i < iter; i++)
        {
            int ops2 = rnd.Next(6);

            switch (ops2)
            {
                case 0:
                    //Console.WriteLine("0");
                    chain = abstr.Clone();
                    break;

                case 1:
                    //Console.WriteLine("1");
                    abstr = chain.Clone();
                    break;

                case 2:
                    //Console.WriteLine("2");
                    abstr.Assign(chain);
                    break;

                case 3:
                    //Console.WriteLine("3");
                    chain.Assign(abstr);
                    break;

                case 4:
                    //Console.WriteLine("4");
                    chain.AssignTo(abstr);
                    break;

                case 5:
                    //Console.WriteLine("5");
                    abstr.AssignTo(chain);
                    break;
            }
        }

        if (abstr.IsEqual(chain)) Console.WriteLine("2 Good");
        else Console.WriteLine("Error");

        
        
        abstr.Show();
        Console.WriteLine("\n\n");
        chain.Show();
        Console.WriteLine("\n\n");

        
        
        chain.Print();

        Console.WriteLine($"Arr count = {abstr.Count}, Chain count = {chain.Count}\n");

        
        Console.ReadKey();
    }
}