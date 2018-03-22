using System.Web.Http;
using Valtech.MoveIT.Logic;

namespace Valtech.MoveIT.Api.Controllers {
  public class PriceOfferController : ApiController {
    private readonly IPriceOfferService _priceOfferService;

    public PriceOfferController(IPriceOfferService priceOfferService) {
      _priceOfferService = priceOfferService;
    }

    public PriceOfferController() {
      _priceOfferService = new PriceOfferService();
    }

    public IHttpActionResult Get(int livingArea, int atticArea, int distance, int pianoCount) {
      var result = _priceOfferService.CalculatePrice(livingArea, atticArea, distance, pianoCount);
      return Ok(result);
    }
  }
}