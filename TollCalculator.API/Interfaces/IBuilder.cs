namespace TollCalculator.API.Interfaces
{
    public interface IBuilder<BuildReturnType, ResetReturnType>
    {
        BuildReturnType Build();
        ResetReturnType Reset();
    }
}