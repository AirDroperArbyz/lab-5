namespace TaxiStation.Models
{

    public class ElectricCar : Car
    {
        public int RangeKm { get; }

        public ElectricCar(string brand, string model, double price, double fuelConsumption, int maxSpeed, int rangeKm)
            : base(brand, model, price, fuelConsumption, maxSpeed)
        {
            RangeKm = rangeKm;
        }

        public override string GetDetails() => $"Электрокар (запас хода: {RangeKm} км)";
    }
}