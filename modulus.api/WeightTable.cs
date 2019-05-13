using System.Collections.Generic;
using System.Linq;
using Modulus.Api.Contracts;
using Modulus.Api.Exceptions;
using Modulus.Shared.Models;

namespace Modulus.Api
{
    public class WeightTable
    {
        public ITextFile Helper { get; }

        public List<WeightItem> Weights { get; private set; }

        public WeightTable(ITextFile helper)
        {
            Helper = helper;
            Weights = new List<WeightItem>();
        }

        public void LoadFromFile()
        {
            Weights = Helper.GetWeightItems("./data/weight_table.txt");
        }

        public List<WeightItem> FindWeights(string sortCode)
        {
            if (this.Weights.Count == 0)
            {
                throw new MudulusTableNotLoadedException("The Modulus Weight Table has not been loaded");
            }

            var items = this.Weights.Where(x => int.Parse(x.Sort1) <= int.Parse(sortCode)
                                                && int.Parse(x.Sort2) >= int.Parse(sortCode)).ToList();
            return items;
        }

    }
}