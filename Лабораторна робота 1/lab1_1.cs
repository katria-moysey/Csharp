/* Варіант 10 Трикутник задається координатами своїх вершин на площині:
 A (x_1 , y_1 ) , B ( x_2, y_2)  , C ( x_3, y_3 ). 
 Скласти програму для знаходження периметра */
using System;
namespace Program
{
    class Triangle
    {
        static void Main()
        {
            Console.WriteLine("Введіть координати трикутника:");
            Console.Write("Координати вершини A (x_1, y_1): ");
            double x_1 = double.Parse(Console.ReadLine());
            double y_1 = double.Parse(Console.ReadLine());
            Console.Write("Координати вершини B (x_2, y_2): ");
            double x_2 = double.Parse(Console.ReadLine());
            double y_2 = double.Parse(Console.ReadLine());
            Console.Write("Координати вершини C (x_3, y_3): ");
            double x_3 = double.Parse(Console.ReadLine());
            double y_3 = double.Parse(Console.ReadLine());
            double side_1 = Math.Sqrt(Math.Pow((x_2 - x_1), 2) + Math.Pow((y_2 - y_1), 2));
            double side_2 = Math.Sqrt(Math.Pow((x_3 - x_2), 2) + Math.Pow((y_3 - y_2), 2));
            double side_3 = Math.Sqrt(Math.Pow((x_1 - x_3), 2) + Math.Pow((y_1 - y_3), 2));
            double perimeter = side_1 + side_2 + side_3;
            Console.WriteLine("Периметр трикутника = {0:f4}", perimeter);
        
            
        }
    }
}
