using Microsoft.AspNetCore.Mvc;
using TollCalculator.API.Models;
using TollCalculator.API.Repositories;
namespace TollCalculator.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TestingController : Controller
    {
        private readonly SQLiteRepository _repository;

        private readonly List<TollEntry> fakeEntries = new List<TollEntry>
        {

        };
        public TestingController(SQLiteRepository repository) =>
            _repository = repository;


    }
}