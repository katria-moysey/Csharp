using System;

namespace Module2
{
    public class Ellipsoid
    {
        protected double[,] coefficients;

        public Ellipsoid()
        {
            coefficients = new double[2, 3];
        }

        public double this[int i, int j]
        {
            get { return coefficients[i, j]; }
            set { coefficients[i, j] = value; }
        }

        public virtual void Enter()
        {
            Console.WriteLine("Введення даних еліпсоїда");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        Console.Write($"Введіть a_{j + 1} : ");
                    }
                    else
                    {
                        Console.Write($"Введіть b_{j + 1} : ");
                    }
                    coefficients[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        public virtual void Print()
        {
            Console.Write("Рівняння еліпсоїда: ");
            for (int j = 0; j < 3; j++)
            {
                string sign = (j == 0) ? "" : " + ";
                Console.Write($"{sign}(x_{j+1} - {coefficients[1, j]})^2 / {coefficients[0, j]}^2");
            }
            Console.WriteLine(" = 1");
        }

        public virtual double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * coefficients[0, 0] * coefficients[0, 1] * coefficients[0, 2];
        }
    }

    public class Globe : Ellipsoid
    {
        protected double R;

        public Globe() : base() { }

        public override void Enter()
        {
            Console.WriteLine("Введення даних кулі");
            Console.Write("Введіть R (радіус кулі): ");
            R = double.Parse(Console.ReadLine());
            
            coefficients[0, 0] = R;
            coefficients[0, 1] = R;
            coefficients[0, 2] = R;

            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Введіть b_{j + 1} (координата центру): ");
                coefficients[1, j] = double.Parse(Console.ReadLine());
            }
        }

        public override void Print()
        {
            Console.Write("Рівняння кулі: ");
            for (int j = 0; j < 3; j++)
            {
                string sign = (j == 0) ? "" : " + ";
                Console.Write($"{sign}(x_{j+1} - {coefficients[1, j]})^2");
            }
            Console.WriteLine($" = {R}^2");
        }

        public override double CalculateVolume()
        {
            return 4.0 / 3.0 * Math.PI * Math.Pow(R, 3);
        }
    }

    class Program
    {
        static void Main()
        {
            Ellipsoid ellipsoid = new Ellipsoid();
            ellipsoid.Enter();
            ellipsoid.Print();
            Console.WriteLine($"Об'єм еліпсоїда: {ellipsoid.CalculateVolume():F2}\n");

            Globe globe = new Globe();
            globe.Enter();
            globe.Print();
            Console.WriteLine($"Об'єм кулі: {globe.CalculateVolume():F2}");
        }
    }
}