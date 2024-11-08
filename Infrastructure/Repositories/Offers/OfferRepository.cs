using Dapper;
using Npgsql;
using System.Data;
using Unite.Application.Filters;
using Unite.Application.Helpers;
using Unite.Domain.Entities;

namespace Unite.Infrastructure.Repositories.Offers
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IDbConnection _dbConnection;

        public OfferRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Pagination<IEnumerable<Offer>>> GetPaginatedOffersAsync(OfferFilter offerFilter, PaginationParams paginationParams)
        {
            string sql = @"
                SELECT * FROM Offer
                ORDER BY Id
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;
        
                SELECT COUNT(*) FROM Products;";

            int skip = (paginationParams.CurrentPage - 1) * paginationParams.PageSize;
            int take = paginationParams.PageSize;

            var reader = await _dbConnection.QueryMultipleAsync(sql, new { Skip = skip, Take = take });
            var offers = await reader.ReadAsync<Offer>();
            var totalCount = await reader.ReadFirstAsync<int>();

            return new Pagination<IEnumerable<Offer>>(totalCount, offers, paginationParams.CurrentPage, paginationParams.PageSize);
        }

        public async Task<Offer> GetOfferByIdAsync(string id)
        {
            string sql = @"
                SELECT * FROM Offer
                WHERE id = @Id";


            return await _dbConnection.QueryFirstOrDefaultAsync(sql, new { Id = id });
        }

        public async Task<Offer> GetOfferByUserIdAsync(string userId)
        {
            string sql = @"
                SELECT * FROM Offer
                WHERE user_id = @UserId";


            return await _dbConnection.QueryFirstOrDefaultAsync(sql, new { UserId = userId });
        }

        public async Task<Offer> InsertOfferAsync(Offer offer)
        {
            string sql = @"
                INSERT INTO Offer (
                    Id, 
                    Queue, 
                    CreatedAt, 
                    TargetTier, 
                    IsTierRestricted, 
                    TargetPosition1, 
                    TargetPosition2, 
                    TargetPosition3, 
                    TargetPosition4, 
                    Notes, 
                    Status
                ) VALUES (
                    @Id,
                    @Queue,
                    NOW(),
                    @TargetTier,
                    @IsTierRestricted,
                    @TargetPosition1,
                    @TargetPosition2,
                    @TargetPosition3,
                    @TargetPosition4,
                    @Notes,
                    @Status
                ) RETURNING *;";

            var parameters = new
            {
                Id = Guid.NewGuid(),
                offer.Queue,
                offer.TargetTier,
                offer.IsTierRestricted,
                offer.TargetPosition1,
                offer.TargetPosition2,
                offer.TargetPosition3,
                offer.TargetPosition4,
                offer.Notes,
                offer.Status
            };

            try
            {
                return await _dbConnection.QuerySingleAsync(sql, parameters);
            }
            catch (PostgresException ex)
            {
                throw;
            }

        }


        public async Task<Offer> UpdateOfferAsync(string id, Offer offer)
        {
            string sql = @"
                UPDATE Offer
                SET
                    Queue = @Queue,
                    CreatedAt = @CreatedAt,
                    TargetTier = @TargetTier,
                    IsTierRestricted = @IsTierRestricted, 
                    TargetPosition1 = @TargetPosition1,
                    TargetPosition2 = @TargetPosition2,
                    TargetPosition3 = @TargetPosition3,
                    TargetPosition4 = @TargetPosition4,
                    Notes = @Notes,
                    Status = @Status
                WHERE
                    Id = @Id;
                RETURNING *;";

            var parameters = new
            {
                Id = Guid.NewGuid(),
                offer.Queue,
                offer.CreatedAt,
                offer.TargetTier,
                offer.IsTierRestricted,
                offer.TargetPosition1,
                offer.TargetPosition2,
                offer.TargetPosition3,
                offer.TargetPosition4,
                offer.Notes,
                offer.Status
            };

            return await _dbConnection.QuerySingleAsync(sql, parameters);
        }


        public async Task<int> DeleteOfferAsync(string id)
        {
            string sql = @"DELETE FROM Offer WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
