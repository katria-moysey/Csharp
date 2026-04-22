/*10. Клас “квадратна матриця ” – TSMatrix
поля ▪ для зберігання елементів матриці;
▪ для зберігання розмірності матриці.
методи 
▪ конструктор без параметрів, конструктор з параметрами, конструктор копіювання;
▪ введення/виведення даних;
▪ знаходження найбільшого/найменшого елемента;
▪ знаходження суми елементів.
▪ перевантаження операторів + (додавання елементів), – (віднімання елементів)..*/
using System;

namespace Lab5
{
    class TSMatrix
    {
        private int[,] matrix;
        private int size;
        public TSMatrix()
        {
            size = 3;
            matrix = new int[size, size];
        }

        public TSMatrix(int size)
        {
                this.size = size;

            matrix = new int[this.size, this.size];
        }

        public TSMatrix(TSMatrix m)
        {
            this.size = m.size;
            this.matrix = new int[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    this.matrix[i, j] = m.matrix[i, j];
        }

        public void Enter()
        {
            Console.WriteLine($"Введіть елементи матриці {size}x{size}:");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"[{i},{j}] = ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void Print()
        {

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int Max()
        {
            int max = matrix[0, 0];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (matrix[i, j] > max)
                        max = matrix[i, j];

            return max;
        }


        public int Min()
        {
            int min = matrix[0, 0];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (matrix[i, j] < min)
                        min = matrix[i, j];

            return min;
        }
        public int Sum()
        {
            int sum = 0;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    sum += matrix[i, j];

            return sum;
        }

        public static TSMatrix operator +(TSMatrix a, TSMatrix b)
        {

            TSMatrix result = new TSMatrix(a.size);

            for (int i = 0; i < a.size; i++)
                for (int j = 0; j < a.size; j++)
                    result.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];

            return result;
        }
        public static bool operator ==(TSMatrix a, TSMatrix b)
        {
            for (int i = 0; i < a.size; i++)
                for (int j = 0; j < a.size; j++)
                    if(a.matrix[i, j]!=b.matrix[i, j])
                    {
                        return false;
                    }

            return true;
        }

        public static TSMatrix operator -(TSMatrix a, TSMatrix b)
        {

            TSMatrix result = new TSMatrix(a.size);

            for (int i = 0; i < a.size; i++)
                for (int j = 0; j < a.size; j++)
                    result.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введіть розмір матриці: ");
            int n = int.Parse(Console.ReadLine());

            TSMatrix m1 = new TSMatrix(n);
            TSMatrix m2 = new TSMatrix(n);

            Console.WriteLine("Матриця 1:");
            m1.Enter();

            Console.WriteLine("Матриця 2:");
            m2.Enter();

            Console.WriteLine("Матриця 1:");
            m1.Print();
            Console.WriteLine($"Max: {m1.Max()}");
            Console.WriteLine($"Min: {m1.Min()}");
            Console.WriteLine($"Sum: {m1.Sum()}");

            Console.WriteLine("Матриця 2:");
            m2.Print();
            Console.WriteLine($"Max: {m2.Max()}");
            Console.WriteLine($"Min: {m2.Min()}");
            Console.WriteLine($"Sum: {m2.Sum()}");
            Console.WriteLine("Сума матриць:");
            
            TSMatrix m3 = m1 + m2;
            m3.Print();
            
            Console.WriteLine("Різниця матриць:");
            TSMatrix m4 = m1 - m2;
            
            m4.Print();
        }
    }
}