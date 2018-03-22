using System;

namespace Valtech.MoveIT.Logic {
  public class PriceOfferService : IPriceOfferService {
    private const decimal PriceForMovingPiano = 5000;
    private const int SquareMetersPerOneCar = 49;

    public decimal CalculatePrice(double distance, double livingArea, double atticArea = 0, int pianoCount = 0) {
      if (distance < 0.1)
        throw new ArgumentException(nameof(distance));

      if (livingArea < 0.1)
        throw new ArgumentException(nameof(livingArea));

      if (atticArea < 0)
        throw new ArgumentException(nameof(livingArea));

      if (pianoCount < 0)
        throw new ArgumentException(nameof(pianoCount));

      decimal cars = GetNumberOfCars(livingArea, atticArea);
      decimal priceForMovingPiano = GetPriceForMovingPiano(pianoCount);
      decimal priceByDistance = GetPriceByDistance(distance);

      return cars * priceByDistance + priceForMovingPiano;
    }

    private static decimal GetPriceByDistance(double distance) {
      // < 50 km: 1000 SEK + 10 SEK / km
      if (distance < 50)
        return 1000 + (decimal) (distance * 10);

      // >= 50 <= 100 km: 5000 SEK + 8 SEK / km
      if (distance <= 100)
        return 5000 + (decimal) (distance * 8);

      // > 100 km: 10000 SEK + 7 SEK / km
      return 10000 + (decimal) (distance * 7);
    }

    private static int GetNumberOfCars(double livingArea, double atticArea) {
      //cars for living area + cars for attic area
      int result = (int) Math.Ceiling((atticArea * 2) / SquareMetersPerOneCar+(livingArea / SquareMetersPerOneCar));
      return result;
    }

    private static decimal GetPriceForMovingPiano(int pianoCount) {
      return PriceForMovingPiano * pianoCount;
    }
  }
}