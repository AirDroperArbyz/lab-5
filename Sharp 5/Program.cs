using System;
using System.Linq;
using TaxiStation.Models;

namespace TaxiStation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var taxiPark = new TaxiPark("Таксопарк «Столичный»")
                    .LoadFromFile("fleet.txt")
                    .AddCar(new Sedan("Skoda", "Octavia", 24500, 6.5, 215, 568));

                Console.WriteLine($"=== {taxiPark.Name} ===");

                while (true)
                {
                    Console.WriteLine("\n1. Весь автопарк и общая стоимость\n2. Сортировка по расходу топлива\n3. Поиск по скорости\n0. Выход");
                    Console.Write("Выбор: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            taxiPark.Cars.ToList().ForEach(Console.WriteLine);
                            Console.WriteLine($"Итоговая стоимость парка: {taxiPark.GetTotalCost():F2}$");
                            break;

                        case "2":
                            Console.WriteLine("\n--- Сортировка по расходу ---");
                            taxiPark.SortByFuelConsumption().ToList().ForEach(Console.WriteLine);
                            break;

                        case "3":
                            Console.Write("Мин. скорость: ");
                            int min = int.Parse(Console.ReadLine());
                            Console.Write("Макс. скорость: ");
                            int max = int.Parse(Console.ReadLine());

                            var found = taxiPark.FindBySpeedRange(min, max).ToList();
                            if (found.Count == 0) Console.WriteLine("Ничего не найдено.");
                            else found.ForEach(Console.WriteLine);
                            break;

                        case "0":
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
