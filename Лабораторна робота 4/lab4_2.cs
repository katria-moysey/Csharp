/* Дано послідовність натуральних чисел n a1 ,a2 ,...,an. Використовуючи підпрограму, яка дозволяє встановити, чи є послідовність із 
чотирьох чисел геометричною прогресією, знайти кількість послідовно розміщених четвірок чисел, які утворюють геометричну прогресію*/
using System;
namespace Aplication4
{
    class Program{
        static bool IsGeometricProgression(params int[] numbers)
        {
            bool progression = numbers[1]*numbers[1]==numbers[0]*numbers[2] && numbers[2]*numbers[2]==numbers[1]*numbers[3];
            return progression;
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
               count+=IsGeometricProgression(numbers[i],numbers[i+1],numbers[i+2],numbers[i+3]) ? 1 : 0;
            }
            Console.WriteLine($"Число геометричних прогресій {count}");
        }
    }
}
