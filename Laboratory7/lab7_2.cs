/*10.  Реалізувати клас, що представляє рівняння прямої на площині (
Ax + By + C = 0) і
містить опис індексатора для доступу до коефіцієнтів цього рівняння. Передбачити
методи введеня/виведення, знаходження точки перетину з іншою прямою та метод
перевірки належності точки прямій */
using System;

namespace lab7
{
    class Equation
    {
        private double[] a;

        public Equation(params double[] a)
        {
            this.a = new double[3];
            for (int i = 0; i < 3 && i < a.Length; i++)
                this[i] = a[i];
        }

        public double this[int i]
        {
            get
            {
                if (i >= 0 && i < a.Length)
                    return a[i];
                else
                    return 0;
            }
            set
            {
                if (i >= 0 && i < a.Length)
                    a[i] = value;
            }
        }

        public void Enter()
        {
            
            Console.WriteLine("Введіть вашу пряму:");
            Console.Write("Введіть A: ");
            this[0] = double.Parse(Console.ReadLine());

            Console.Write("Введіть B: ");
            this[1] = double.Parse(Console.ReadLine());

            Console.Write("Введіть C: ");
            this[2] = double.Parse(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine($"{this[0]}x + {this[1]}y + {this[2]} = 0");
        }
        public bool Belongs(double x, double y)
        {
            return Math.Abs(this[0] * x + this[1] * y + this[2]) < 1e-9;
        }

        public double[] Intersection(Equation other)
        {
            double det = this[0] * other[1] - this[1] * other[0];

            if (Math.Abs(det) < 1e-9)
                return null;

            double x = (-this[2] * other[1] + this[1] * other[2]) / det;
            double y = (-this[0] * other[2] + this[2] * other[0]) / det;

            return new double[] { x, y };
        }
    }

    class Program
    {
        static void Main()
        {
            Equation e1 = new Equation();
            Equation e2 = new Equation();
            e1.Enter();
            e2.Enter();

            e1.Print();
            e2.Print();

            double[] p = e1.Intersection(e2);

            if (p != null)
                Console.WriteLine($"Точка перетину: ({p[0]}; {p[1]})");
            else
                Console.WriteLine("Прямі не перетинаються");

            Console.WriteLine("Перевірка точки (1;1): " + e1.Belongs(1, 1));
        }
    }
}