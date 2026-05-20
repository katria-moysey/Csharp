/*10. Створити клас TSystemLinearEquation, який представляє систему лінійних
алгебраїчних рівнянь і містить методи для введення/виведення коефіцієнтів,
знаходження коренів та перевірки того, чи є деякий набір чисел розв’язком
системи. На основі цього класу створити класи-нащадки, які представляють
системи двох та трьох лінійних рівнянь відповідно з двома та трьома невідомими.
Випадковим чином згенерувавши дані, знайти розв’язок систем лінійних
алгебраїчних рівнянь обох видів.
*/
using System;

namespace lab11
{
    public abstract class TSystemLinearEquation<T> where T : IComparable<T>
    {
        protected T[,] coefficients;
        protected int rows;
        protected int cols;

        public int Rows
        {
            get { return rows; }
        }

        public int Cols
        {
            get { return cols; }
        }

        public TSystemLinearEquation(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            coefficients = new T[rows, cols];
        }

        public T this[int i, int j]
        {
            get { return coefficients[i, j]; }
            set { coefficients[i, j] = value; }
        }

        public virtual void Enter()
        {
            Console.WriteLine("Введіть коефіцієнти системи:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"[{i},{j}] = ");
                    coefficients[i, j] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
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
                        Console.WriteLine($"= {coefficients[i, j]}");
                    else
                        Console.Write($"{coefficients[i, j]}\t");
                }
            }
        }

        public abstract T[] SolveSystem();

        public bool IsThisSolution(params T[] x)
        {
            if (x.Length != cols - 1)
                return false;

            for (int i = 0; i < rows; i++)
            {
                double sum = 0;

                for (int j = 0; j < cols - 1; j++)
                {
                    sum += Convert.ToDouble(coefficients[i, j]) * Convert.ToDouble(x[j]);
                }

                double rightPart = Convert.ToDouble(coefficients[i, cols - 1]);

                if (Math.Abs(sum - rightPart) > 0.001)
                    return false;
            }

            return true;
        }
    }

    public class TwoLinearEquations<T> : TSystemLinearEquation<T> where T : IComparable<T>
    {
        public TwoLinearEquations() : base(2, 3) { }

        public override void Enter()
        {
            Console.WriteLine("Система 2 рівнянь з 2 невідомими:");
            base.Enter();
        }

        public override void Print()
        {
            Console.WriteLine("Система 2 рівнянь з 2 невідомими:");
            base.Print();
        }

        public override T[] SolveSystem()
        {
            double a1 = Convert.ToDouble(coefficients[0, 0]);
            double b1 = Convert.ToDouble(coefficients[0, 1]);
            double c1 = Convert.ToDouble(coefficients[0, 2]);

            double a2 = Convert.ToDouble(coefficients[1, 0]);
            double b2 = Convert.ToDouble(coefficients[1, 1]);
            double c2 = Convert.ToDouble(coefficients[1, 2]);

            double d = a1 * b2 - a2 * b1;

            if (Math.Abs(d) < 0.000001)
            {
                Console.WriteLine("Система не має єдиного розв'язку.");
                return null;
            }

            double x = (c1 * b2 - c2 * b1) / d;
            double y = (a1 * c2 - a2 * c1) / d;

            return new T[]
            {
                (T)Convert.ChangeType(x, typeof(T)),
                (T)Convert.ChangeType(y, typeof(T))
            };
        }
    }

    public class ThreeLinearEquations<T> : TSystemLinearEquation<T> where T : IComparable<T>
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

        public override T[] SolveSystem()
        {
            double[,] a = new double[3, 4];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    a[i, j] = Convert.ToDouble(coefficients[i, j]);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(a[i, i]) < 0.000001)
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

            return new T[]
            {
                (T)Convert.ChangeType(result[0], typeof(T)),
                (T)Convert.ChangeType(result[1], typeof(T)),
                (T)Convert.ChangeType(result[2], typeof(T))
            };
        }
    }

    class Program
    {
        static Random rand = new Random();

        static void Main()
        {


            TSystemLinearEquation<double>[] systems =
            {
                new TwoLinearEquations<double>(),
                new ThreeLinearEquations<double>()
            };

            foreach (TSystemLinearEquation<double> system in systems)
            {
                RandomFill(system);

                system.Print();

                double[] result = system.SolveSystem();

                if (result != null)
                {
                    Console.WriteLine("Розв'язок:");

                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.WriteLine($"x{i + 1} = {result[i]:0.###}");
                    }

                    Console.WriteLine("Перевірка: " + system.IsThisSolution(result));
                }

                Console.WriteLine();
            }
        }

        static void RandomFill(TSystemLinearEquation<double> a)
        {
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    a[i, j] = rand.Next(1, 20);
                }
            }
        }
    }
}