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

        [Fact]
        public void StringContainsNumeric_Negative()
        {
            // Arrange
            var inputString = "Divya";
            var expectedResult = false;

            // Act
            var actualResult = Utility.StringContainsNumeric(inputString);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void StringContainsNumeric_Positive()
        {
            // Arrange
            var inputString = "Divya1";
            var expectedResult = true;

            // Act
            var actualResult = Utility.StringContainsNumeric(inputString);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }
    }
}
