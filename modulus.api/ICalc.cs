using Modulus.Shared;

namespace Modulus.api
{
    public interface ICalc
    {
        int Calculate();
        WeightItem WeightItem { get; }
        AccountInfo AccountInfo { get; }
    }
}