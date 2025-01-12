using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Infrastructure.Repositories.Offers
{
    public interface IOfferRepository
    {
        public Task<Pagination<IEnumerable<Offer>>> FindPaginatedOffersAsync(OfferFilter offerFilter, PaginationParams paginationParams);

        public Task<Offer> FindOfferByIdAsync(string id);

        public Task<Offer> FindOfferByUserIdAsync(string userId);

        public Task InsertOfferAsync(Offer offer);

        public Task<Offer> UpdateOfferAsync(string id, Offer offer);

        public Task<int> DeleteOfferAsync(string id);
    }
}
