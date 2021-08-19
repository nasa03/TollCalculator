using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;

namespace TollCalculator.API.Repositories
{
    public class SQLiteRepository : IRepository
    {
        public IQueryable<TollEntry> GetTollEntries(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public void PostTollEntry(TollEntry tollEntry)
        {
            throw new NotImplementedException();
        }
    }
}