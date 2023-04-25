using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.API.Helper;

namespace NZWalks.Api.Test.Helper
{
    public class UtilityTest
    {

        [Theory]
        [InlineData("Divya", false)]
        [InlineData("Divya12", true)]
        [InlineData("23233223", true)]
        [InlineData("dfdffd4", true)]
        [InlineData("Pankaj", false)]
        public void StringContainsNumeric(string inputString, bool expectedResult)
        {

            // Act
            var actualResult = Utility.StringContainsNumeric(inputString);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }


        //public void AllStringNumeric_Positive()
        //{
        //Arrange
        //var inputString = "1000";
        //var expectedResult = true;
        //Act 
        //var actualResult
        //}
        [Theory]
        [InlineData("1234", true)]
        [InlineData("p4759", false)]
        [InlineData("p559", false)]
        [InlineData("pvhfgygfg", false)]
        [InlineData("6798hji", false)]
        [InlineData("hyu89", false)]
        [InlineData("gt67", false)]
        public void AllNumericString(string inputString, bool expectedResult)
        {
            //Act
            var actualResult = Utility.AllNumericString(inputString);
            //Assert
            Assert.Equal(expectedResult,actualResult);
        }
        [Theory]
        [InlineData("pankaj","pankj")]
        [InlineData("aaaaaa","a")]
        [InlineData("aaabbb","ab")]
        [InlineData("aabbc","abc")]
        [InlineData("bbbcdefgh","bcdefgh")]
        [InlineData("", "")]
        public void UniqueCharacter(String inputString ,string expected)
        {
            //Act
            var actualResult = Utility.UniqueCharacter(inputString);
            //Assert
            Assert.Equal(expected, actualResult);
        }
    }
}
