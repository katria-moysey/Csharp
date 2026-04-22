/*10. Створити клас TBus, який характеризує автобус і містить наступні поля: марка
автобуса, вага, кількість місць, кількість пасажирів. Передбачити методи
збільшення/зменшення кількості пасажирів та визначення наближеної ваги
автобуса з пасажирами без багажу. */
using System;

namespace lab7
{
    class TBus
    {
        private string brand_;
        private int weight_;
        private int places_;
        private int passengers_;

        public string Brand
        {
            get { return brand_; }
            set { brand_ = value; }
        }

        public int Weight
        {
            get { return weight_; }
            set
            {
                if (value > 0)
                    weight_ = value;
            }
        }

        public int Places
        {
            get { return places_; }
            set
            {
                if (value > 0)
                    places_ = value;
            }
        }

        public int Passengers
        {
            get { return passengers_; }
            set
            {
                if (value >= 0 && value <= places_)
                    passengers_ = value;
            }
        }

        public TBus()
        {
            brand_ = "";
            weight_ = 1000;
            places_ = 40;
            passengers_ = 0;
        }

        public TBus(string brand, int weight, int places, int passengers)
        {
            Brand = brand;
            Weight = weight;
            Places = places;
            Passengers = passengers;
        }

        public void AddPassengers(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Кількість не може бути від'ємною!");
                return;
            }

            if (passengers_ + number <= places_)
                passengers_ += number;
            else
                Console.WriteLine("Забагато пасажирів!");
        }

        public void RemovePassengers(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Кількість не може бути від'ємною!");
                return;
            }

            if (passengers_ - number >= 0)
                passengers_ -= number;
            else
                Console.WriteLine("Не може бути менше 0!");
        }

        public int GetTotalWeight()
        {
            return weight_ + passengers_ * 70;
        }

        public void Print()
        {
            Console.WriteLine($"Марка: {brand_}");
            Console.WriteLine($"Вага: {weight_}");
            Console.WriteLine($"Кількість місць: {places_}");
            Console.WriteLine($"Кількість пасажирів: {passengers_}");
            Console.WriteLine($"Вага з пасажирами: {GetTotalWeight()}");
        }
    }

    class Program
    {
        static void Main()
        {
            TBus bus1 = new TBus("Mercedes-Benz", 4000, 70, 59);

            bus1.AddPassengers(8);

            Console.WriteLine("Ваш автобус 1:");
            bus1.Print();

            Console.Write("Введіть марку автобуса: ");
            string name = Console.ReadLine();

            Console.Write("Введіть вагу автобуса: ");
            int weight = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість місць автобуса: ");
            int places = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість пасажирів автобуса: ");
            int passengers = int.Parse(Console.ReadLine());

            TBus bus2 = new TBus(name, weight, places, passengers);

            Console.WriteLine("Ваш автобус 2:");
            bus2.Print();
        }
    }
}