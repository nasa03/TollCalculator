using Microsoft.AspNetCore.Mvc;
using TollCalculator.API.Controllers.Helpers;
using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;
namespace TollCalculator.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TesterController : Controller
    {
        private readonly IRepository _repository;
        private readonly List<TollEntry> _fakeEntries = new();
        public TesterController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Reset()
        {
            var resetResult = _repository.DeleteAllEntries();
            if (!resetResult)
                return NotFound();
            for (var i = 0; i < 10000; i++)
            {
                var entry = TesterHelpers.GetFakeEntry();
                _fakeEntries.Add(entry);
            }
            var postResult = _repository.PostTollEntry(_fakeEntries);
            if (!postResult)
                return NotFound();
            return Ok();
        }
    }
}