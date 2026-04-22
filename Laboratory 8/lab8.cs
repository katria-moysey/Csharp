/*10.Варіант 10.
1. Описати клас, який містять вказані поля і методи.
Клас “одновимірний масив” – TArray
поля ▪ для зберігання елементів масиву;
▪ для зберігання кількості елементів.
методи ▪ конструктор без параметрів, конструктор з параметрами,
конструктор копіювання;
▪ введення/виведення даних;
▪ знаходження найбільшого/найменшого елемента;
▪ сортування масиву;
▪ знаходження суми елементів;
▪ перевантаження операторів + (додавання елементів), –
(віднімання елементів), * (множення масиву на число).
2. Створити клас-нащадок TOderedArray (упорядкований масив) на основі класу TArray.
Додати методи додавання та вилучення елементів (перевизначивши оператори додавання
та віднімання числа).
3. Створити програму-клієнт для тестування. */

using System;

namespace lab8
{
    public class TArray
    {
        protected double[] array;
        protected int size;

        public int Size
        {
            get { return size; }
            set
            {
                if (value > 0)
                    size = value;
            }
        }

        public TArray()
        {
            size = 10;
            array = new double[size];
        }

        public TArray(int size)
        {
            if (size > 0)
                this.size = size;
            else
                this.size = 10;

            array = new double[this.size];
        }

        public TArray(params double[] a)
        {
            size = a.Length;
            array = new double[size];
            for (int i = 0; i < size; i++)
                array[i] = a[i];
        }

        public TArray(TArray a)
        {
            size = a.size;
            array = new double[size];
            for (int i = 0; i < size; i++)
                array[i] = a.array[i];
        }

        public double this[int i]
        {
            get
            {
                if (i >= 0 && i < size)
                    return array[i];
                else
                    return 0;
            }
            set
            {
                if (i >= 0 && i < size)
                    array[i] = value;
            }
        }

        public void Enter()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"[{i}] = ");
                array[i] = double.Parse(Console.ReadLine());
            }
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }

        public void Sort()
        {
            for (int i = 0; i < size - 1; i++)
                for (int j = 0; j < size - i - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        (array[j +1], array[j]) = (array[j], array[j +1]);
                    }
        }

        public double Max()
        {
            double max = array[0];
            for (int i = 1; i < size; i++)
                if (array[i] > max)
                    max = array[i];
            return max;
        }

        public double Min()
        {
            double min = array[0];
            for (int i = 1; i < size; i++)
                if (array[i] < min)
                    min = array[i];
            return min;
        }

        public double Sum()
        {
            double sum = 0;
            for (int i = 0; i < size; i++)
                sum += array[i];
            return sum;
        }

        public static TArray operator +(TArray a, double number)
        {

            TArray r = new TArray(a.size);

            for (int i = 0; i < a.size; i++)
                r.array[i] = a.array[i] + number;

            return r;
        }

        public static TArray operator -(TArray a, double number)
        {

            TArray r = new TArray(a.size);

            for (int i = 0; i < a.size; i++)
                r.array[i] = a.array[i] - number;

            return r;
        }

        public static TArray operator *(TArray a, double number)
        {
            TArray r = new TArray(a.size);

            for (int i = 0; i < a.size; i++)
                r.array[i] = a.array[i] * number;

            return r;
        }
    }

    public class TOrderedArray : TArray
    {
        public TOrderedArray() : base() { }

        public TOrderedArray(int size) : base(size) { }

        public TOrderedArray(TArray a) : base(a)
        {
            Sort();
        }

        public new void Enter()
        {
            base.Enter();
            Sort();
        }

        public static TOrderedArray operator +(TOrderedArray a, double number)
        {
            TOrderedArray r = new TOrderedArray(a.size + 1);

            for (int i = 0; i < a.size; i++)
                r.array[i] = a.array[i];

            r.array[a.size] = number;
            r.Sort();

            return r;
        }
        public static TOrderedArray operator -(TOrderedArray a, double number)
        {
            int count = 0;
            for (int i = 0; i < a.size; i++)
                if (a.array[i] == number)
                    count++;
            if (count==0)
            {
                Console.WriteLine("Цього числа нема в масиву");
                return a;
            }

            TOrderedArray r = new TOrderedArray(a.size - count);

            int k = 0;
            for (int i = 0; i < a.size; i++)
            {
                if (a.array[i] != number)
                {
                    r.array[k] = a.array[i];
                    k++;
                }
            }

            r.Sort();
            return r;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введіть розмір масиву: ");
            int n = int.Parse(Console.ReadLine());

            TOrderedArray a = new TOrderedArray(n);

            Console.WriteLine("Введіть елементи масиву:");
            a.Enter();

            Console.WriteLine("Упорядкований масив:");
            a.Print();

            Console.WriteLine("Максимум = " + a.Max());
            Console.WriteLine("Мінімум = " + a.Min());
            Console.WriteLine("Сума = " + a.Sum());

            Console.Write("Введіть число для додавання: ");
            double x = double.Parse(Console.ReadLine());
            a = a + x;

            Console.WriteLine("Після додавання:");
            a.Print();

            Console.Write("Введіть число для вилучення: ");
            double y = double.Parse(Console.ReadLine());
            a = a - y;

            Console.WriteLine("Після вилучення:");
            a.Print();

            Console.Write("Введіть число для множення: ");
            double k = double.Parse(Console.ReadLine());
            TArray b = a * k;

            Console.WriteLine("Після множення на число:");
            b.Print();
        }
    }
}
    
