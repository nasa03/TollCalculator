using Microsoft.AspNetCore.Mvc;
using TollCalculator.API.Builders;
using TollCalculator.API.Interfaces;
using TollCalculator.API.Models;
using TollCalculator.API.Repositories;
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
                AddFakeEntry();

            var postResult = _repository.PostTollEntry(_fakeEntries);

            if (!postResult)
                return NotFound();
            return Ok();
        }

        private void AddFakeEntry()
        {
            var date = GetRandomDate();
            var plate = GetRandomLicensePlate();
            var fee = GetRandomFee();

            var entryBuilder = new TollEntryBuilder();
            entryBuilder.WithLicencePlate(plate);
            entryBuilder.EnteredByDate(date);
            entryBuilder.ForFeeOf(fee);

            var entry = entryBuilder.Build();
            _fakeEntries.Add(entry);
        }

        private int GetRandomFee()
        {
            var rnd = new Random();
            var probability = rnd.Next(0, 101);
            if (probability < 50)
                return 0;
            var fee = rnd.Next(0, 61);
            return fee;
        }

        private string GetRandomLicensePlate()
        {
            var allLettersAndnumbers = "abcdefghijklmnopqrstuvwxyzåäö0123456789";
            var rnd = new Random();
            var licensePlate = new char[6];
            for (var i = 0; i < licensePlate.Length; i++)
            {
                var randomPosition = rnd.Next(0, allLettersAndnumbers.Length - 1);
                var randomChar = allLettersAndnumbers[randomPosition];
                licensePlate[i] = randomChar;
            }
            return new String(licensePlate);
        }

        private DateTime GetRandomDate()
        {
            var year = GetRandomInteger(2015, 2022);
            var month = GetRandomInteger(1, 13);
            var day = GetRandomInteger(1, 29);
            var hour = GetRandomInteger(0, 24);
            var minute = GetRandomInteger(0, 60);
            var second = GetRandomInteger(0, 60);
            var date = new DateTime
            (
                year: year,
                month: month,
                day: day,
                hour: hour,
                minute: minute,
                second: second
            );
            return date;
        }

        private int GetRandomInteger(int a, int b)
        {
            var rnd = new Random();
            return rnd.Next(a, b);
        }

    }
}