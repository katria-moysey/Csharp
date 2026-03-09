/*10
Дано натуральне число n. Обчислити 
s = (2^2 + 4^2 + ... + 2n^2 )+( 3 ^3+ 5^3 + ... + (2n +1)^3)*/
using System;
namespace Application1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Уведіть своє наутральне число ");
            int n = int.Parse(Console.ReadLine());
            int sum_2=0;
            int sum_3=0;
            for (int i=1;i<=n; i++)
                sum_2+=2*i*2*i;
            
            for (int i=1;i<=n; i++)
                sum_3+=(2*i+1)*(2*i+1)*(2*i+1);
            int s=sum_2+sum_3;
            Console.Write($"S = {s}");
        }
    }
}