using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Application.ViewModels.Offers;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Application.Services.OfferService
{
    public interface IOfferService
    {
        public Task<Pagination<IEnumerable<Offer>>> GetPaginatedOffersAsync(OfferFilter filter, PaginationParams paginationParams);

        public Task<Offer> GetOfferByIdAsync(string id);

        public Task CreateOfferAsync(OfferInput offer);

        public Task<Offer> UpdateOfferAsync(string id, OfferInput offer);

        public Task<int> DeleteOfferAsync(string id);
    }
}
