/*10. Створити клас TSystemLinearEquation, який представляє систему лінійних
алгебраїчних рівнянь і містить методи для введення/виведення коефіцієнтів,
знаходження коренів та перевірки того, чи є деякий набір чисел розв’язком
системи. На основі цього класу створити класи-нащадки, які представляють
системи двох та трьох лінійних рівнянь відповідно з двома та трьома невідомими.
Випадковим чином згенерувавши дані, знайти розв’язок систем лінійних
алгебраїчних рівнянь обох видів.
*/
using System;
namespace lab9
{
    public abstract class TSystemLinearEquation
    {
        protected double[,] coefficients;
        protected int rows;
        protected int cols;

        public int Rows
        {
            get { return rows; }
            set { if (value > 0) rows = value; }
        }
        
        public int Cols
        {
            get { return cols; }
            set { if (value > 0) cols = value; }
        }

        public TSystemLinearEquation(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            coefficients = new double[rows, cols];
        }

        public double this[int i, int j]
        {
            get { return coefficients[i, j]; }
            set { coefficients[i, j] = value; }
        }

        public virtual void Enter()
        {
            Console.WriteLine($"Ваша система коефіцієнтів :");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"[{i},{j}] = ");
                    coefficients[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        public virtual void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j == cols - 1) 
                    {
                        Console.WriteLine($"= {coefficients[i, j]} ");

                    }
                    else
                    {
                    Console.Write(coefficients[i, j] + "\t");
                    }

                }
            }
        }
        public abstract double[] SolveSystem();

        public bool IsThisSolution(params double[] x)
        {
            if (x.Length != cols - 1) return false;

            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < cols - 1; j++)
                {
                    sum += coefficients[i, j] * x[j];
                }

                if (Math.Abs(sum - coefficients[i, cols - 1]) > 0.001)
                    return false;
            }

            return true;
        }
    }

    public class TwoLinearEquations : TSystemLinearEquation
    {
        public TwoLinearEquations() : base(2, 3) { }

        public override void Enter()
        {
            Console.WriteLine($"Система 2 рівнянь з 2 невідомими:");
            base.Enter();


        }

        public override void Print()
        {
            Console.WriteLine("Система 2 рівнянь з 2 невідомими:");
            base.Print();
        }
        public override double[] SolveSystem()
        {
            double a1 = coefficients[0, 0];
            double b1 = coefficients[0, 1];
            double c1 = coefficients[0, 2];

            double a2 = coefficients[1, 0];
            double b2 = coefficients[1, 1];
            double c2 = coefficients[1, 2];

            double d = a1 * b2 - a2 * b1;

            if (d == 0)
            {
                Console.WriteLine("Система не має єдиного розв'язку.");
                return null;
            }

            double x = (c1 * b2 - c2 * b1) / d;
            double y = (a1 * c2 - a2 * c1) / d;

            return new double[] { x, y };
        }
    }

    public class ThreeLinearEquations : TSystemLinearEquation
    {
        public ThreeLinearEquations() : base(3, 4) { }

        public override void Enter()
        {
            Console.WriteLine("Система 3 рівнянь з 3 невідомими:");
            base.Enter();

        }

        public override void Print()
        {
            Console.WriteLine("Система 3 рівнянь з 3 невідомими:");
            base.Print();
        }
        public override double[] SolveSystem()
        {
            double[,] a = new double[3, 4];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    a[i, j] = coefficients[i, j];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(a[i, i]) < 1e-9)
                {
                    Console.WriteLine("Система не має єдиного розв'язку.");
                    return null;
                }

                for (int k = i + 1; k < 3; k++)
                {
                    double factor = a[k, i] / a[i, i];

                    for (int j = i; j <= 3; j++)
                    {
                        a[k, j] -= factor * a[i, j];
                    }
                }
            }

    double[] result = new double[3];

    for (int i = 2; i >= 0; i--)
    {
        result[i] = a[i, 3];

        for (int j = i + 1; j < 3; j++)
        {
            result[i] -= a[i, j] * result[j];
        }

        result[i] /= a[i, i];
    }

    return result;
}
    }

    class Program
    {
        static void Main()
        {
            TSystemLinearEquation[] systems = new TSystemLinearEquation[] 
            { 
                new TwoLinearEcdquations(), 
                new ThreeLinearEquations() 
            };

            foreach (TSystemLinearEquation system in systems)
            {
                RandomFill(system);
                system.Print();
                double[] result = system.SolveSystem();

                if (result != null)
                {
                    Console.WriteLine("Розв'язок:");
                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.WriteLine($"x{i + 1} = {result[i]}");
                    }
                    Console.WriteLine("Перевірка: " + (system.IsThisSolution(result)));
                }
            }
        }

        static void RandomFill(TSystemLinearEquation a)
        {
            Random rand = new Random();

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    a[i, j] = rand.Next(1, 100);
                }
            }
        }
    }
}