using Modulus.Shared;
using Modulus.Shared.Models;

namespace Modulus.api.Contracts
{
    public interface ICalc
    {
        int Calculate();
        WeightItem WeightItem { get; }
        AccountInfo AccountInfo { get; }
    }
}