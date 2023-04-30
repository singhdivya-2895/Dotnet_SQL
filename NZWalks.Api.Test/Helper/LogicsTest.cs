using NZWalks.API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
        [Theory]
        [InlineData(new int[] { 1,1,2 }, new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 1, 1,1,1, 2,2 }, new int[] { 1, 2 }, 2)]
        public void RemoveDuplicates_UsingList(int[] nums, int[] expectedArray, int expected)
        {
            //Act
            int actualResult = Logics.RemoveDuplicates_UsingList(ref nums);
            //Assert
            Assert.Equal(expected, actualResult);
            for (int i = 0; i < expected; i++)
            {
                Assert.Equal(nums[i], expectedArray[i]); 
            }
        }


        [Theory]
        [InlineData(new int[] { 1, 1, 2 }, new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 1, 1, 1, 1, 2, 2 }, new int[] { 1, 2 }, 2)]
        public void RemoveDuplicates(int[] nums, int[] expectedArray, int expected)
        {
            //Act
            int actualResult = Logics.RemoveDuplicates(ref nums);
            //Assert
            Assert.Equal(expected, actualResult);
            for (int i = 0; i < expected; i++)
            {
                Assert.Equal(nums[i], expectedArray[i]);
            }
        }


        [Theory]
        [InlineData("()", true)]
        [InlineData("(}", false)]
        [InlineData(")()", false)]
        [InlineData("()[]{}", true)]

        public void IsValidString_WithBrackers(String inputString, bool expected)
        {
            //Act
            bool actualResult = Logics.IsValidStringWithBrackets(inputString);
            //Assert
            Assert.Equal(expected, actualResult);
        }

    }
}
