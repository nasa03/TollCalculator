namespace TollCalculator.API.GenericClasses
{
    public class Dto<T>
    {
        internal T Payload { get; set; }
        internal bool Success { get; init; }
    }
}