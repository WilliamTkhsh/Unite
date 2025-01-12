using Microsoft.AspNetCore.Mvc;
using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Application.Services.SubscriptionService;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ILogger<SubscriptionController> _logger;
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ILogger<SubscriptionController> logger, ISubscriptionService subscriptionService)
        {
            _logger = logger;
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        [Route("{offerId}")]
        public async Task<IActionResult> GetSubscriptionsByOffer([FromRoute] string offerId)
        {
            _logger.LogInformation($"Initiating method {nameof(GetSubscriptionsByOffer)}.");

            var result = await _subscriptionService.GetSubscriptionsByOffer(offerId);
            return Ok();
        }

        [HttpGet]
        [Route("{subscriptionId}")]
        public async Task<IActionResult> GetSubscriptionById([FromRoute] string subscriptionId)
        {
            _logger.LogInformation($"Initiating method {nameof(GetSubscriptionById)}.");
            return Ok(subscriptionId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody] Subscription Subscription)
        {
            _logger.LogInformation($"Initiating method {nameof(CreateSubscription)}.");
            var result = await _subscriptionService.CreateSubscriptionAsync(Subscription);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSubscription([FromRoute] string SubscriptionId, [FromBody] Subscription Subscription)
        {
            _logger.LogInformation($"Initiating method {nameof(UpdateSubscription)}.");
            var result = await _subscriptionService.UpdateSubscriptionAsync(SubscriptionId, Subscription);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSubscription([FromRoute] string SubscriptionId)
        {
            _logger.LogInformation($"Initiating method {nameof(DeleteSubscription)}.");
            var result = await _subscriptionService.DeleteSubscriptionAsync(SubscriptionId);
            return Ok(result);
        }
    }
}
