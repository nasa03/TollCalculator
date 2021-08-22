using TollCalculator.API.Models;

namespace TollCalculator.API.Interfaces
{
    public interface ITollEntryBuilder : IBuilder<TollEntry>
    {
        TollEntry WithLicencePlate(LicensePlate licensePlate);
        TollEntry EnteredByDate(DateTime dateTime);
        TollEntry ForFeeOf(double fee);
    }
}