using TollCalculator.API.Context;
using TollCalculator.API.GenericClasses;
using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;

namespace TollCalculator.API.Repositories
{
    public class SQLiteRepository : IRepository<VehicleType>
    {
        private readonly ApplicationDbContext _context;

        public SQLiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteAllVehicleTypes()
        {
            var allVehicleTypes = _context.VehicleTypes
                .Where(vt => true);
            _context.VehicleTypes.RemoveRange(allVehicleTypes);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Dto<VehicleType> GetVehicleType(bool isTollEligable)
        {
            var type = _context.VehicleTypes
                .FirstOrDefault(vt => vt.IsTollEligable == isTollEligable);
            if (type is null)
                return new Dto<VehicleType> { Success = false };

            return new Dto<VehicleType>
            {
                Payload = type,
                Success = true
            };
        }

        public bool PostLicensePlate(LicensePlate licensePlate)
        {
            _context.LicensePlates.Add(licensePlate);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PostVehicleType(VehicleType vehicleType)
        {
            _context.VehicleTypes.Add(vehicleType);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}