using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Unite.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;

        public OfferController(ILogger<OfferController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetPaginatedOffers()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOfferById([FromRoute] string offerId)
        {
            return Ok(offerId);
        }
    }
}
