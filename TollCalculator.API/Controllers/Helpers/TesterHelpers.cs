using TollCalculator.API.Builders;
using TollCalculator.API.Models;
namespace TollCalculator.API.Controllers.Helpers
{
    internal static class TesterHelpers
    {
        // internal static TollEntry GetFakeEntry()
        // {
        //     var date = GetRandomDate();
        //     var plate = GetRandomLicensePlate();
        //     var fee = GetRandomFee();
        //     var entryBuilder = new TollEntryBuilder();
        //     entryBuilder.WithLicencePlate(plate);
        //     entryBuilder.EnteredByDate(date);
        //     entryBuilder.ForFeeOf(fee);
        //     return entryBuilder.Build();
        // }
        internal static int GetRandomFee()
        {
            var rnd = new Random();
            var probability = rnd.Next(0, 101);
            if (probability < 50)
                return 0;
            var fee = rnd.Next(0, 61);
            return fee;
        }
        // private static string GetRandomLicensePlate()
        // {
        //     var allLettersAndnumbers = "abcdefghijklmnopqrstuvwxyzåäö0123456789";
        //     var rnd = new Random();
        //     var licensePlate = new char[6];
        //     for (var i = 0; i < licensePlate.Length; i++)
        //     {
        //         var randomPosition = rnd.Next(0, allLettersAndnumbers.Length - 1);
        //         var randomChar = allLettersAndnumbers[randomPosition];
        //         licensePlate[i] = randomChar;
        //     }
        //     return new String(licensePlate);
        // }
        internal static DateTime GetRandomDate()
        {
            var year = GetRandomInteger(2021, 2022);
            var month = GetRandomInteger(1, 2);
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
        private static int GetRandomInteger(int a, int b)
        {
            var rnd = new Random();
            return rnd.Next(a, b);
        }
    }
}