using TollCalculator.API.Models;
namespace TollCalculator.API.Interfaces
{
    public interface IRepository
    {
        void PostTollEntry(TollEntry tollEntry);
        IQueryable<IEnumerable<TollEntry>> GetTollEntries(string licensePlate);
    }
}