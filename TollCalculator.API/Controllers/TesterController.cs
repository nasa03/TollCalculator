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
            var postVehicleTypeRes = PopulateDbWithVehicleTypes();
            var postLicensePlateRes = PopulateDbWithLicensePlates();

            return Ok();
        }

        private bool PopulateDbWithLicensePlates()
        {
            var licensePlateBuilder = new LicensePlateBuilder();

            var tollFree = _repository
                .GetVehicleType(true)
                .Payload;
            var tollEligable = _repository
                .GetVehicleType(false)
                .Payload;

            var postsucces = true;
            var plates = new[] { "ALEX5689", "HANS0045", "FRED1119", "ANDE3399" };
            for (var i = 0; i < 4; i++)
            {
                var tollEligibility = tollFree;
                if (i > 1)
                    tollEligibility = tollEligable;

                var licenseplate = licensePlateBuilder
                .Reset()
                .ForVehicleType(tollEligibility)
                .WithNumber(plates[i])
                .Build();

                var postResult = _repository.PostLicensePlate(licenseplate);
                if (!postResult)
                    postsucces = false;
            }

            return postsucces;
        }

        private bool PopulateDbWithVehicleTypes()
        {
            var vehicleTypeBuilder = new VehicleTypeBuilder();
            var tollFreeType = vehicleTypeBuilder
                .Reset()
                .IsTollEligable(false)
                .Build();

            var tollEligableType = vehicleTypeBuilder
                .Reset()
                .IsTollEligable(true)
                .Build();

            var postResult = true;
            var postResult1 = _repository.PostVehicleType(tollFreeType);
            var postResult2 = _repository.PostVehicleType(tollEligableType);

            if (!postResult1 || !postResult2)
                postResult = false;

            return postResult;
        }
    }
}