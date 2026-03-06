/* 10 Дано три різні числа дійсних числа: a, b, c . Знайти ( min (a,b,c))^2 */
using System;
namespace Program
{
    class Minnumber
    {
        static void Main()
        {
            Console.WriteLine("Введіть свої числа: ");
            Console.Write("a ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c ");
            double c = double.Parse(Console.ReadLine());
            double number;
            if(a<c && a < b)
            {
                 number=a;
            }
            else if(b<c && b < a)
            {
                 number=b;
            }
            else
            {
                number=c;
            }
            double state= number*number;
            Console.WriteLine("Мінімальне значення = {0}, Вираз = {1}",number,state);
        }
    }
}