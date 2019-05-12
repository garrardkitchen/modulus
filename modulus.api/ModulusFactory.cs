using System;
using Modulus.api.Contracts;
using Modulus.Shared;
using Modulus.Shared.Enums;
using Modulus.Shared.Models;

namespace Modulus.api
{
    public class ModulusFactory : ICalc
    {
        private ICalc ModulusItem;
        
        public ModulusFactory(AccountInfo accountInfo, WeightItem weightItem)
        {
            AccountInfo = accountInfo;
            WeightItem = weightItem;

            switch (weightItem.Algorithm)
            {
                case ModulusType.MOD10:
                    ModulusItem = new StandardMod10(accountInfo, weightItem);
                    break;
                case ModulusType.MOD11:
                    ModulusItem = new StandardMod11(accountInfo, weightItem);
                    break;
                case ModulusType.DBLAL:
                    ModulusItem = new DoubleAlternativeMod10(accountInfo, weightItem);
                    break;
                case ModulusType.INVALID:
                    throw new InvalidOperationException("This modulus type is invalid");
                default:
                    throw new InvalidOperationException("This modulus type is invalid");
            }
        }
        
        public int Calculate()
        {
            return ModulusItem.Calculate();
        }

        public WeightItem WeightItem { get; }
        public AccountInfo AccountInfo { get; }
    }
}