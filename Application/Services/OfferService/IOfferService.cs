using Unite.Application.Filters;
using Unite.Application.Helpers;
using Unite.Domain.Entities;

namespace Unite.Application.Services.OfferService
{
    public interface IOfferService
    {
        public Task<Pagination<IEnumerable<Offer>>> GetPaginatedOffersAsync(OfferFilter filter, PaginationParams paginationParams);
        
        public Task<Offer> GetOfferByIdAsync(string id);
        
        public Task<Offer> CreateOfferAsync(Offer offer);
        
        public Task<Offer> UpdateOfferAsync(string id, Offer offer);

        public Task<int> DeleteOfferAsync(string id);
    }
}
