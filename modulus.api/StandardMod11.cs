using Modulus.Shared.Models;

namespace Modulus.Api
{
    public class StandardMod11 : Standard
    {
        public StandardMod11(AccountInfo accountInfo, WeightItem weightItem) : base(accountInfo, weightItem)
        {
            ModulusNumber = 11;
        }

        public override int Calculate()
        {
            int remainder = base.Calculate();

            // Exception 4, Modulus 11 only
            
            if (WeightItem.Ex == 4)
            {
                return (WeightItem.Notation[12] + WeightItem.Notation[13]) - remainder;
            }
            
            return remainder;
        }
    }
}