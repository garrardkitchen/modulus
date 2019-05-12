using Modulus.Shared;
using Modulus.Shared.Models;

namespace Modulus.api
{
    public class Standard : ModulusCalcBase
    {
        protected int ModulusNumber = 10;
        
        public Standard(AccountInfo accountInfo, WeightItem weightItem) : base(accountInfo, weightItem)
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
            
            return num % ModulusNumber;
        }

    }
}