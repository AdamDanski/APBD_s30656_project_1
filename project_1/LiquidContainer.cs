namespace project_1;

public class LiquidContainer : Contener, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double weight, double height, double ownWeight, double depth, double maxCapacity, bool isHazardous)
        : base(weight, height, ownWeight, depth, maxCapacity, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCharge(double loadWeight)
    {
        double allowedCapacity = IsHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

        if (Weight + loadWeight > allowedCapacity)
        {
            NotifyHazard("Attempted to overload a hazardous liquid container!");
            throw new OverfillException($"Overfill error: {SerialNumber} hazardous limit exceeded.");
        }

        base.LoadCharge(loadWeight);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[Hazard] {SerialNumber}: {message}");
    }
}