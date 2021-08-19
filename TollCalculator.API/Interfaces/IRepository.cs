using TollCalculator.API.Models;
namespace TollCalculator.API.Interfaces
{
    public interface IRepository
    {
        bool PostTollEntry(TollEntry tollEntry);
        bool PostTollEntry(IEnumerable<TollEntry> tollEntry);
        IQueryable<TollEntry> GetTollEntries(string licensePlate);
        bool DeleteAllEntries();
    }
}