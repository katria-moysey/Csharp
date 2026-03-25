/*10. Об’єкт “Множина цифр”
поля ▪ для зберігання множини цифр;
методи ▪ додавання нової цифри;
▪ виведення цифр, які входять у множину на екран;
▪ знаходження найбільшої цифри;
▪ знаходження суми цифр.*/
using System;

namespace Lab5
{
    class Set
    {
        public int[] set;
        public int count;

        public Set()
        {
            set = new int[10];
            count = 0;
        }

        public void Add(int number)
        {
            if (number < 0 || number > 9)
            {
                Console.WriteLine("Можна додавати тільки цифри від 0 до 9.");
                return;
            }


            for (int i = 0; i < count; i++)
            {
                if (set[i] == number)
                {
                    Console.WriteLine($"Цифра {number} вже є у множині.");
                    return;
                }
            }
                set[count] = number;
                count++;
        }

        public void Print()
        {
            Console.Write("Множина містить: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(set[i] + " ");
            }
            Console.WriteLine();
        }

        public int Max()
        {
            int max = set[0];
            for (int i = 1; i < count; i++)
            {
                if (set[i] > max)
                {
                    max = set[i];
                }
            }
            return max;
        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += set[i];
            }
            return sum;
        }
    }

    class Program
    {
        static void Main()
        {
            Set set1 = new Set();

            Console.Write("Скільки чисел ви хочете ввести? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введіть {i + 1} число: ");
                int number = int.Parse(Console.ReadLine());
                set1.Add(number);
            }
            set1.Print();
            Console.WriteLine($"Найбільша цифра: {set1.Max()}");
            Console.WriteLine($"Сума всіх цифр: {set1.Sum()}");
        }
    }
}