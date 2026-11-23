namespace TaxiStation.Models
{
    public class Minivan : Car
    {
        public int SeatsCount { get; }

        public Minivan(string brand, string model, double price, double fuelConsumption, int maxSpeed, int seatsCount)
            : base(brand, model, price, fuelConsumption, maxSpeed)
        {
            SeatsCount = seatsCount;
        }

        public override string GetDetails() => $"Минивэн (мест: {SeatsCount})";
    }
}
