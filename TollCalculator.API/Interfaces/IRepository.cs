using TollCalculator.API.Models;
namespace TollCalculator.API.Interfaces
{
    public interface IRepository
    {
        void PostTollEntry(TollEntry tollEntry);
        IQueryable<TollEntry> GetTollEntries(string licensePlate);
    }
}