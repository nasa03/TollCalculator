using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;

namespace TollCalculator.API.Builders
{
    internal sealed class VehicleTypeBuilder : IVehicleTypeBuilder
    {
        internal static bool? _isTollEligable;
        public IVehicleTypeBuilder SetTollEligibilityTo(bool isTollEligable)
        {
            _isTollEligable = isTollEligable;
            return this;
        }
        public VehicleType Build()
        {
            var vehicleType = new VehicleType
            {
                Id = new Guid(),
                IsTollFree = _isTollEligable ?? false
            };

            return vehicleType;
        }

        public IVehicleTypeBuilder Reset()
        {
            _isTollEligable = null;
            return this;
        }
    }
}
