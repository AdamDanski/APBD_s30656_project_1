namespace project_1;

public class RefrigeratedContainer : Contener
{
    public string ProductType { get; set; }
    public double RequiredTemperature { get; set; }
    public double CurrentTemperature { get; set; }

    public RefrigeratedContainer(double weight, double height, double ownWeight, double depth, double maxCapacity, string productType, double requiredTemperature)
        : base(weight, height, ownWeight, depth, maxCapacity, "C")
    {
        ProductType = productType;
        RequiredTemperature = requiredTemperature;
        CurrentTemperature = requiredTemperature;
    }

    public void SetTemperature(double newTemperature)
    {
        if (newTemperature < RequiredTemperature)
        {
            throw new Exception("Temperature is too low for stored products!");
        }
        CurrentTemperature = newTemperature;
    }
}