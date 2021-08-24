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
            var deleteTollEntriesResult = _repository.DeleteAllTollEntries();
            var deleteLicensePlatesResult = _repository.DeleteAllLicensePlates();
            var deleteVehicleTypeResult = _repository.DeleteAllVehicleTypes();

            if (!deleteVehicleTypeResult || !deleteLicensePlatesResult || !deleteTollEntriesResult)
                return NotFound();

            var postVehicleTypeResult = PopulateDbWithVehicleTypes();
            var postLicensePlateResult = PopulateDbWithLicensePlates();
            var postRandomEntriesResult = PopulateDbWithRandomEntries();

            if (!postVehicleTypeResult || !postLicensePlateResult || !postRandomEntriesResult)
                return StatusCode(406);

            return Ok();
        }

        private bool PopulateDbWithRandomEntries()
        {
            var postSuccess = true;
            var licensePlates = _repository.GetAllLicensePlates();
            foreach (var licensePlate in licensePlates)
            {
                for (var i = 0; i < 25; i++)
                {
                    var randomEntry = GetRandomEntry(licensePlate);
                    _fakeEntries.Add(randomEntry);
                }
            }
            var postResult = _repository.PostTollEntries(_fakeEntries);
            if (!postResult)
                postSuccess = false;

            return postSuccess;
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

            var postSuccess = true;
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
                    postSuccess = false;
            }

            return postSuccess;
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

        private TollEntry GetRandomEntry(LicensePlate licensePlate)
        {
            var tollEntryBuilder = new TollEntryBuilder();
            var date = TesterHelpers.GetRandomDate();
            var fee = TesterHelpers.GetRandomFee();


            return tollEntryBuilder
                .Reset()
                .EnteredByDate(date)
                .WithLicencePlate(licensePlate)
                .ForFeeOf(fee)
                .Build();
        }
    }
}