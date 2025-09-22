public class EnergyData
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Timestamp { get; set; }
    public double ConsumptionKWh { get; set; }
    public string DeviceId { get; set; }
    public string Location { get; set; }
}