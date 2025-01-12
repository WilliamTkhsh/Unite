using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Domain.Entities;
using Unite.WebApi.Infrastructure.Repositories.Subscriptions;

namespace Unite.WebApi.Application.Services.SubscriptionService
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ILogger<SubscriptionService> _logger;
        private readonly ISubscriptionRepository _subscriptionRepository;


        public SubscriptionService(ILogger<SubscriptionService> logger, ISubscriptionRepository SubscriptionRepository)
        {
            _logger = logger;
            _subscriptionRepository = SubscriptionRepository;
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByOffer(string offerId)
        {
            try
            {
                var subscriptions = await _subscriptionRepository.FindSubscriptionsByOfferAsync(offerId);

                return subscriptions;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(string id)
        {
            try
            {
                var Subscription = await _subscriptionRepository.FindSubscriptionByIdAsync(id);

                return Subscription;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription Subscription)
        {
            try
            {
                //Se o usuário já tiver um Subscription criado com id dele, bloqueia.
                //var userSubscription = await _SubscriptionRepository.GetSubscriptionByUserIdAsync(id);

                //if (userSubscription)
                //{
                //    return userSubscription;
                //}

                var newSubscription = await _subscriptionRepository.InsertSubscriptionAsync(Subscription);

                return newSubscription;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Subscription> UpdateSubscriptionAsync(string id, Subscription Subscription)
        {
            try
            {
                var oldSubscription = await _subscriptionRepository.FindSubscriptionByIdAsync(id);

                if (oldSubscription == null)
                {
                    throw new Exception($"Subscription {id} does not exists");
                }

                var updatedSubscription = await _subscriptionRepository.UpdateSubscriptionAsync(id, Subscription);

                return updatedSubscription;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> DeleteSubscriptionAsync(string id)
        {
            try
            {
                var Subscription = await _subscriptionRepository.FindSubscriptionByIdAsync(id);

                if (Subscription == null)
                {
                    throw new Exception($"Subscription {id} does not exists");
                }

                var SubscriptionId = await _subscriptionRepository.DeleteSubscriptionAsync(id);

                return SubscriptionId;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
