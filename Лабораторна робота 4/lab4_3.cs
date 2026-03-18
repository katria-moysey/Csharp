/* Нехай x_0=2, x_1=x_2=x_3=7
x_i= (x_i-1(1+x_i_2)x_i-3)/x_i-4
.Визначити x_n .*/
using System;
namespace Aplication5
{
    class Program{
        // Рекурсивний 
            static double Num(int x)
            {
                if (x == 0) return 2;
                if (x == 1 || x == 2 || x == 3) return 7;

                return (Num(x - 1) * (1 + Num(x - 2)) + Num(x - 3)) / Num(x - 4);
            }
        
        static void Main()
        {
            Console.WriteLine("Уведіть число: ");
            int n=int.Parse(Console.ReadLine());
            double number2=Num(n);
            Console.WriteLine($"Число {number1}");
            Console.WriteLine($"Число {number2}");
        }
    }
}
