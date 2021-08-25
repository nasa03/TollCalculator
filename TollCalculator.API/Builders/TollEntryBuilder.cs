using System;
using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;

namespace TollCalculator.API.Builders
{
    internal class TollEntryBuilder : ITollEntryBuilder
    {
        private LicensePlate _licensePlate;
        private double? _fee;
        private DateTime? _dateTime;

        public TollEntry Build()
        {
            if (_licensePlate is null)
            {
                var message = $"'{nameof(TollEntry.LicensePlate)}' hasn't been set yet.'"
                + Environment.NewLine +
                $"Please call '{nameof(WithLicencePlate)}' to assign a value to this property.";

                throw new ArgumentNullException(message);
            }

            if (_fee is null)
            {
                var message = $"'{nameof(TollEntry.Fee)}' hasn't been set yet.'"
                + Environment.NewLine +
                $"Please call '{nameof(ForFeeOf)}' to assign a value to this property.";

                throw new ArgumentNullException(message);
            }

            if (_dateTime is null)
            {
                var message = $"'{nameof(TollEntry.TimeOfEntry)}' hasn't been set yet.'"
                + Environment.NewLine +
                $"Please call '{nameof(EnteredByDate)}' to assign a value to this property.";

                throw new ArgumentNullException(message);
            }

            return new TollEntry
            {
                Id = new Guid(),
                Fee = _fee,
                LicensePlate = _licensePlate,
                TimeOfEntry = Convert.ToDateTime(_dateTime)
            };
        }

        public ITollEntryBuilder EnteredByDate(DateTime dateTime)
        {
            _dateTime = dateTime;
            return this;
        }

        public ITollEntryBuilder ForFeeOf(double fee)
        {
            _fee = fee;
            return this;
        }

        public ITollEntryBuilder Reset()
        {
            _licensePlate = null;
            _fee = null;
            _dateTime = null;
            return this;
        }

        public ITollEntryBuilder WithLicencePlate(LicensePlate licensePlate)
        {
            _licensePlate = licensePlate;
            return this;
        }
    }
}