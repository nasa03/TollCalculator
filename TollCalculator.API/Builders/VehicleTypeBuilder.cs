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
            if (_isTollEligable is null)
            {
                var message = $"'{nameof(VehicleType.IsTollEligable)}' hasn't been set yet.'"
                + Environment.NewLine +
                $"Please call '{nameof(SetTollEligibilityTo)}' to assign a value to this property.";

                throw new ArgumentNullException(message);
            }
            var vehicleType = new VehicleType
            {
                Id = new Guid(),
                IsTollEligable = Convert.ToBoolean(_isTollEligable)
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
