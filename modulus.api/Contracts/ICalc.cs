using Modulus.Shared.Models;

namespace Modulus.Api.Contracts
{
    public interface ICalc
    {
        int Calculate();
        WeightItem WeightItem { get; }
        AccountInfo AccountInfo { get; }
    }
}