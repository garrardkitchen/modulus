using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Modulus.api.Exceptions;
using Modulus.Shared;

namespace Modulus.api
{
    public class WeightTable
    {

        public List<WeightItem> Weights { get; }

        public WeightTable()
        {
            Weights = new List<WeightItem>();
        }

        public void LoadFromFile()
        {
            string[] content = File.ReadAllLines("./data/weight_table.txt");

            for (var i = 0; i < content.Length; i++)
            {
                var cols = content[i].Split(' ');
                var notationSlice = content[i].Substring(19);

                WeightItem item = new WeightItem();
                Enum.TryParse(cols[3], out ModulusType alType);
                item.Sort1 = cols[0];
                item.Sort2 = cols[1];
                item.Algorithm = alType;

                // loop through 14 notation items 

                int[] notation = new int[14];
                for (var x = 0; x < 14; x++)
                {
                    var startPos = x == 0 ? 0 : (x * 5);
                    var col = notationSlice.Substring(startPos, 5);
                    var not = col.Trim();
                    int.TryParse(not, out int num);
                    notation[x] = num;
                }

                item.Notation = notation;

                // check if there is an Exception code after notation segment

                var exStartPos = (14 * 5) + 1;
                if (notationSlice.Length > exStartPos)
                {
                    int.TryParse(notationSlice.Substring(exStartPos), out int ex);
                    if (ex != 0)
                    {
                        item.Ex = ex;
                    }
                }

                Weights.Add(item);
            }
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