using System;
using System.Collections.Generic;
using System.Linq;
using Modulus.api;
using Modulus.api.Contracts;
using Modulus.api.Exceptions;
using Modulus.api.Helper;
using Modulus.Shared;
using Modulus.Shared.Enums;
using Modulus.Shared.Models;
using Moq;
using Xunit;

namespace modulus.tests
{
    public class WeightTableTests : IDisposable
    {
        private Modulus.api.WeightTable _wt;

        public WeightTableTests()
        {
            _wt = new Modulus.api.WeightTable(new TextFile());
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
      

        [Theory]
        [InlineData("100009")]
        [InlineData("100021")]
        [InlineData("100041")]
        public void No_Match_Found(string sortCode)
        {
            var mock = new Mock<ITextFile>();
            WeightTable wt = new WeightTable(mock.Object); 
            
            List<WeightItem> weights = new List<WeightItem>
            {
                new WeightItem{Algorithm = ModulusType.MOD10, Ex = 0, Notation = new int[14], Sort1 = "100010", Sort2 = "100020"},
                new WeightItem{Algorithm = ModulusType.MOD10, Ex = 0, Notation = new int[14], Sort1 = "100030", Sort2 = "100040"}
            };
            mock.Setup(x => x.GetWeightItems(It.IsAny<string>())).Returns(weights);
            
            wt.LoadFromFile();
            Assert.True(wt.FindWeights(sortCode).Count == 0, "Should not have found a match");
        }
        
        [Theory]
        [InlineData("100010")]
        [InlineData("100011")]
        [InlineData("100020")]
        [InlineData("100030")]
        [InlineData("100031")]
        [InlineData("100040")]
        public void Match_Found(string sortCode)
        {
            var mock = new Mock<ITextFile>();
            WeightTable wt = new WeightTable(mock.Object); 
            
            List<WeightItem> weights = new List<WeightItem>
            {
                new WeightItem{Algorithm = ModulusType.MOD10, Ex = 0, Notation = new int[14], Sort1 = "100010", Sort2 = "100020"},
                new WeightItem{Algorithm = ModulusType.MOD10, Ex = 0, Notation = new int[14], Sort1 = "100030", Sort2 = "100040"}
            };
            mock.Setup(x => x.GetWeightItems(It.IsAny<string>())).Returns(weights);
            
            wt.LoadFromFile();
            Assert.True(wt.FindWeights(sortCode).Count > 0, "Should have found a match");
        }


        public void Dispose()
        {
            _wt = null;
        }
    }
}