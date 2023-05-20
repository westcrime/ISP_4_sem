namespace Lab4.Models;

public class CustomRate
{
    public string Name { get; set; }
    public double Value { get; set; }
    
    public CustomRate() { }

    public CustomRate(string name, double value)
    {
        Name = name;
        Value = value;
    }
}