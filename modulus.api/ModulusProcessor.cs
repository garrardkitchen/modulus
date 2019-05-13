using System.Collections.Generic;
using System.Linq;
using Modulus.Shared.Models;

namespace Modulus.Api
{
    public class ModulusProcessor
    {
        public WeightTable WeightTable { get; }
        public AccountInfo AccountInfo { get; }

        public ModulusProcessor(WeightTable weightTable, AccountInfo accountInfo)
        {
            WeightTable = weightTable;
            AccountInfo = accountInfo;
        }

        public bool IsValid()
        {
            var items = this.WeightTable.FindWeights(this.AccountInfo.SortCode);
            WeightItem firstCheck = items.FirstOrDefault();
            WeightItem secondCheck = items.Count > 1 ? items[1] : null;
            List<int> listOfExceptions = new List<int> {2, 5, 9, 10, 11, 12, 13, 14};

            if (firstCheck != null)
            {
                ModulusFactory factory = new ModulusFactory(AccountInfo, firstCheck);

                if (factory.Calculate() == 0)
                {
                    if (secondCheck == null || listOfExceptions.Contains(firstCheck.Ex))
                    {
                        return true;
                    }
                    else
                    {
                        factory = new ModulusFactory(AccountInfo, secondCheck);
                        return (factory.Calculate() == 0);
                    }
                }
                else
                {
                    if (listOfExceptions.Contains(firstCheck.Ex))
                    {
                        if (secondCheck == null)
                        {
                            return false;
                        }
                        else
                        {
                            factory = new ModulusFactory(AccountInfo, secondCheck);
                            return (factory.Calculate() == 0);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}