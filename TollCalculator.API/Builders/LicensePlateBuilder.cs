using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;

namespace TollCalculator.API.Builders
{
    internal class LicensePlateBuilder : ILicensePlateBuilder
    {
        private VehicleType _vehicleType;
        private string _number;

        public ILicensePlateBuilder Reset()
        {
            _vehicleType = null;
            _number = null;

            return this;
        }
        public ILicensePlateBuilder ForVehicleType(VehicleType vehicleType)
        {
            _vehicleType = vehicleType;
            return this;
        }
        public ILicensePlateBuilder WithNumber(string number)
        {
            _number = number;
            return this;
        }
        public LicensePlate Build()
        {
            if (_vehicleType is null)
            {
                var message = $"'{nameof(LicensePlate.VehicleType)}' hasn't been set yet.'"
                + Environment.NewLine +
                $"Please call '{nameof(ForVehicleType)}' to assign a value to this property.";

                throw new ArgumentNullException(message);
            }

            if (_number is null)
            {
                var message = $"'{nameof(LicensePlate.Number)}' hasn't been set yet.'"
                + Environment.NewLine +
                $"Please call '{nameof(WithNumber)}' to assign a value to this property.";

                throw new ArgumentNullException(message);
            }

            var licensePlate = new LicensePlate
            {
                Id = new Guid(),
                Number = _number,
                VehicleType = _vehicleType
            };

            return licensePlate;
        }
    }
}