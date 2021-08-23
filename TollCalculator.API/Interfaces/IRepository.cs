using TollCalculator.API.GenericClasses;
using TollCalculator.API.Models;
namespace TollCalculator.API.Interfaces
{
    public interface IRepository<T>
    {
        //Get
        IEnumerable<LicensePlate> GetAllLicensePlates();
        Dto<T> GetVehicleType(bool isTollEligable);
        //Post
        bool PostVehicleType(T vehicleType);
        bool PostLicensePlate(LicensePlate licensePlate);
        bool PostTollEntry(TollEntry tollEntry);
        bool PostTollEntries(List<TollEntry> _fakeEntries);
        //Delete
        bool DeleteAllVehicleTypes();
        bool DeleteAllLicensePlates();
        bool DeleteAllTollEntries();
    }
}