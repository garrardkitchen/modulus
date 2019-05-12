using Modulus.Shared;

namespace Modulus.api
{
    public abstract class ModulusCalcBase : ICalc
    {
        public ModulusCalcBase(AccountInfo accountInfo, WeightItem weightItem)
        {
            AccountInfo = accountInfo;
            WeightItem = weightItem;

            // Exception 7, all Modulus
            
            if (WeightItem.Ex == 7)
            {
                // if notation 'g' = 9, zeroise first 9 elements;
                
                if (WeightItem.Notation[12] == 9)
                {
                    WeightItem.Notation[0] = 0;
                    WeightItem.Notation[1] = 0;
                    WeightItem.Notation[2] = 0;
                    WeightItem.Notation[3] = 0;
                    WeightItem.Notation[4] = 0;
                    WeightItem.Notation[5] = 0;
                    WeightItem.Notation[6] = 0;
                    WeightItem.Notation[7] = 0;
                }
            }
        }

        public abstract int Calculate();

        public WeightItem WeightItem { get; }
        public AccountInfo AccountInfo { get; }
    }
}