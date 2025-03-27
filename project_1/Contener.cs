namespace project_1
{
    public class Contener
    {
        private static int counterSerial = 0;
        public double Weight { get; set; }
        public double Height { get; set; }
        public double OwnWeight { get; set; }
        public double Depth { get; set; }
        public double MaxCapacity { get; set; }
        public string SerialNumber { get; set; }

        public Contener(double weight, double height, double ownWeight, double depth, double maxCapacity, string type)
        {
            Weight = weight;
            Height = height;
            OwnWeight = ownWeight;
            Depth = depth;
            MaxCapacity = maxCapacity;
            SerialNumber = $"KON-{type}-{counterSerial++}";
        }
        
        public virtual void LoadCharge(double loadWeight)
        {
            double totalWeight = OwnWeight + Weight + loadWeight;

            if (totalWeight > MaxCapacity)
            {
                throw new OverfillException($"Overfill error: The charge exceeds the container's maximum capacity. {SerialNumber}.");
            }

            Weight += loadWeight;
        }

        public virtual void UnloadCharge(double unloadWeight)
        {
            if (unloadWeight > Weight)
            {
                throw new OverfillException("Attempting to empty a container with more cargo than is inside.");
            }

            Weight -= unloadWeight;
        }
        
        public string GetContainerInfo()
        {
            return $"Serial Number: {SerialNumber}\n" +
                   $"Current Weight: {Weight} kg\n" +
                   $"Max Capacity: {MaxCapacity} kg\n" +
                   $"Own Weight: {OwnWeight} kg\n" +
                   $"Height: {Height} cm\n" +
                   $"Depth: {Depth} cm";
        }
    }
}
