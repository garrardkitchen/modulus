using System;
using System.Linq;
using Modulus.api.Exceptions;
using Modulus.Shared;
using Xunit;

namespace modulus.tests
{
    public class WeightTableTests : IDisposable
    {
        private Modulus.api.WeightTable _wt;

        public WeightTableTests()
        {
            _wt = new Modulus.api.WeightTable();
        }

        [Fact]
        public void Weight_Table_Is_Empty_Test()
        {
            Assert.True(_wt.Weights.Count == 0, "Modulus Weight table data already loaded");
        }

        [Fact]
        public void Weight_Table_Is_Not_Empty_After_Load_Test()
        {
            _wt.LoadFromFile();
            Assert.True(_wt.Weights.Count > 0, "Failed to load the Modulus Weight table");
        }

        [Fact]
        public void No_Invalid_Modulus_Types_Exists_Test()
        {
            _wt.LoadFromFile();
            Assert.False(_wt.Weights.Any(x => x.Algorithm == ModulusType.INVALID), "Invalid Modulus types exist");
        }


        [Fact]
        public void Exception_Thrown_As_Trying_To_Find_Weight_When_Table_Not_Loaded_Test()
        {
            Assert.Throws<MudulusTableNotLoadedException>(() => _wt.FindWeights("123456"));
        }
        
        [Fact]
        public void No_Exception_Thrown_When_Trying_To_Find_Weight_After_Table_Loaded_Test()
        {
            _wt.LoadFromFile();
            Assert.True(_wt.FindWeights("089999").Count > 0, "Failed to find a match");
        }


        public void Dispose()
        {
            _wt = null;
        }
    }
}