using Dapper;
using Npgsql;
using System.Data;
using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Infrastructure.Repositories.Offers
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IDbConnection _dbConnection;

        public OfferRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Pagination<IEnumerable<Offer>>> FindPaginatedOffersAsync(OfferFilter offerFilter, PaginationParams paginationParams)
        {
            string sql = @"
                SELECT * FROM TU_OFFERS
                ORDER BY id
                OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;
        
                SELECT COUNT(*) FROM TU_OFFERS;";

            int skip = (paginationParams.CurrentPage - 1) * paginationParams.PageSize;
            int take = paginationParams.PageSize;

            var reader = await _dbConnection.QueryMultipleAsync(sql, new { Skip = skip, Take = take });
            var offers = await reader.ReadAsync<Offer>();
            var totalCount = await reader.ReadFirstAsync<int>();

            return new Pagination<IEnumerable<Offer>>(totalCount, offers, paginationParams.CurrentPage, paginationParams.PageSize);
        }

        public async Task<Offer> FindOfferByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out var uuid))
            {
                throw new ArgumentException("O ID fornecido não é um UUID válido.", nameof(id));
            }

            string sql = @"
                SELECT * FROM TU_OFFERS
                WHERE id = @Id";


            return await _dbConnection.QueryFirstOrDefaultAsync<Offer>(sql, new { Id = uuid });
        }

        public async Task<Offer> FindOfferByUserIdAsync(string userId)
        {
            string sql = @"
                SELECT * FROM TU_OFFERS
                WHERE user_id = @UserId";


            return await _dbConnection.QueryFirstOrDefaultAsync<Offer>(sql, new { UserId = userId });
        }

        public async Task InsertOfferAsync(Offer offer)
        {
            string sql = @"
                INSERT INTO TU_OFFERS (
                    id, 
                    queue, 
                    created_at, 
                    target_tier, 
                    is_tier_restricted, 
                    target_position1, 
                    target_position2, 
                    target_position3, 
                    target_position4, 
                    notes, 
                    status
                ) VALUES (
                    @Id,
                    @Queue,
                    @CreatedAt,
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
                offer.Id,
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

            try
            {
                await _dbConnection.ExecuteAsync(sql, parameters);
            }
            catch (PostgresException ex)
            {
                throw;
            }

        }


        public async Task<Offer> UpdateOfferAsync(string id, Offer offer)
        {
            if (!Guid.TryParse(id, out var uuid))
            {
                throw new ArgumentException("O ID fornecido não é um UUID válido.", nameof(id));
            }

            string sql = @"
                UPDATE TU_OFFERS
                SET
                    queue = @Queue,
                    target_tier = @TargetTier,
                    is_tier_restricted = @IsTierRestricted, 
                    target_position1 = @TargetPosition1,
                    target_position2 = @TargetPosition2,
                    target_position3 = @TargetPosition3,
                    target_position4 = @TargetPosition4,
                    notes = @Notes,
                    status = @Status
                WHERE
                    id = @Id
                RETURNING *;";

            var parameters = new
            {
                offer.Queue,
                offer.TargetTier,
                offer.IsTierRestricted,
                offer.TargetPosition1,
                offer.TargetPosition2,
                offer.TargetPosition3,
                offer.TargetPosition4,
                offer.Notes,
                offer.Status,
                Id = uuid
            };

            return await _dbConnection.QuerySingleAsync<Offer>(sql, parameters);
        }


        public async Task<int> DeleteOfferAsync(string id)
        {
            if (!Guid.TryParse(id, out var uuid))
            {
                throw new ArgumentException("O ID fornecido não é um UUID válido.", nameof(id));
            }

            string sql = @"DELETE FROM TU_OFFERS WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = uuid });
        }
    }
}
