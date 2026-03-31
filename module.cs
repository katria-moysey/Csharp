using System;

namespace Module
{
    public interface IMeasurable
    {
        void Specify();
        void Print();
        double Area();
    }

    public class ConvexQuadrilateral : IMeasurable
    {
        protected int[,] coordinates;
        protected int amount;

        public int Amount
        {
            get { return amount; }
            set
            {
                if (value > 0)
                    amount = value;
            }
        }

        public ConvexQuadrilateral()
        {
            Amount = 4;
            coordinates = new int[Amount, 2];
        }

        public virtual void Specify()
        {
            Console.WriteLine("Введіть координати 4 вершин чотирикутника:");
            for (int i = 0; i < Amount; i++)
            {
                Console.Write($"x{i + 1} = ");
                coordinates[i, 0] = int.Parse(Console.ReadLine());

                Console.Write($"y{i + 1} = ");
                coordinates[i, 1] = int.Parse(Console.ReadLine());
            }
        }

        public virtual void Print()
        {
            Console.WriteLine("Координати вершин чотирикутника:");
            for (int i = 0; i < Amount; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: ({coordinates[i, 0]}, {coordinates[i, 1]})");
            }
        }

        public virtual double Area()
        {
            double sum1 = 0;
            double sum2 = 0;

            for (int i = 0; i < Amount; i++)
            {
                int next = (i + 1) % Amount;
                sum1 += coordinates[i, 0] * coordinates[next, 1];
                sum2 += coordinates[i, 1] * coordinates[next, 0];
            }

            return Math.Abs(sum1 - sum2) / 2.0;
        }
    }

    public class Triangle : ConvexQuadrilateral
    {
        public Triangle()
        {
            Amount = 3;
            coordinates = new int[Amount, 2];
        }

        public override void Specify()
        {
            Console.WriteLine("Введіть координати 3 вершин трикутника:");
            for (int i = 0; i < Amount; i++)
            {
                Console.Write($"x{i + 1} = ");
                coordinates[i, 0] = int.Parse(Console.ReadLine());

                Console.Write($"y{i + 1} = ");
                coordinates[i, 1] = int.Parse(Console.ReadLine());
            }
        }

        public override void Print()
        {
            Console.WriteLine("Координати вершин трикутника:");
            for (int i = 0; i < Amount; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: ({coordinates[i, 0]}, {coordinates[i, 1]})");
            }
        }

        public override double Area()
        {
            double x1 = coordinates[0, 0];
            double y1 = coordinates[0, 1];
            double x2 = coordinates[1, 0];
            double y2 = coordinates[1, 1];
            double x3 = coordinates[2, 0];
            double y3 = coordinates[2, 1];

            return Math.Abs(
                x1 * (y2 - y3) +
                x2 * (y3 - y1) +
                x3 * (y1 - y2)
            ) / 2.0;
        }
    }

    class Program
    {
        static void Main()
        {
            ConvexQuadrilateral quad = new ConvexQuadrilateral();
            quad.Specify();
            quad.Print();
            Console.WriteLine($"Площа чотирикутника = {quad.Area()}");

            Console.WriteLine();

            Triangle triangle = new Triangle();
            triangle.Specify();
            triangle.Print();
            Console.WriteLine($"Площа трикутника = {triangle.Area()}");
        }
    }
}