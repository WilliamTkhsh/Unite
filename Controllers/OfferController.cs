using Microsoft.AspNetCore.Mvc;
using System.Net;
using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Application.Services.OfferService;
using Unite.WebApi.Application.ViewModels.Offers;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Controllers
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
        public async Task<IActionResult> GetPaginatedOffers([FromQuery] OfferFilter filter, [FromQuery] PaginationParams paginationParams)
        {
            _logger.LogInformation($"Initiating method {nameof(GetPaginatedOffers)}.");

            var result = await _offerService.GetPaginatedOffersAsync(filter, paginationParams);
            return Ok(result);
        }

        [HttpGet]
        [Route("{offerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOfferById([FromRoute] string offerId)
        {
            _logger.LogInformation($"Initiating method {nameof(GetOfferById)}.");
            var offer = await _offerService.GetOfferByIdAsync(offerId);
            return Ok(offer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOffer([FromBody] OfferInput offer)
        {
            _logger.LogInformation($"Initiating method {nameof(CreateOffer)}.");
            await _offerService.CreateOfferAsync(offer);
            return Created();
        }

        [HttpPut]
        [Route("{offerId}")]
        public async Task<IActionResult> UpdateOffer([FromRoute] string offerId, [FromBody] OfferInput offer)
        {
            _logger.LogInformation($"Initiating method {nameof(UpdateOffer)}.");
            var result = await _offerService.UpdateOfferAsync(offerId, offer);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{offerId}")]
        public async Task<IActionResult> DeleteOffer([FromRoute] string offerId)
        {
            _logger.LogInformation($"Initiating method {nameof(DeleteOffer)}.");
            var result = await _offerService.DeleteOfferAsync(offerId);
            return Ok(result);
        }
    }
}
