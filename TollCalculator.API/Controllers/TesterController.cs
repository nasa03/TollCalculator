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
        private readonly IRepository<VehicleType> _repository;
        private readonly List<TollEntry> _fakeEntries = new();
        public TesterController(IRepository<VehicleType> repository)
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

            var licensePlateBuilder = new LicensePlateBuilder();

            var tollFree = _repository
                .GetVehicleTypeFromTollEligibility(true)
                .Payload;
            var tollEligable = _repository
                .GetVehicleTypeFromTollEligibility(false)
                .Payload;

            var licenseplate1 = licensePlateBuilder
                .Reset()
                .ForVehicleType(tollFree)
                .WithNumber("ALEX5689")
                .Build();
            var licenseplate2 = licensePlateBuilder
                .Reset()
                .ForVehicleType(tollFree)
                .WithNumber("HANS0045")
                .Build();
            var licenseplate3 = licensePlateBuilder
                .Reset()
                .ForVehicleType(tollEligable)
                .WithNumber("FRED1119")
                .Build();
            var licenseplate4 = licensePlateBuilder
                .Reset()
                .ForVehicleType(tollEligable)
                .WithNumber("ANDE3399")
                .Build();

            _repository.PostLicensePlate(licenseplate1);
            _repository.PostLicensePlate(licenseplate2);
            _repository.PostLicensePlate(licenseplate3);
            _repository.PostLicensePlate(licenseplate4);

            return Ok();
        }
    }
}