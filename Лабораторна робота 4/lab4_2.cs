/* Дано послідовність натуральних чисел n a1 ,a2 ,...,an. Використовуючи підпрограму, яка дозволяє встановити, чи є послідовність із 
чотирьох чисел геометричною прогресією, знайти кількість послідовно розміщених четвірок чисел, які утворюють геометричну прогресію*/
using System;
namespace Aplication4
{
    class Program{
        static int GeometricProgression(int x1,int x2,int x3,int x4)
        {
            bool progression = x2*x2==x1*x3 && x3*x3==x2*x4;

            if(progression)
            {
                return 1;
            }
            return 0;
        }
        static void Main()
        {
            Console.WriteLine("Уведіть кількість чисел: ");
            int n=int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            Console.WriteLine("Уведіть свою послідовність: ");
            for (int i = 0; i < n; i++)
                {
                numbers[i]=int.Parse(Console.ReadLine());
                }
            int count=0;
            for (int i=0; i<n-3; i++)
            {
               count+=GeometricProgression(numbers[i],numbers[i+1],numbers[i+2],numbers[i+3]);
            }
            Console.WriteLine($"Число геометричних прогресій {count}");
        }
    }
}
