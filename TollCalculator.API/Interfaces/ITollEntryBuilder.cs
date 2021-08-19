using TollCalculator.API.Models;

namespace TollCalculator.API.Interfaces
{
    public interface ITollEntryBuilder : IBuilder<TollEntry>
    {
        TollEntry WithLicencePlate(string licensePlate);
        TollEntry EnteredBy(DateTime dateTime);
        TollEntry ForFeeOf(double fee);
    }
}