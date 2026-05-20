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
    public class TArray<T> where T : IComparable<T>
    {
        protected T[] array;
        protected int size;

        public int Size
        {
            get { return size; }
        }

        public TArray()
        {
            size = 10;
            array = new T[size];
        }

        public TArray(int size)
        {
            if (size > 0)
                this.size = size;
            else
                this.size = 10;

            array = new T[this.size];
        }

        public TArray(params T[] a)
        {
            size = a.Length;
            array = new T[size];

            for (int i = 0; i < size; i++)
                array[i] = a[i];
        }

        public TArray(TArray<T> a)
        {
            size = a.size;
            array = new T[size];

            for (int i = 0; i < size; i++)
                array[i] = a.array[i];
        }

        public T this[int i]
        {
            set
            {
            if (i < 0 || i >= size)
            throw new Exception("Iндекс елемента виходить за межi масиву.");
            array[i] = value;
            }
            get
            {
            if (i < 0 || i >= size)
            throw new Exception("Iндекс елемента виходить за межi масиву.");
            return array[i];
            }

        }

        public  void Enter()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"[{i}] = ");
                array[i] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            }
        }

public void Print()
{
    for (int i = 0; i < size; i++)
        Console.Write($"{array[i]:0.##} ");

    Console.WriteLine();
}

        public void Sort()
        {
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        (array[j+1], array[j]) = (array[j], array[j+1]);
                    }
                }
            }
        }

        public T Max()
        {
            T max = array[0];

            for (int i = 1; i < size; i++)
            {
                if (array[i].CompareTo(max) > 0)
                    max = array[i];
            }

            return max;
        }

        public T Min()
        {
            T min = array[0];

            for (int i = 1; i < size; i++)
            {
                if (array[i].CompareTo(min) < 0)
                    min = array[i];
            }

            return min;
        }

        public T Sum()
        {
            dynamic sum = default(T);

            for (int i = 0; i < size; i++)
                sum += array[i];

            return sum;
        }

        public static TArray<T> operator +(TArray<T> a, T number)
        {
            TArray<T> r = new TArray<T>(a.size);

            for (int i = 0; i < a.size; i++)
                r.array[i] = (dynamic)a.array[i] + number;

            return r;
        }

        public static TArray<T> operator -(TArray<T> a, T number)
        {
            TArray<T> r = new TArray<T>(a.size);

            for (int i = 0; i < a.size; i++)
                r.array[i] = (dynamic)a.array[i] - number;

            return r;
        }

        public static TArray<T> operator *(TArray<T> a, T number)
        {
            TArray<T> r = new TArray<T>(a.size);

            for (int i = 0; i < a.size; i++)
                r.array[i] = (dynamic)a.array[i] * number;

            return r;
        }
    }

    public class TOrderedArray<T> : TArray<T> where T : IComparable<T>
    {
        public TOrderedArray() : base() { }

        public TOrderedArray(int size) : base(size) { }

        public TOrderedArray(TArray<T> a) : base(a)
        {
            Sort();
        }

        public new void Enter()
        {
            base.Enter();
            Sort();
        }

        public static TOrderedArray<T> operator +(TOrderedArray<T> a, T number)
        {
            TOrderedArray<T> r = new TOrderedArray<T>(a.size + 1);

            for (int i = 0; i < a.size; i++)
                r.array[i] = a.array[i];

            r.array[a.size] = number;
            r.Sort();

            return r;
        }

        public static TOrderedArray<T> operator -(TOrderedArray<T> a, T number)
        {
            int count = 0;

            for (int i = 0; i < a.size; i++)
            {
                if (a.array[i].CompareTo(number) == 0)
                    count++;
            }

            if (count == 0)
            {
                Console.WriteLine("Цього елемента немає в масиві");
                return a;
            }

            TOrderedArray<T> r = new TOrderedArray<T>(a.size - count);

            int k = 0;

            for (int i = 0; i < a.size; i++)
            {
                if (a.array[i].CompareTo(number) != 0)
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

            TOrderedArray<double> a = new TOrderedArray<double>(n);

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

            TArray<double> b = a * k;

            Console.WriteLine("Після множення на число:");
            b.Print();
        }
    }
}