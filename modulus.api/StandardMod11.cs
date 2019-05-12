using Modulus.Shared;

namespace Modulus.api
{
    public class StandardMod11 : ModulusCalcBase
    {
        public StandardMod11(AccountInfo accountInfo, WeightItem weightItem) : base(accountInfo, weightItem)
        {
        }

        public override int Calculate()
        {
            var num = 0;
            for (var i = 0; i < 6; i++)
            {
                num += int.Parse(this.AccountInfo.SortCode.Substring(i, 1)) * WeightItem.Notation[i];
            }
                
            for (var i = 0; i < 8; i++)
            {
                num += int.Parse(this.AccountInfo.AccountNumber.Substring(i, 1)) * WeightItem.Notation[6+i];
            }
            
            var remainder = num % 11;

            // Exception 4, Modulus 11 only
            
            if (WeightItem.Ex == 4)
            {
                return (WeightItem.Notation[12] + WeightItem.Notation[13]) - remainder;
            }
            
            return remainder;
        }
    }
}