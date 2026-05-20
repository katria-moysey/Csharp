/*Дано стек цілих чисел, який складається з n елементів.
Визначити суму і добуток додатних чисел, що стоять на парних
позиціях.*/ 
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Уведіть ваше число");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Уведіть ваші числа");
        Stack<int> stack = new Stack<int>(new int[] { });
        for ( int i =0; i<n; i++)
        {
            int element= int.Parse(Console.ReadLine());
            stack.Push(element);
        }

        
        int sum = 0;
        int product = 1;
        int position = 0;

        foreach (int number in stack)
        {
            if (position % 2 != 0 && number > 0)
            {
                sum += number;
                product *= number;
            }
            position++;
        }

        if (sum != 0)
        {
            Console.WriteLine($"Добуток додатних чисел на парних позиціях: {product}");
            Console.WriteLine($"Сума додатних чисел на парних позиціях: {sum}");
        }

        else
            Console.WriteLine("Додатних чисел на парних позиціях немає.");
    }
}