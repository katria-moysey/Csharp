//Варіант 10
using System;

namespace Application2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("x");
            double x=double.Parse(Console.ReadLine());
            Console.WriteLine("e");
            double e =double.Parse(Console.ReadLine());
            double sum=0.0;
            double n;
            int y=0;
            do
            {   
                n=Math.Pow(x,2*y+1)/(2*y+1);
                sum+=n;
                y++;
            }
            while (Math.Abs(n) > e);
            Console.WriteLine($"S = {sum}");
            Console.WriteLine($"{Math.Atanh(x)}");

        }
    }
}