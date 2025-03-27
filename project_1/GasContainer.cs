namespace project_1;

public class GasContainer : Contener, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double weight, double height, double ownWeight, double depth, double maxCapacity, double pressure)
        : base(weight, height, ownWeight, depth, maxCapacity, "G")
    {
        Pressure = pressure;
    }

    public override void LoadCharge(double loadWeight)
    {
        if (Weight + loadWeight > MaxCapacity)
        {
            NotifyHazard("Attempted to overload a gas container!");
            throw new OverfillException($"Overfill error: {SerialNumber} exceeded max capacity.");
        }
        base.LoadCharge(loadWeight);
    }

    public override void UnloadCharge(double unloadWeight)
    {
        double remainingWeight = Weight - unloadWeight;
        if (remainingWeight < MaxCapacity * 0.05)
        {
            NotifyHazard("Attempted to empty a gas container beyond the safety threshold!");
        }
        base.UnloadCharge(unloadWeight * 0.95);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[Hazard] {SerialNumber}: {message}");
    }
}