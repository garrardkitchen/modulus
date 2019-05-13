using System.Collections.Generic;
using Modulus.Shared.Models;

namespace Modulus.Api.Contracts
{
    public interface ITextFile
    {
        List<WeightItem> GetWeightItems(string absPath);
    }
}