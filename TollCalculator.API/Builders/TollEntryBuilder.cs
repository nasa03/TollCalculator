using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;
namespace TollCalculator.API.Builders
{
    internal class TollEntryBuilder : ITollEntryBuilder
    {
        private TollEntry _tollEntry;
        internal TollEntryBuilder() => _tollEntry = new TollEntry();
        public TollEntry EnteredBy(DateTime dateTime)
        {
            _tollEntry.TimeOfEntry = dateTime;
            return _tollEntry;
        }
        public TollEntry ForFeeOf(double fee)
        {
            _tollEntry.Fee = fee;
            return _tollEntry;
        }
        public TollEntry WithLicencePlate(string licensePlate)
        {
            _tollEntry.LicensePlate = licensePlate;
            return _tollEntry;
        }
        public TollEntry Build() => _tollEntry;
    }
}