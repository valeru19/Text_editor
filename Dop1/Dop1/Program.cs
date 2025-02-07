using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using static Dop1.DabbleLinkedList;
using static Dop1.LinkedList;
using static Dop1.ArrayList;
using System.Collections;

namespace Lab1CS
{
    class Test
    {
        static void Main(string[] args)
        {

            ArrayList abstr = new ArrayList();
            ChainList chain = new ChainList();
            DoublyList doubly = new DoublyList();

            Stopwatch sw_arr = new Stopwatch();
            Stopwatch sw_chain = new Stopwatch();
            Stopwatch sw_doubly = new Stopwatch();

            Random rnd = new Random();

            int iter = 100000;

            for (int i = 0; i < iter; i++)
            {
                int ops = rnd.Next(4);
                int value = rnd.Next(100);
                int pos = rnd.Next(2000);

                switch (ops)
                {
                    case 0:

                        sw_arr.Start();
                        abstr.Add(value);
                        sw_arr.Stop();

                        sw_chain.Start();
                        chain.Addit(value);
                        sw_chain.Stop();

                        sw_doubly.Start();
                        doubly.Add(value);
                        sw_doubly.Stop();

                        break;

                    case 1:

                        sw_arr.Start();
                        abstr.Del(pos);
                        sw_arr.Stop();

                        sw_chain.Start();
                        chain.Delete(pos);
                        sw_chain.Stop();

                        sw_doubly.Start();
                        doubly.Delete(pos);
                        sw_doubly.Stop();
                        break;

                    case 2:

                        sw_arr.Start();
                        abstr.Ins(value, pos);
                        sw_arr.Stop();

                        sw_chain.Start();
                        chain.Insert(value, pos);
                        sw_chain.Stop();

                        sw_doubly.Start();
                        doubly.Insert(value, pos);
                        sw_doubly.Stop();
                        break;

                    /*case 3:                       
                        abstr.Clr();
                        chain.Clear();
                        doubly.Clear();
                        break;*/

                    case 4:

                        sw_arr.Start();
                        abstr[pos] = value;
                        sw_arr.Stop();

                        sw_chain.Start();
                        chain[pos] = value;
                        sw_chain.Stop();

                        sw_doubly.Start();
                        doubly[pos] = value;
                        sw_doubly.Stop();
                        break;
                }
            }
            void Checker()
            {
                bool checker = true;
                for (int i = 0; i < abstr.Count; i++)
                {
                    if (!(abstr[i] == chain[i] && abstr[i] == doubly[i] && chain[i] == doubly[i]))
                    {
                        checker = false;
                        Console.WriteLine($"Не сошлись [{i}] у chain = {chain[i]}, у doubly = {doubly[i]}\n");
                    }
                }
                if (checker == true) Console.WriteLine("Успешно\n");
                else Console.WriteLine("Ошибка\n");
            }

            Checker();
            Console.WriteLine($"Arr cnt = {abstr.Count}, Chain cnt = {chain.Count}, Doubly cnt = {doubly.Count}\n");
            Console.WriteLine($"Arr time = {sw_arr.ElapsedMilliseconds}, Chain time = {sw_chain.ElapsedMilliseconds}, Doubly time = {sw_doubly.ElapsedMilliseconds}\n");

            /*abstr.Shw();
            Console.WriteLine("\n\n");
            chain.Show();
            Console.WriteLine("\n\n");
            doubly.Show();*/

            Console.WriteLine("\n\nНажмите любую клавишу");
            Console.ReadKey();
        }


    }
}
