namespace TollCalculator.API.Interfaces
{
    public interface IBuilder<T1, T2>
    {
        T1 Build();
        T2 Reset();
    }
}