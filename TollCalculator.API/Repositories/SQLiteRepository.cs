using TollCalculator.API.Context;
using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;

namespace TollCalculator.API.Repositories
{
    public class SQLiteRepository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteAllEntries()
        {
            var all = _context.TollEntries.Where(t => true);
            _context.RemoveRange(all);
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

        public IQueryable<TollEntry> GetTollEntries(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public bool PostTollEntry(TollEntry tollEntry)
        {
            throw new NotImplementedException();
        }
        public bool PostTollEntry(IEnumerable<TollEntry> tollEntry)
        {
            _context.TollEntries.AddRange(tollEntry);
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}