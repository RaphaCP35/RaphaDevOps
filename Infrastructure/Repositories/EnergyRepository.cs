public interface IEnergyRepository
{
    Task<IEnumerable<EnergyData>> GetPaginatedDataAsync(int page, int pageSize);
    Task AddDataAsync(EnergyData data);
    Task<IEnumerable<Alert>> GetAlertsAsync();
}

public class EnergyRepository : IEnergyRepository
{
    private static List<EnergyData> _data = new();
    private static List<Alert> _alerts = new();

    public Task<IEnumerable<EnergyData>> GetPaginatedDataAsync(int page, int pageSize)
        => Task.FromResult(_data.Skip((page - 1) * pageSize).Take(pageSize));

    public Task AddDataAsync(EnergyData data)
    {
        _data.Add(data);
        if (data.ConsumptionKWh > 100) // exemplo de alerta
        {
            _alerts.Add(new Alert { Message = "Alto consumo detectado", Severity = "Critical" });
        }
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Alert>> GetAlertsAsync() => Task.FromResult(_alerts.AsEnumerable());
}
