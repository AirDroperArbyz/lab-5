namespace TaxiStation.Models
{

    public class Sedan : Car
    {
        public int TrunkVolume { get; }

        public Sedan(string brand, string model, double price, double fuelConsumption, int maxSpeed, int trunkVolume)
            : base(brand, model, price, fuelConsumption, maxSpeed)
        {
            TrunkVolume = trunkVolume;
        }

        public override string GetDetails() => $"Седан (багажник: {TrunkVolume} л)";
    }
}