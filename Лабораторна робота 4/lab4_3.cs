/* Нехай x_0=2, x_1=x_2=x_3=7
x_i= (x_i-1(1+x_i_2)x_i-3)/x_i-4
.Визначити x_n .*/
using System;
namespace Aplication5
{
    class Program{
        // Рекурсивний (повільніший)
            static double Num(int x)
            {
                if (x == 0) return 2;
                if (x == 1 || x == 2 || x == 3) return 7;

                return (Num(x - 1) * (1 + Num(x - 2)) + Num(x - 3)) / Num(x - 4);
            }
        // Ітеративний (швидкіший)
            static double Nums(int n)
        {
            if (n == 0) return 2;
            if (n >= 1 && n <= 3) return 7;
            double[] x = new double[n + 1];
            x[0] = 2;
            x[1] = 7;
            x[2] = 7;
            x[3] = 7;

            for (int i = 4; i <= n; i++)
            {
                x[i] = (x[i - 1] * (1 + x[i - 2]) + x[i - 3]) / x[i - 4];
            }

            return x[n];
        }

        
        static void Main()
        {
            Console.WriteLine("Уведіть число: ");
            int n=int.Parse(Console.ReadLine());
            double number2=Num(n);
            double number1=Nums(n);
            Console.WriteLine($"Число {number1}");
            Console.WriteLine($"Число {number2}");
        }
    }
}