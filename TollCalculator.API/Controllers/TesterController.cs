using Microsoft.AspNetCore.Mvc;
using TollCalculator.API.Builders;
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
            _repository.DeleteAllVehicleTypes();

            var vehicleTypeBuilder = new VehicleTypeBuilder();
            var tollFreeType = vehicleTypeBuilder
                .Reset()
                .SetTollEligibilityTo(false)
                .Build();

            var tollEligableType = vehicleTypeBuilder
                .Reset()
                .SetTollEligibilityTo(true)
                .Build();

            _repository.PostVehicleType(tollFreeType);
            _repository.PostVehicleType(tollEligableType);

            return Ok();
        }
    }
}