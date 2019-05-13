using System;
using System.Collections.Generic;
using System.IO;
using Modulus.Api.Contracts;
using Modulus.Shared.Enums;
using Modulus.Shared.Models;

namespace Modulus.Api.Helper
{
    public class TextFile : ITextFile
    {
        public List<WeightItem> GetWeightItems(string absPath)
        {
            List<WeightItem> items = new List<WeightItem>();
                
            string[] content = File.ReadAllLines(absPath);

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

                items.Add(item);
            }

            return items;
        }
    }
}