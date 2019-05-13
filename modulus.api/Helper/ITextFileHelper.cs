using System.Collections.Generic;
using Modulus.Shared.Models;

namespace Modulus.Api.Helper
{
    public interface ITextFileHelper
    {
        List<WeightItem> GetWeightItems(string absPath);
    }
}