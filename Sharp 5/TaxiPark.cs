using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TaxiStation.Models;

namespace TaxiStation
{
    public class TaxiPark
    {
        private readonly List<Car> _cars = new List<Car>();

        public string Name { get; }
        public IReadOnlyList<Car> Cars => _cars.AsReadOnly();

        public TaxiPark(string name)
        {
            Name = name;
        }

        public TaxiPark AddCar(Car car)
        {
            _cars.Add(car);
            return this;
        }

        public TaxiPark LoadFromFile(string filePath)
        {
            foreach (string line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] p = line.Split(';');
                string type = p[0].Trim().ToLowerInvariant();
                string brand = p[1].Trim();
                string model = p[2].Trim();
                double price = double.Parse(p[3].Trim(), CultureInfo.InvariantCulture);
                double fuel = double.Parse(p[4].Trim(), CultureInfo.InvariantCulture);
                int speed = int.Parse(p[5].Trim());
                int extra = int.Parse(p[6].Trim());


                Car car;
                switch (type)
                {
                    case "sedan":
                        car = new Sedan(brand, model, price, fuel, speed, extra);
                        break;
                    case "minivan":
                        car = new Minivan(brand, model, price, fuel, speed, extra);
                        break;
                    case "electric":
                        car = new ElectricCar(brand, model, price, fuel, speed, extra);
                        break;
                    default:
                        throw new InvalidOperationException($"Неизвестный тип авто: {type}");
                }

                _cars.Add(car);
            }
            return this;
        }

        public double GetTotalCost() => _cars.Sum(c => c.Price);

        public IEnumerable<Car> SortByFuelConsumption() => _cars.OrderBy(c => c.FuelConsumption);

        public IEnumerable<Car> FindBySpeedRange(int minSpeed, int maxSpeed) =>
            _cars.Where(c => c.MaxSpeed >= minSpeed && c.MaxSpeed <= maxSpeed);
    }
}
