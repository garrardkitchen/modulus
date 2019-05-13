using System.Collections.Generic;
using Modulus.Shared.Models;

namespace Modulus.api.Contracts
{
    public interface ITextFile
    {
        List<WeightItem> GetWeightItems(string absPath);
    }
}