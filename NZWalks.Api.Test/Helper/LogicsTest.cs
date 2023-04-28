using NZWalks.API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZWalks.Api.Test.Helper
{
     public  class LogicsTest
    {
        [Theory]
        [InlineData("VII", 7)]
        [InlineData("X",10)]
        [InlineData("IX", 9)]

        public void RomanToInt_Test(String inputString, int expected)
        {
            //Act
            int actualResult = Logics.RomanToInt(inputString);
            //Assert
            Assert.Equal(expected, actualResult);
        }
        [Theory]
        [InlineData("XXIV", 24)]
        [InlineData("X", 10)]
        [InlineData("IX", 9)]
        public void RomanToInt_Reverse(String inputString, int expected)
        {
            //Act
            int actualResult = Logics.RomanToInt(inputString);
            //Assert
            Assert.Equal(expected, actualResult);
        }
     }
}
