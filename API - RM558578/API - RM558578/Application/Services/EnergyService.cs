public class EnergyService : IEnergyService
{
    private readonly IEnergyRepository _repository;

    public EnergyService(IEnergyRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<EnergyData>> GetConsumptionAsync(int page, int pageSize)
        => _repository.GetPaginatedDataAsync(page, pageSize);

    public Task InsertDataAsync(EnergyData data) => _repository.AddDataAsync(data);

    public Task<IEnumerable<Alert>> GetAlertsAsync() => _repository.GetAlertsAsync();

    public IEnumerable<object> ForecastConsumption()
    {
        // Simulação simples de previsão
        return new[] {
            new { Date = DateTime.UtcNow.AddDays(1), EstimatedKWh = 150 },
            new { Date = DateTime.UtcNow.AddDays(2), EstimatedKWh = 160 }
        };
    }
}