/*Використовуючи підпрограму для знаходження найбільшого спільного
дільника (НСД), знайти значення виразу
S=(НСД(a,b)+ НСД(a,4))+ НСД(24,b)*/
using System;
namespace Application3
{
    class Program
    {
        static int GCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                while (b != 0)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }

                return a;
            }
        }
        static void Main()
        {
            Console.WriteLine("Введіть a, b");
            int a=int.Parse(Console.ReadLine());
            int b=int.Parse(Console.ReadLine());
            int s=GCD(a,b)+GCD(a,4)+GCD(24,b);
            Console.WriteLine($"Вираз- {s}");
        }
    }
}