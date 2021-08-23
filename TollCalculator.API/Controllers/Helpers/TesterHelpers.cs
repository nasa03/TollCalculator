using TollCalculator.API.Builders;
using TollCalculator.API.Models;
namespace TollCalculator.API.Controllers.Helpers
{
    internal static class TesterHelpers
    {
        internal static int GetRandomFee()
        {
            var rnd = new Random();
            var probability = rnd.Next(0, 101);
            if (probability < 50)
                return 0;
            var fee = rnd.Next(0, 61);
            return fee;
        }

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