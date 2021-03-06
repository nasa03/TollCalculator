using System.Collections.Generic;
using TollCalculator.API.GenericClasses;
using TollCalculator.API.Models;
namespace TollCalculator.API.Interfaces
{
    public interface IRepository
    {
        //Get
        IEnumerable<LicensePlate> GetAllLicensePlates();
        Dto<VehicleType> GetVehicleType(bool isTollEligible);
        //Post
        bool PostVehicleType(VehicleType vehicleType);
        bool PostLicensePlate(LicensePlate licensePlate);
        bool PostTollEntry(TollEntry tollEntry);
        bool PostTollEntries(List<TollEntry> fakeEntries);
        //Delete
        bool DeleteAllVehicleTypes();
        bool DeleteAllLicensePlates();
        bool DeleteAllTollEntries();
    }
}