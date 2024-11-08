using Unite.Application.Filters;
using Unite.Application.Helpers;
using Unite.Domain.Entities;

namespace Unite.Infrastructure.Repositories.Offers
{
    public interface IOfferRepository
    {
        public Task<Pagination<IEnumerable<Offer>>> GetPaginatedOffersAsync(OfferFilter offerFilter, PaginationParams paginationParams);

        public Task<Offer> GetOfferByIdAsync(string id);

        public Task<Offer> GetOfferByUserIdAsync(string userId);

        public Task<Offer> InsertOfferAsync(Offer offer);

        public Task<Offer> UpdateOfferAsync(string id, Offer offer);

        public Task<int> DeleteOfferAsync(string id);
    }
}
