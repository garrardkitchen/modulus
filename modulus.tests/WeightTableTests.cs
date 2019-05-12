using System;
using System.Linq;
using modulus.shared;
using Xunit;

namespace modulus.tests
{
    public class WeightTableTests : IDisposable
    {
        private Modulus.api.WeightTable _api;

        public WeightTableTests()
        {
            _api = new Modulus.api.WeightTable();
        }

        [Fact]
        public void Weight_Table_Is_Empty_Test()
        {
            Assert.True(_api.Weights.Count == 0, "Modulus Weight table data already loaded");
        }

        [Fact]
        public void Weight_Table_Is_Not_Empty_After_Load_Test()
        {
            _api.LoadFromFile();
            Assert.True(_api.Weights.Count > 0, "Failed to load the Modulus Weight table");
        }

        [Fact]
        public void No_Invalid_Modulus_Types_Exists_Test()
        {
            _api.LoadFromFile();
            Assert.False(_api.Weights.Any(x => x.Algorithm == ModulusType.INVALID), "Invalid Modulus types exist");
        }

        public void Dispose()
        {
            _api = null;
        }
    }
}