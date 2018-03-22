using Valtech.MoveIT.Logic;
using Xunit;

namespace Valtech.MoveIT.Tests {
  public class PriceOfferTests {
    [Theory]
    [InlineData(49, 10, 1100)]
    [InlineData(50, 10, 2200)]
    [InlineData(100, 10, 3300)]
    [InlineData(150, 10, 4400)]
    public void CalculatePrice_ShouldReturnCorrectResult_ForCorrectLivingAreaAndDistance(double livingArea, double distance, decimal expectedResult) {
      //Arrange
      IPriceOfferService service = new PriceOfferService();

      //Act
      decimal result = service.CalculatePrice(distance, livingArea);

      //Assert
      Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(10, 25, 10, 2200)]
    public void CalculatePrice_ShouldReturnCorrectResult_ForCorrectLivingAreaAndAtticAreaAndDistance(double livingArea, double atticArea, double distance, decimal expectedResult) {
      //Arrange
      IPriceOfferService service = new PriceOfferService();

      //Act
      decimal result = service.CalculatePrice(distance, livingArea, atticArea);

      //Assert
      Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(1012, 123, 1270, 13, 556140)]
    public void CalculatePrice_ShouldReturnCorrectResult_ForCorrectLivingAreaAndAtticAreaAndDistanceAndPiano(double livingArea, double atticArea, double distance, int pianoCount, decimal expectedResult) {
      //Arrange
      IPriceOfferService service = new PriceOfferService();

      //Act
      decimal result = service.CalculatePrice(distance, livingArea, atticArea, pianoCount);

      //Assert
      Assert.Equal(expectedResult, result);
    }
  }
}