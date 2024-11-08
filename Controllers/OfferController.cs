using Microsoft.AspNetCore.Mvc;
using Unite.Application.Filters;
using Unite.Application.Helpers;
using Unite.Application.Services.OfferService;
using Unite.Domain.Entities;

namespace Unite.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;
        private readonly IOfferService _offerService;

        public OfferController(ILogger<OfferController> logger, IOfferService offerService)
        {
            _logger = logger;
            _offerService = offerService;
        }

        [HttpGet]
        public IActionResult GetPaginatedOffers([FromQuery] OfferFilter filter, [FromQuery] PaginationParams paginationParams)
        {
            _logger.LogInformation($"Initiating method {nameof(GetPaginatedOffers)}.");

            var result = _offerService.GetPaginatedOffersAsync(filter, paginationParams);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOfferById([FromRoute] string offerId)
        {
            _logger.LogInformation($"Initiating method {nameof(GetOfferById)}.");
            return Ok(offerId);
        }

        [HttpPost]        
        public IActionResult CreateOffer([FromBody] Offer offer)
        {
            _logger.LogInformation($"Initiating method {nameof(CreateOffer)}.");
            var result = _offerService.CreateOfferAsync(offer);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateOffer([FromRoute] string offerId, [FromBody] Offer offer)
        {
            _logger.LogInformation($"Initiating method {nameof(UpdateOffer)}.");
            var result = _offerService.UpdateOfferAsync(offerId, offer);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteOffer([FromRoute] string offerId)
        {
            _logger.LogInformation($"Initiating method {nameof(DeleteOffer)}.");
            var result = _offerService.DeleteOfferAsync(offerId);
            return Ok(result);
        }
    }
}
