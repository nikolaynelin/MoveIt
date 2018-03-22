namespace Valtech.MoveIT.Logic {
  public interface IPriceOfferService {
    decimal CalculatePrice(double distance, double livingArea, double atticArea=0, int pianoCount=0);
  }
}