using Modulus.Api;
using Modulus.Api.Helper;
using Modulus.Shared;
using Modulus.Shared.Models;
using Xunit;

namespace modulus.tests
{
    public class ModulusAlgorithmTests
    {
        [Theory]
        [InlineData("089999","66374958", true)]
        public void Pass_Mod_10_Test(string sortCode, string accountNumber, bool valid)
        {
            WeightTable wt = new WeightTable(new TextFile());
            wt.LoadFromFile();
            
            AccountInfo accountInfo = new AccountInfo(sortCode, accountNumber);
            
            ModulusProcessor processor = new ModulusProcessor(wt, accountInfo);
            Assert.True(processor.IsValid() == valid, "Is not valid");
        }
        
        [Theory]
        [InlineData("107999","88837491", true)]
        [InlineData("202959","63748472", true)]
        public void Pass_Mod_11_Test(string sortCode, string accountNumber, bool valid)
        {
            WeightTable wt = new WeightTable(new TextFile());
            wt.LoadFromFile();
            
            AccountInfo accountInfo = new AccountInfo(sortCode, accountNumber);
            
            ModulusProcessor processor = new ModulusProcessor(wt, accountInfo);
            Assert.True(processor.IsValid() == valid, "Is not valid");
        }
        
        [Theory]
        [InlineData("134020","63849203", true)]
        public void Pass_Exception4_Where_Remainder_Is_Equal_To_CheckDigit_Test(string sortCode, string accountNumber, bool valid)
        {
            WeightTable wt = new WeightTable(new TextFile());
            wt.LoadFromFile();
            
            AccountInfo accountInfo = new AccountInfo(sortCode, accountNumber);
            
            ModulusProcessor processor = new ModulusProcessor(wt, accountInfo);
            Assert.True(processor.IsValid() == valid, "Is not valid");
        }
        
        [Theory]
        [InlineData("772798","99345694", true)]
        public void Pass_Exception7_But_Would_Fail_The_Standard_Check_Test(string sortCode, string accountNumber, bool valid)
        {
            WeightTable wt = new WeightTable(new TextFile());
            wt.LoadFromFile();
            
            AccountInfo accountInfo = new AccountInfo(sortCode, accountNumber);
            
            ModulusProcessor processor = new ModulusProcessor(wt, accountInfo);
            Assert.True(processor.IsValid() == valid, "Is not valid");
        }
        
        [Theory]
        [InlineData("203099","66831036", false)]
        public void Fail_Mod11_Check_And_Fail_Double_Alt_Check_Test(string sortCode, string accountNumber, bool valid)
        {
            WeightTable wt = new WeightTable(new TextFile());
            wt.LoadFromFile();
            
            AccountInfo accountInfo = new AccountInfo(sortCode, accountNumber);
            
            ModulusProcessor processor = new ModulusProcessor(wt, accountInfo);
            Assert.True(processor.IsValid() == valid, "Should be invalid");
        }
        
        [Theory]
        [InlineData("203099","58716970", false)]
        public void Fail_Mod11_Check_And_Pass_Double_Alt_Check_Test(string sortCode, string accountNumber, bool valid)
        {
            WeightTable wt = new WeightTable(new TextFile());
            wt.LoadFromFile();
            
            AccountInfo accountInfo = new AccountInfo(sortCode, accountNumber);
            
            ModulusProcessor processor = new ModulusProcessor(wt, accountInfo);
            Assert.True(processor.IsValid() == valid, "Should be invalid");
        }
        
        [Theory]
        [InlineData("089999","66374959", false)]
        public void Fail_Mod10_Check_Test(string sortCode, string accountNumber, bool valid)
        {
            WeightTable wt = new WeightTable(new TextFile());
            wt.LoadFromFile();
            
            AccountInfo accountInfo = new AccountInfo(sortCode, accountNumber);
            
            ModulusProcessor processor = new ModulusProcessor(wt, accountInfo);
            Assert.True(processor.IsValid() == valid, "Should be invalid");
        }

        [Theory]
        [InlineData("107999","88837493", false)]
        public void Fail_Mod11_Check_Test(string sortCode, string accountNumber, bool valid)
        {
            WeightTable wt = new WeightTable(new TextFile());
            wt.LoadFromFile();
            
            AccountInfo accountInfo = new AccountInfo(sortCode, accountNumber);
            
            ModulusProcessor processor = new ModulusProcessor(wt, accountInfo);
            Assert.True(processor.IsValid() == valid, "Should be invalid");
        }
    }
}