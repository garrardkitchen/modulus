using System;
using System.Collections.Generic;
using Modulus.Shared;

namespace Modulus.api
{
    public class DoubleAlternativeMod10 : ModulusCalcBase
    {
        public DoubleAlternativeMod10(AccountInfo accountInfo, WeightItem weightItem) : base(accountInfo, weightItem)
        {
        }
        
        public override int Calculate()
        {
            var num = 0;
            string longNumber = String.Empty;
            List<int> list = new List<int>();
            for (var i = 0; i < 6; i++)
            {
                list.Add(int.Parse(this.AccountInfo.SortCode.Substring(i, 1)) * WeightItem.Notation[i]);
            }
                
            for (var i = 0; i < 8; i++)
            {
                list.Add(int.Parse(this.AccountInfo.AccountNumber.Substring(i, 1)) * WeightItem.Notation[6+i]);
            }

            foreach (var number in list)
            {
                longNumber += $"{number}";
            }
            
            foreach (var number in longNumber.ToCharArray())
            {
                num += Char.IsNumber(number) ? int.Parse(number.ToString()) : 0;
            }
            
            int remainder = num % 10;

            return remainder;
        }
    }
}