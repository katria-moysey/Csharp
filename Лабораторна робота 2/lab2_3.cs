/* Варіант 10 Дано чотири точки, що є вершинами чотирикутника:
 A (x_1 , y_1 ) , B ( x_2, y_2)  , C ( x_3, y_3 ), D(x_4 , y_4) . З’ясувати, чи можуть вони бути вершинами ромба.*/
using System;
namespace Program
{
    class Rhombus
    {
        static void Main()
        {
            Console.WriteLine("Введіть координати чотирикутника:");
            Console.Write("Координати вершини A (x_1, y_1): ");
            double x_1 = double.Parse(Console.ReadLine());
            double y_1 = double.Parse(Console.ReadLine());
            Console.Write("Координати вершини B (x_2, y_2): ");
            double x_2 = double.Parse(Console.ReadLine());
            double y_2 = double.Parse(Console.ReadLine());
            Console.Write("Координати вершини C (x_3, y_3): ");
            double x_3 = double.Parse(Console.ReadLine());
            double y_3 = double.Parse(Console.ReadLine());
            Console.Write("Координати вершини D (x_4, y_4): ");
            double x_4 = double.Parse(Console.ReadLine());
            double y_4 = double.Parse(Console.ReadLine());
            double AB= Math.Sqrt(Math.Pow((x_2 - x_1), 2) + Math.Pow((y_2 - y_1), 2));
            double BC = Math.Sqrt(Math.Pow((x_3 - x_2), 2) + Math.Pow((y_3 - y_2), 2));
            double CD= Math.Sqrt(Math.Pow((x_4 - x_3), 2) + Math.Pow((y_4 - y_3), 2));
            double DA = Math.Sqrt(Math.Pow((x_1 - x_4), 2) + Math.Pow((y_1 - y_4), 2));
            if (AB == BC && CD == DA && CD == AB)
            {
              Console.WriteLine("Чотрикутник є ромбом");  
            }
            else
            {
                Console.WriteLine("Чотрикутник не є ромбом");  

            }
            
        
            
        }
    }
}