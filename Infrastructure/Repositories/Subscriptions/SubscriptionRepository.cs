using Dapper;
using Npgsql;
using System.Data;
using Unite.WebApi.Application.Filters;
using Unite.WebApi.Application.Helpers;
using Unite.WebApi.Domain.Entities;

namespace Unite.WebApi.Infrastructure.Repositories.Subscriptions
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IDbConnection _dbConnection;

        public SubscriptionRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Subscription>> FindSubscriptionsByOfferAsync(string offerId)
        {
            string sql = @"
                SELECT * FROM TU_SUBSCRIPTIONS
                WHERE offer_id = @OfferId";

            var reader = await _dbConnection.QueryMultipleAsync(sql, new { OfferId = offerId });
            var subscriptions = await reader.ReadAsync<Subscription>();

            return subscriptions;
        }

        public async Task<Subscription> FindSubscriptionByIdAsync(string id)
        {
            string sql = @"
                SELECT * FROM TU_SUBSCRIPTIONS
                WHERE subscription_id = @Id";


            return await _dbConnection.QueryFirstOrDefaultAsync(sql, new { Id = id });
        }

        public async Task<Subscription> FindSubscriptionByUserIdAsync(string userId)
        {
            string sql = @"
                SELECT * FROM TU_SUBSCRIPTIONS
                WHERE user_id = @UserId";


            return await _dbConnection.QueryFirstOrDefaultAsync(sql, new { UserId = userId });
        }

        public async Task<Subscription> InsertSubscriptionAsync(Subscription Subscription)
        {
            string sql = @"
                INSERT INTO TU_SUBSCRIPTIONS (
                    position, 
                    notes, 
                    created_at,
                    updated_at
                ) VALUES (
                    @Position,
                    @Notes,                    
                    NOW(),
                    NOW()
                ) RETURNING *;";

            var parameters = new
            {
                Subscription.Position,
                Subscription.Notes
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


        public async Task<Subscription> UpdateSubscriptionAsync(string id, Subscription Subscription)
        {
            string sql = @"
                UPDATE TU_SUBSCRIPTIONS
                SET
                    position = @Position, 
                    notes = @Notes,
                    updated_at = NOW()
                WHERE
                    subscription_id = @SubscriptionId;
                RETURNING *;";

            var parameters = new
            {
                Subscription.Position,
                Subscription.Notes,
                Subscription.SubscriptionId,
            };

            return await _dbConnection.QuerySingleAsync(sql, parameters);
        }


        public async Task<int> DeleteSubscriptionAsync(string id)
        {
            string sql = @"DELETE FROM TU_SUBSCRIPTIONS WHERE subscription_id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
