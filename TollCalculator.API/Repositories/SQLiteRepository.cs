using System;
using System.Collections.Generic;
using TollCalculator.API.Context;
using TollCalculator.API.GenericClasses;
using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;
using System.Linq;

namespace TollCalculator.API.Repositories
{
    public class SqLiteRepository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public SqLiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteAllLicensePlates()
        {
            var all = _context.LicensePlates.Where(lp => true);
            _context.LicensePlates.RemoveRange(all);
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

        public bool DeleteAllTollEntries()
        {
            var all = _context.TollEntries.Where(te => true);
            _context.TollEntries.RemoveRange(all);
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public IEnumerable<LicensePlate> GetAllLicensePlates()
        {
            return _context.LicensePlates.Where(lp => true);
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

        public bool PostTollEntries(List<TollEntry> fakeEntries)
        {
            _context.AddRange(fakeEntries);
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

        public bool PostTollEntry(TollEntry tollEntry)
        {
            _context.TollEntries.Add(tollEntry);
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