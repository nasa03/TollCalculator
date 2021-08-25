using TollCalculator.API.Models;

namespace TollCalculator.API.Interfaces
{
    public interface IVehicleTypeBuilder : IBuilder<VehicleType, IVehicleTypeBuilder>
    {
        IVehicleTypeBuilder IsTollEligible(bool isEligible);
    }
}