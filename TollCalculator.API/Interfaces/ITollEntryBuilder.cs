using System;
using TollCalculator.API.Models;

namespace TollCalculator.API.Interfaces
{
    public interface ITollEntryBuilder : IBuilder<TollEntry, ITollEntryBuilder>
    {
        ITollEntryBuilder WithLicencePlate(LicensePlate licensePlate);
        ITollEntryBuilder EnteredByDate(DateTime dateTime);
        ITollEntryBuilder ForFeeOf(double fee);
    }
}