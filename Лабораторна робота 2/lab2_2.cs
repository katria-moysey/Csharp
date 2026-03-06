/* 10 Варіант */
using System;
namespace Program
{
    class Number
    {
        static void Main()
        {
            Console.WriteLine("Введіть своє числo x:");
            double x = double.Parse(Console.ReadLine());
            double z;
            if(1<=x && x<=3)
            {
                 z=Math.Log(x)-Math.Tan(x);
            }
            else if(3<x && x<=4)
            {
                 z=Math.Tan(x);
            }
            else
            {
                z=0;
            }
            Console.WriteLine($"Вираз = {z}");
        }
    }
}