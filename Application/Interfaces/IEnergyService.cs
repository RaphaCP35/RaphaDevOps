public interface IEnergyService
{
    Task<IEnumerable<EnergyData>> GetConsumptionAsync(int page, int pageSize);
    Task InsertDataAsync(EnergyData data);
    Task<IEnumerable<Alert>> GetAlertsAsync();
    IEnumerable<object> ForecastConsumption();
}