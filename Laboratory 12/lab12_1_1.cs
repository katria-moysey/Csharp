/*Дано структуру даних (колекцію) відповідно до варіанта. Додати
зазначену кількість елементів, які описують відповідну предметну
область. Вивести всі елементи на консоль в прямому та зворотному
порядку. Вивести кількість елементів у колекції. Очистити колекцію.
10 List Назви мікропроцесорів 11*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab12
{
class Program
{
static void Main()
{

List<string> microprocessors = new List<string>();
microprocessors.Add("Intel 4004");
microprocessors.Add("Intel 8080");
microprocessors.Add("Intel 8086");
microprocessors.Add("Intel Pentium");
microprocessors.Add("Intel Core 2 Duo");
microprocessors.Add("Intel Core i7");
microprocessors.Add("Intel Xeon");
microprocessors.Add("AMD Athlon ");
microprocessors.Add("AMD Ryzen 7 ");
microprocessors.Add("VIA C3 ");
microprocessors.Add("Intel Itanium");

Console.WriteLine("Елементи у прямому порядку:");
foreach (var item in microprocessors)
{
Console.WriteLine($"{item}");
}

Console.WriteLine("Без тих, що починаються на I:");
for (int i = microprocessors.Count - 1; i >= 0; i--)
    {
        if (microprocessors[i].StartsWith("I"))
            {
                    microprocessors.Remove(microprocessors[i]);
            }
    }

foreach (var item in microprocessors)
{
Console.WriteLine($"{item}");
}
Console.WriteLine($"Кількість елементів у колекції: {microprocessors.Count}");

microprocessors.Clear();
Console.WriteLine($"Кількість елементів після очищення: {microprocessors.Count}");

}
}   
}

