using TollCalculator.API.Models;

namespace TollCalculator.API.Interfaces
{
    internal interface ILicensePlateBuilder : IBuilder<LicensePlate, ILicensePlateBuilder>
    {
        ILicensePlateBuilder WithNumber(string number);
        ILicensePlateBuilder ForVehicleType(VehicleType vehicleType);
    }
}