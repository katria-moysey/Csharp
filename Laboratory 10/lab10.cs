/*10. Створити інтерфейс, що містить опис методів для роботи з двовимірними
векторами (знаходження довжини вектора, суми векторів, множення вектора на
число, скалярного добутку) та класи, які містять реалізації методів інтерфейсу у
випадку, коли вектор задано його координатами та координатами початку і кінця.
*/
using System;
namespace lab10
{
    interface IVector2D
{
    void Enter();
    double Length();

    IVector2D Add(IVector2D other);

    IVector2D Multiply(double number);

    double ScalarProduct(IVector2D other);

    double GetX();

    double GetY();

    void Print();
}

class VectorByCoordinates : IVector2D
{
    private double x;
    private double y;
    public VectorByCoordinates()
    {
        x = 1;
        y = 1;
    }

    public VectorByCoordinates(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public  void Enter()
        {
            Console.WriteLine($"Координати вектора :");
              x = double.Parse(Console.ReadLine());
              y = double.Parse(Console.ReadLine());

        }

    public double GetX()
    {
        return x;
    }

    public double GetY()
    {
        return y;
    }

    public double Length()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public IVector2D Add(IVector2D other)
    {
        double newX = this.x + other.GetX();
        double newY = this.y + other.GetY();

        return new VectorByCoordinates(newX, newY);
    }

    public IVector2D Multiply(double number)
    {
        double newX = this.x * number;
        double newY = this.y * number;

        return new VectorByCoordinates(newX, newY);
    }

    public double ScalarProduct(IVector2D other)
    {
        return this.x * other.GetX() + this.y * other.GetY();
    }

    public void Print()
    {
        Console.WriteLine($"Вектор заданий координатами: ({x}; {y})");
    }
}

class VectorByPoints : IVector2D
{
    private double x1;
    private double y1;
    private double x2;
    private double y2;
    public VectorByPoints()
    {
        x1 = 1;
        y1 = 1;
        x2 = 2;
        y2 = 2;
    }

    public VectorByPoints(double x1, double y1, double x2, double y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }
    public  void Enter()
    {
            Console.WriteLine($"Координати вектора :");
            Console.WriteLine("Початок вектора");
            x1 = double.Parse(Console.ReadLine());
            y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Кінець вектора");
            x2 = double.Parse(Console.ReadLine());
            y2 = double.Parse(Console.ReadLine());

    }

    public double GetX()
    {
        return x2 - x1;
    }

    public double GetY()
    {
        return y2 - y1;
    }

    public double Length()
    {
        double x = GetX();
        double y = GetY();

        return Math.Sqrt(x * x + y * y);
    }

    public IVector2D Add(IVector2D other)
    {
        double newX = GetX() + other.GetX();
        double newY = GetY() + other.GetY();

        return new VectorByCoordinates(newX, newY);
    }

    public IVector2D Multiply(double number)
    {
        double newX = GetX() * number;
        double newY = GetY() * number;

        return new VectorByCoordinates(newX, newY);
    }

    public double ScalarProduct(IVector2D other)
    {
        return GetX() * other.GetX() + GetY() * other.GetY();
    }

    public void Print()
    {
        Console.WriteLine($"Вектор заданий точками: початок ({x1}; {y1}), кінець ({x2}; {y2})");
        Console.WriteLine($"Його координати: ({GetX()}; {GetY()})");
    }
}

class Program
{
    static void Main()
    {

        VectorByCoordinates vector1 = new VectorByCoordinates();
        vector1.Enter();

        VectorByPoints vector2 = new VectorByPoints();
        vector2.Enter();

        Console.WriteLine("Перший вектор:");
        vector1.Print();
        Console.WriteLine($"Довжина першого вектора: {vector1.Length()}");

        Console.WriteLine("Другий вектор:");
        vector2.Print();
        Console.WriteLine($"Довжина другого вектора: {vector2.Length()}");

        Console.WriteLine("Сума векторів:");
        IVector2D sum = vector1.Add(vector2);
        sum.Print();

        Console.WriteLine("Множення першого вектора на число 2:");
        IVector2D multiplied = vector1.Multiply(2);
        multiplied.Print();

        Console.WriteLine("Скалярний добуток першого і другого векторів:");
        double ScalarProduct = vector1.ScalarProduct(vector2);
        Console.WriteLine($"Скалярний добуток = {ScalarProduct}");
    }
}
    
}

