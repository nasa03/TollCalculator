using System;
using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;

namespace TollCalculator.API.Builders
{
    internal sealed class VehicleTypeBuilder : IVehicleTypeBuilder
    {
        private static bool? _isTollEligible;
        private static int? _id;
        public IVehicleTypeBuilder IsTollEligible(bool isTollEligible)
        {
            _isTollEligible = isTollEligible;
            return this;
        }
        public IVehicleTypeBuilder WithId(int id)
        {
            _id = id;
            return this;
        }
        public VehicleType Build()
        {
            if (_isTollEligible is null)
            {
                var message = $"'{nameof(VehicleType.IsTollEligible)}' hasn't been set yet.'"
                + Environment.NewLine +
                $"Please call '{nameof(IsTollEligible)}' to assign a value to this property.";

                throw new ArgumentNullException(message);
            }
            var vehicleType = new VehicleType
            {
                Id = Convert.ToInt32(_id),
                IsTollEligible = Convert.ToBoolean(_isTollEligible)
            };

            return vehicleType;
        }

        public IVehicleTypeBuilder Reset()
        {
            _isTollEligible = null;
            _id = null;
            return this;
        }

    }
}
