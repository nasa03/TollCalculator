using TollCalculator.API.Models;

namespace TollCalculator.API.Interfaces
{
    public interface ITollEntryBuilder : IBuilder<TollEntry>
    {
        ITollEntryBuilder WithLicencePlate(string licensePlate);
        ITollEntryBuilder EnteredBy(DateTime dateTime);
        ITollEntryBuilder ForFeeOf(double fee);
    }
}