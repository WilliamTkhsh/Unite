using Unite.Application.Filters;
using Unite.Application.Helpers;
using Unite.Domain.Entities;
using Unite.Infrastructure.Repositories.Offers;

namespace Unite.Application.Services.OfferService
{
    public class OfferService : IOfferService
    {
        private readonly ILogger<OfferService> _logger;
        private readonly IOfferRepository _offerRepository;


        public OfferService(ILogger<OfferService> logger, IOfferRepository offerRepository)
        {
            _logger = logger;
            _offerRepository = offerRepository;
        }

        public async Task<Pagination<IEnumerable<Offer>>> GetPaginatedOffersAsync(OfferFilter filter, PaginationParams paginationParams)
        {
            try
            {
                var offers = await _offerRepository.GetPaginatedOffersAsync(filter, paginationParams);

                return offers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Offer> GetOfferByIdAsync(string id)
        {
            try
            {
                var offer = await _offerRepository.GetOfferByIdAsync(id);

                return offer;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Offer> CreateOfferAsync(Offer offer)
        {
            try
            {
                //Se o usuário já tiver um offer criado com id dele, bloqueia.
                //var userOffer = await _offerRepository.GetOfferByUserIdAsync(id);

                //if (userOffer)
                //{
                //    return userOffer;
                //}

                var newOffer = await _offerRepository.InsertOfferAsync(offer);

                return newOffer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Offer> UpdateOfferAsync(string id, Offer offer)
        {
            try
            {
                var oldOffer = await _offerRepository.GetOfferByIdAsync(id);

                if (oldOffer == null)
                {
                    throw new Exception($"Offer {id} does not exists");
                }

                var updatedOffer = await _offerRepository.UpdateOfferAsync(id, offer);

                return updatedOffer;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> DeleteOfferAsync(string id)
        {
            try
            {
                var offer = await _offerRepository.GetOfferByIdAsync(id);

                if (offer == null)
                {
                    throw new Exception($"Offer {id} does not exists");
                }

                var offerId = await _offerRepository.DeleteOfferAsync(id);

                return offerId;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
