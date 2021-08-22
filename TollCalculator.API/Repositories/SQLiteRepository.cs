using TollCalculator.API.Context;
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

        // public IQueryable<TollEntry> GetTollEntries(string licensePlate)
        // {
        //     throw new NotImplementedException();
        // }

        // public bool PostTollEntry(TollEntry tollEntry)
        // {
        //     throw new NotImplementedException();
        // }
        // public bool PostTollEntry(IEnumerable<TollEntry> tollEntry)
        // {
        //     _context.TollEntries.AddRange(tollEntry);
        //     try
        //     {
        //         return _context.SaveChanges() > 0;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }
    }
}