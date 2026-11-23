using System;

namespace TaxiStation.Models
{

    public abstract class Car
    {
        public string Brand { get; }
        public string Model { get; }
        public double Price { get; }
        public double FuelConsumption { get; }
        public int MaxSpeed { get; }

        protected Car(string brand, string model, double price, double fuelConsumption, int maxSpeed)
        {
            if (price <= 0 || fuelConsumption <= 0 || maxSpeed <= 0)
                throw new ArgumentException("Числовые параметры автомобиля должны быть больше нуля.");

            Brand = brand;
            Model = model;
            Price = price;
            FuelConsumption = fuelConsumption;
            MaxSpeed = maxSpeed;
        }

        
        public abstract string GetDetails();

        public override string ToString() =>
            $"{Brand,-13} {Model,-10} | Цена: {Price,8:F2}$ | Расход: {FuelConsumption,5:F1} | Макс. ск.: {MaxSpeed,3} км/ч | {GetDetails()}";
    }
}