using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Application.Mappers;
using Unite.WebApi.Application.ViewModels.Offers;
using Unite.WebApi.Domain.Entities;
using Unite.WebApi.Infrastructure.Repositories.Offers;

namespace Unite.WebApi.Application.Services.OfferService
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
                var offers = await _offerRepository.FindPaginatedOffersAsync(filter, paginationParams);

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
                var offer = await _offerRepository.FindOfferByIdAsync(id);

                return offer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateOfferAsync(OfferInput offerInput)
        {
            try
            {
                //Se o usuário já tiver um offer criado com id dele, bloqueia.
                //var userOffer = await _offerRepository.GetOfferByUserIdAsync(id);

                //if (userOffer)
                //{
                //    return userOffer;
                //}
                var offer = OfferMapper.MapInputToOfferModel(offerInput);

                await _offerRepository.InsertOfferAsync(offer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Offer> UpdateOfferAsync(string id, OfferInput offerInput)
        {
            try
            {
                var oldOffer = await _offerRepository.FindOfferByIdAsync(id);

                if (oldOffer == null)
                {
                    throw new Exception($"Offer {id} does not exists");
                }

                var offer = OfferMapper.MapInputToOfferModel(offerInput);

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
                var offer = await _offerRepository.FindOfferByIdAsync(id);

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
